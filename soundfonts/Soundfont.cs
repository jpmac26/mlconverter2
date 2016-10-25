using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace mlconverter2.soundfonts
{
    class Soundfont
    {
        // ---- data arrays ----

        public static int[] instrumentPointers;
        public static int[] samplePointers;

        public static int[][] instrumentDef;
        public static int[][] sampleDef;

        // ---- variables ----

        int activeSample;

        // ---- properties ----

        public int ActiveSample
        {
            get { return activeSample; }
            set { activeSample = value; }
        }

		public int[] SuperstarSample
		{
			get { return sampleDef[activeSample]; }
		}

		public int[] KazooieSample
        {
            get { return sampleDef[activeSample]; }
        }

        // ---- functions ----

        public void PrepareSoundfont(BinaryReader file, int romFormat)
        {
			switch (romFormat)
			{
				case 0x00: //Superstar Saga
					int iTableStart = 0x0021D1CC;
					file.BaseStream.Position = iTableStart; // Start of instrument offset table

					ushort size = file.ReadUInt16();
					instrumentPointers = new int[(size / 2)];
					for (int i = 0; i < (size / 2); i++)
					{
						ushort offset = file.ReadUInt16();
						instrumentPointers[i] = iTableStart + offset - 2;
					}
					
					instrumentDef = new int[(size / 2)][];
					for (int i = 0; i < (size / 2); i++)
					{
						file.BaseStream.Position = instrumentPointers[i];

						instrumentDef[i] = new int[2];
						instrumentDef[i][0] = file.ReadInt32();
						instrumentDef[i][1] = file.ReadInt32();
					}



					int sTableStart = 0x00A806B8;
					file.BaseStream.Position = sTableStart; // Start of sample offset table

					samplePointers = new int[0xEC];
					for (int i = 0; i < 0xEC; i++)
					{
						int offset = file.ReadInt32();
						if (offset == 0x40000000) break; // this means we have run into the start of sample data, so we will stop

						if (offset == 0)
						{
							samplePointers[i] = 0; // Set nonexistent offsets to zero, so they are easier to notice
						}
						else
						{
							samplePointers[i] = sTableStart + offset;
						}
					}

					sampleDef = new int[0xEC][];
					for (int i = 0; i < 0xEC; i++)
					{
						if (samplePointers[i] != 0)
						{
							sampleDef[i] = new int[4]; // The sample header contains 4 values

							//This is just in case there is empty space in-between sample
							file.BaseStream.Position = samplePointers[i];

							for (int j = 0; j < 4; j++)
							{
								sampleDef[i][j] = file.ReadInt32();
							}
						}
					}
					break;

				case 0x01: //Banjo-Kazooie
					file.BaseStream.Position = 0x006ADE44;
					instrumentPointers = new int[0x32];
					for (int i = 0; i < 0x32; i++) instrumentPointers[i] = Common.repairPointer(file.ReadInt32());

					file.BaseStream.Position = 0x006ADF0C;
					samplePointers = new int[0x90];
					for (int i = 0; i < 0x90; i++) samplePointers[i] = Common.repairPointer(file.ReadInt32());

					instrumentDef = new int[0x32][];

					for (int i = 0; i < 0x32; i++)
					{
						instrumentDef[i] = new int[0x44 / 4];
						file.BaseStream.Position = instrumentPointers[i];

						for (int j = 0; j < 0x44 / 4; j++) instrumentDef[i][j] = file.ReadInt32();
					}

					sampleDef = new int[0x90][];

					for (int i = 0; i < 0x90; i++)
					{
						sampleDef[i] = new int[0x44 / 4];
						file.BaseStream.Position = samplePointers[i];

						for (int j = 0; j < 0x44 / 4; j++) sampleDef[i][j] = file.ReadInt32();
					}
					break;
			}

            file.Close();
        }

        public void KazooieSampleToWave(BinaryReader gba, BinaryWriter file)
        {
            int sampleLength = sampleDef[activeSample][6] - sampleDef[activeSample][4];
            gba.BaseStream.Position = Common.repairPointer(sampleDef[activeSample][4]);
            byte[] sample = gba.ReadBytes(sampleLength);

            file.Write(new byte[] { 0x52, 0x49, 0x46, 0x46 });
            file.Write(sampleLength + 0x24);
            file.Write(new byte[] { 0x57, 0x41, 0x56, 0x45, 0x66, 0x6D, 0x74, 0x20, 0x10, 0x00, 0x00, 0x00, 0x01, 0x00, 0x01, 0x00 });
            file.Write(sampleDef[activeSample][2]);
            file.Write(sampleDef[activeSample][2]);
            file.Write(new byte[] { 0x01, 0x00, 0x08, 0x00, 0x64, 0x61, 0x74, 0x61 });
            file.Write(sampleLength);
			
			for (int i = 0; i < sample.Length; i++) file.Write(Convert.ToSByte(sample[i] - 0x80));

            gba.Close();
            file.Close();
        }

		public void SuperstarSampleToWave(BinaryReader gba, BinaryWriter file)
		{
			int sampleLength = sampleDef[activeSample][3];
			gba.BaseStream.Position = samplePointers[activeSample] + 0x10;
			byte[] sample = gba.ReadBytes(sampleLength);

			file.Write(new byte[] { 0x52, 0x49, 0x46, 0x46 });
			file.Write(sampleLength + 0x24);
			file.Write(new byte[] { 0x57, 0x41, 0x56, 0x45, 0x66, 0x6D, 0x74, 0x20, 0x10, 0x00, 0x00, 0x00, 0x01, 0x00, 0x01, 0x00 });
			file.Write(sampleDef[activeSample][1] / 0x400);
			file.Write(sampleDef[activeSample][1] / 0x400); // (Samplerate) * (1 channel) * ((8 bits per sample) / 8)
			file.Write(new byte[] { 0x01, 0x00, 0x08, 0x00, 0x64, 0x61, 0x74, 0x61 });
			file.Write(sampleLength);

			for (int i = 0; i < sample.Length; i++) file.Write(Convert.ToByte(sample[i]));

			gba.Close();
			file.Close();
		}
	}
}
