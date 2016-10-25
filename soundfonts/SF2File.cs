using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace mlconverter2.soundfonts
{
    // This is our own type, not part of the specification
    public enum SampleType
    {
        UNSIGNED_8,
        SIGNED_8,
        SIGNED_16,
        GAMEBOY_CH3,
        BDPCM
    }
    
    public enum SSDataIndexes
    {
        LOOP_FLAG,
        SAMPLE_RATE,
        LOOP_START,
        SIZE
    }

    //SF2 File Format
    class SF2File
    {
        MemoryStream fileDataStream;
	    uint Size = 0;
        
        //All 3 chunks of the SF2 file
        InfoListChunk infolist_chunk;
        SdtaListChunk sdtalist_chunk;
        HydraChunk pdtalist_chunk;
        
        //Constructor to change the default sample rate
        public SF2File(int[][] instruments)
        {
            fileDataStream = new MemoryStream();
            Size = 0;
            infolist_chunk = new InfoListChunk(ref fileDataStream);
            sdtalist_chunk = new SdtaListChunk(ref fileDataStream);
            pdtalist_chunk = new HydraChunk(ref fileDataStream);
        }

		public byte[] getAsciiBytes(string value)
		{
			Encoding enc = Encoding.GetEncoding("us-ascii", new EncoderExceptionFallback(), new DecoderExceptionFallback());

			try
			{
				byte[] bytes = enc.GetBytes(value);
				return bytes;
			}
			catch (EncoderFallbackException e)
			{
				Console.WriteLine("Unable to encode {0} at index {1}", e.IsUnknownSurrogate() ? String.Format("U+{0:X4} U+{1:X4}", Convert.ToUInt16(e.CharUnknownHigh), Convert.ToUInt16(e.CharUnknownLow)) : String.Format("U+{0:X4}", Convert.ToUInt16(e.CharUnknown)), e.Index);
			}

			return null;
		}

		public bool Write(string path)
        {
            // This function adds the "terminal" data in subchunks that are required
            // by the (retarded) SF2 standard
            add_terminals();

            // Compute size of the entire file
            // (this will also compute the size of the chunks)
            Size = 4;
            Size += infolist_chunk.calcSize() + 8;
            Size += sdtalist_chunk.calcSize() + 8;
            Size += pdtalist_chunk.calcSize() + 8;

            //Write RIFF header
            fileDataStream.Write(getAsciiBytes("RIFF"), 0, 4);
            fileDataStream.Write(BitConverter.GetBytes(Size), 0, 4);
            fileDataStream.Write(getAsciiBytes("sfbk"), 0, 4);

            //Write all 3 chunks
            infolist_chunk.Write();
            sdtalist_chunk.Write();
            pdtalist_chunk.Write();

            //Write and close output file
            if (!File.Exists(path))
            {
                fileDataStream.WriteTo(File.Create(path));
                
                /* using (FileStream fs = File.Create(path))
                {
                    fs.Write(fileDataStream.ToArray());
                } */
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", path);
                return false;
            }
	        return true;
        }
        
        //Add terminal data in subchunks where it is required by the standard
        public void add_terminals()
        {
            add_new_sample_header("EOS", 0, 0, 0, 0, 0, 0, 0);
            add_new_instrument("EOI");
            add_new_inst_bag();
            add_new_inst_generator();
            add_new_inst_modulator();
            add_new_preset("EOP", 255, 255);
            add_new_preset_bag();
            add_new_preset_generator();
            add_new_preset_modulator();
        }

        //Add a brand new preset header to the list
        public void add_new_preset(string name, int patch, int bank)
        {
            pdtalist_chunk.phdr_subchunk.add_preset(sfPresetHeader(this, name, patch, bank));
        }

        //Add a brand new instrument
        public void add_new_instrument(string name)
        {
            pdtalist_chunk.inst_subchunk.add_instrument(sfInst(this, name));
        }

        //Add a new instrument bag to the instrument bag list
        //DO NOT use this to add a preset bag !
        public void add_new_inst_bag()
        {
            pdtalist_chunk.ibag_subchunk.add_bag(sfBag(this, false));
        }

        //Add a new preset bag to the preset bag list
        //DO NOT use this to add an instrument bag !
        public void add_new_preset_bag()
        {
            pdtalist_chunk.pbag_subchunk.add_bag(sfBag(this, true));
        }

        //Add a new modulator to the list
        public void add_new_preset_modulator()
        {
            pdtalist_chunk.pmod_subchunk.add_modulator(sfModList(this));
        }

        //Add a new blank generator to the list
        public void add_new_preset_generator()
        {
            pdtalist_chunk.pgen_subchunk.add_generator(sfGenList(this));
        }

        //Add a new customized generator to the list
        public void add_new_preset_generator(SFGenerator operation, ushort value)
        {
            pdtalist_chunk.pgen_subchunk.add_generator(sfGenList(this, operation, genAmountType(value)));
        }

        //Add a new customized generator to the list
        public void add_new_preset_generator(SFGenerator operation, byte lo, byte hi)
        {
            pdtalist_chunk.pgen_subchunk.add_generator(sfGenList(this, operation, genAmountType(lo, hi)));
        }

        //Add a new modulator to the list
        public void add_new_inst_modulator()
        {
            pdtalist_chunk.imod_subchunk.add_modulator(sfModList(this));
        }

        //Add a new blank generator to the list
        public void add_new_inst_generator()
        {
            pdtalist_chunk.igen_subchunk.add_generator(sfGenList(this));
        }

        //Add a new customized generator to the list
        public void add_new_inst_generator(SFGenerator operation, ushort value)
        {
            pdtalist_chunk.igen_subchunk.add_generator(sfGenList(this, operation, genAmountType(value)));
        }

        //Add a new customized generator to the list
        public void add_new_inst_generator(SFGenerator operation, byte lo, byte hi)
        {
            pdtalist_chunk.igen_subchunk.add_generator(sfGenList(this, operation, genAmountType(lo, hi)));
        }

        //Add a brand new header
        public void add_new_sample_header(string name, int start, int end, int start_loop, int end_loop, int sample_rate, int original_pitch, int pitch_correction)
        {
            pdtalist_chunk.shdr_subchunk.add_sample(sfSample(this, name, start, end, start_loop, end_loop, sample_rate, original_pitch, pitch_correction));
        }

        // Add a new sample and create corresponding header
        public void add_new_sample(int[] data, SampleType type, string name, uint pointer, uint size,
                            bool loop_flag, uint loop_pos, uint original_pitch, uint pitch_correction, uint sample_rate);
        {
            uint dir_offset = sdtalist_chunk.smpl_subchunk.add_sample(data, type, pointer, size, loop_flag, loop_pos);
            // If the sample is looped const SF2 standard requires we add the 8 bytes
            // at the start of the loop at the end (what a dumb standard)
            uint dir_end, dir_loop_end, dir_loop_start;

            if (loop_flag)
            {
                dir_end = dir_offset + size + 8;
                dir_loop_end = dir_offset + size;
                dir_loop_start = dir_offset + loop_pos;
            }
            else
            {
                dir_end = dir_offset + size;
                dir_loop_end = 0;
                dir_loop_start = 0;
            }

            // Create sample header and add it to the list
            add_new_sample_header(name, dir_offset, dir_end, dir_loop_start, dir_loop_end, sample_rate, original_pitch, pitch_correction);
        }
        
        // Add new sample using default sample rate
        public void add_new_sample(FILE *file, SampleType type, string name, uint pointer, uint size,
                            bool loop_flag, uint loop_pos, uint original_pitch, uint pitch_correction)
        {
            add_new_sample(file, type, name, pointer, size, loop_flag, loop_pos, original_pitch, pitch_correction, default_sample_rate);
        }

        public static ushort get_ibag_size()
        {
            return pdtalist_chunk.ibag_subchunk.bag_list.size();
        }

        public static ushort get_igen_size()
        {
            return pdtalist_chunk.igen_subchunk.generator_list.size();
        }

        public static ushort get_imod_size()
        {
            return pdtalist_chunk.imod_subchunk.modulator_list.size();
        }

        public static ushort get_pbag_size()
        {
            return pdtalist_chunk.pbag_subchunk.bag_list.size();
        }

        public static ushort get_pgen_size()
        {
            return pdtalist_chunk.pgen_subchunk.generator_list.size();
        }

        public static ushort get_pmod_size()
        {
            return pdtalist_chunk.pmod_subchunk.modulator_list.size();
        }
    }
}
