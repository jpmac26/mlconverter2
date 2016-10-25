using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace mlconverter2.soundfonts
{
    //SF2 generic chunk format
    class SF2Chunk
    {
        public uint size; // Size in bytes of the chunk
        protected char[] name = new char[4]; // 4-letter name of the chunk
        protected MemoryStream sf2;
        
        // Constructor (should be systematically called by sub-classes)
        public SF2Chunk(ref MemoryStream _sf2, string _name, uint _size = 0)
        {    
            sf2 = _sf2;			// Link to output SF2 data memory stream
            size = _size;		// The chunk starts bank
            for(uint i = 0; i < 4; ++i)
            {
                name[i] = _name.ToCharArray()[i];
            }
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

		// Write the name and size of the (sub)chunk (should be systematically called by sub-classes)
		public virtual bool Write()
        {
            sf2.Write(getAsciiBytes(new string(name)), 0, 8);
            return true;
        }
	}
}
