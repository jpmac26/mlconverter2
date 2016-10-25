using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace mlconverter2.soundfonts
{
	//Sample Data List chunk format
	class SdtaListChunk : SF2Chunk
	{
		// Sub-chunks in SdtaList chunk
		public SMPLSubChunk smpl_subchunk;

		// Sample Data List constructor
		public SdtaListChunk(ref MemoryStream _sf2) : base(ref _sf2, "LIST")
		{
			smpl_subchunk = new SMPLSubChunk(ref _sf2);
		}

		// Compute size of the Sample Data List chunk
		public uint calcSize()
		{
			size = 4;
			size += smpl_subchunk.size + 8;
			return size;
		}

		public override bool Write()
		{
			base.Write();                   // Write chunk name and size
			sf2.Write(getAsciiBytes("sdta"), 0, 4);        // Chunk header

			smpl_subchunk.Write();          // Write the sub-chunk element
			return true;
		}
	}


	/// Sample Data List sub-chunk formats


	// Class for the samples sub chunk
	class SMPLSubChunk : SF2Chunk
	{
		// To prevent the program from using a lot of memory by caching all
		// samples before writing them (which is not useful)
		// I instead store a list of pointers to sample data, and the data
		// is directly read from the original file when the sample should
		// be written to output

		// I made this function as generic as possible, so any sample can be loaded
		// from any file, in various formats.

		bool[] loop_flag_list;          // Loop flag for samples (required as we need to copy data after the loop)
		uint[] loop_pos_list;       // Loop start data (irrelevent if loop flag is clear - add dummy data)
		uint[] size_list;           // Size of the data sample
		SampleType[] sample_type_list;  // Type of sample (unsigned / signed, 8/16 bits etc...)

		public SMPLSubChunk(ref MemoryStream _sf2) : base(ref _sf2, "smpl")
		{
			for (int i = 0; i < SF2File.InstrumentData.Length; i++)
			{
				loop_flag_list[i] = SF2File.InstrumentData[i][0] == 0x40000000;
				loop_pos_list[i] = (uint)SF2File.InstrumentData[i][2];
				size_list[i] = (uint)SF2File.InstrumentData[i][3];
			}
		}

		// Write all samples to output in little Indian format
		public override bool Write()
		{
			base.Write();

			for (uint i = 0; i < SF2File.InstrumentData.Length; i++)
			{
				// Seek at the start of the sample in input file

				// Using a cached buffer really speeds up the writing process a lot!!!
				short[] outbuf = new short[SF2File.InstrumentData[i][3]];

				switch (sample_type_list[i])
				{
					// Source is unsigned 8 bits
					case SampleType.UNSIGNED_8:
						{
							byte[] data = new byte[size_list[i]];
							fread(data, 1, size_list[i], file_list[i]);
							// Convert to signed 16 bits
							for (uint j = 0; j < size_list[i]; j++)
								outbuf[j] = (data[j] - 0x80) << 8;
							data = null;
						}
						break;

					// Source is signed 8 bits
					case SampleType.SIGNED_8:
						{
							sbyte[] data = new sbyte[size_list[i]];
							fread(data, 1, size_list[i], file_list[i]);

							for (uint j = 0; j < size_list[i]; j++)
								outbuf[j] = data[j] << 8;
							data = null;
						}
						break;

					case SampleType.SIGNED_16:
						// Just read raw data, no conversion needed
						fread(outbuf, 2, size_list[i], file_list[i]);
						break;

					case SampleType.GAMEBOY_CH3:
						{
							// Conversion lookup table
							short[] conv_tbl =
							{
							-0x4000, -0x3800, -0x3000, -0x2800, -0x2000, -0x1800, -0x0100, -0x0800,
							0x0000, 0x0800, 0x1000, 0x1800, 0x2000, 0x2800, 0x3000, 0x3800
						};

							int num_of_repts = size_list[i] / 32;
							// Data is always on 16 bytes
							byte[] data = new byte[16];
							fread(data, 1, 16, file_list[i]);

							for (int j = 0, l = 0; j < 16; j++)
							{
								for (int k = num_of_repts; k != 0; k--, l++)
									outbuf[l] = conv_tbl[data[j] >> 4];

								for (int k = num_of_repts; k != 0; k--, l++)
									outbuf[l] = conv_tbl[data[j] & 0xf];
							}
						}
						break;

					case SampleType.BDPCM:
						{
							sbyte[] delta_lut = { 0, 1, 4, 9, 16, 25, 36, 49, -64, -49, -36, -25, -16, -9, -4, -1 };

							/*
							 * A block consists of an initial signed 8 bit PCM byte
							 * followed by 63 nibbles stored in 32 bytes.
							 * The first of these bytes has a zero padded (unused) high nibble.
							 * This makes up of a total block size of 65 (0x21) bytes each.
							 *
							 * Decoding works like this:
							 * The initial byte can be directly read without decoding. Then each
							 * next sample can be decoded by putting the nibble into the delta-lookup-table 
							 * and adding that value to the previously calculated sample
							 * until the end of the block is reached.
							 */

							uint nblocks = size_list[i] / 64;       // 64 samples per block

							char[][] data = new char[nblocks][33];
							fread(data, 33, nblocks, file_list[i]);

							for (uint block = 0; block < nblocks; ++block)
							{
								sbyte sample = data[block][0];
								outbuf[64 * block] = sample << 8;
								sample += delta_lut[data[block][1] & 0xf];
								outbuf[64 * block + 1] = sample << 8;
								for (uint j = 1; j < 32; ++j)
								{
									byte d = data[block][j + 1];
									sample += delta_lut[d >> 4];
									outbuf[64 * block + 2 * j] = sample << 8;
									sample += delta_lut[d & 0xf];
									outbuf[64 * block + 2 * j + 1] = sample << 8;
								}
							}
							memset(outbuf + 64 * nblocks, 0, size_list[i] - 64 * nblocks);      // Remaining samples are always 0

							data = null;
						}
						break;
				}

				// Write buffer
				sf2.Write(outbuf, 0, size_list[i], sf2.out);

				// If loop enabled, write 8 samples after loop point
				// (required by the dumb SF2 standard)
				if (loop_flag_list[i])
					fwrite(outbuf + loop_pos_list[i], 2, 8, sf2.out);

				// Write 46 dummy zeroed samples at the end
				// which is also required by the very dumb SF2 standard
				for (int j = 0; j < 2 * 46; j++)
					putc(0x00, sf2.out);

				outbuf = null;
			}

			return true;
		}
	}
}
