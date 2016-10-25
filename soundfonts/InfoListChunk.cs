using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace mlconverter2.soundfonts
{
    //Info List chunk format
    class InfoListChunk : SF2Chunk
    {
        // Sub-chunks in InfoList chunk
        IFILSubChunk ifil_subchunk;
        HeaderSubChunk isng_subchunk;
        HeaderSubChunk inam_subchunk;
        HeaderSubChunk ieng_subchunk;
        HeaderSubChunk icop_subchunk;
        
        // Info List constructor
        public InfoListChunk(ref MemoryStream _sf2) : base(ref _sf2, "LIST")
        {    
            ifil_subchunk = new IFILSubChunk(ref _sf2);
            isng_subchunk = new HeaderSubChunk(ref _sf2, "isng", "EMU8000");
            inam_subchunk = new HeaderSubChunk(ref _sf2, "INAM", "Unnamed");
            ieng_subchunk = new HeaderSubChunk(ref _sf2, "IENG", "Mario & Luigi Superstar Saga SoundFont");
            icop_subchunk = new HeaderSubChunk(ref _sf2, "ICOP", "Ripped with MLConverter v2.1 (c) 2016 by Jesse64 & CaptainSwag101");
        }

        // Compute size of the Info List chunk
        public uint calcSize()
        {
            size = 4;
            size += ifil_subchunk.size + 8;
            size += isng_subchunk.size + 8;
            size += inam_subchunk.size + 8;
            size += ieng_subchunk.size + 8;
            size += icop_subchunk.size + 8;
            return size;
        }

        public override bool Write()
        {
            base.Write();				    // Write chunk name and size
            fwrite("INFO", 1, 4, sf2->out);	// Chunk header

            ifil_subchunk.Write();			// Write all 5 sub-chunk elements
            isng_subchunk.Write();
            inam_subchunk.Write();
            ieng_subchunk.Write();
            icop_subchunk.Write();
            return true;
        }
	}
    
    
    /// Info List sub-chunk formats
    
    
    class IFILSubChunk : SF2Chunk
    {
	    byte wMajor = 2;
	    byte wMinor = 1;
        
        public IFILSubChunk(ref MemoryStream _sf2) : base(ref _sf2, "ifil", 4)
        {
            wMajor = 2;
            wMinor = 1;
        }
        
        public override bool Write()
        {
            base.Write();
            sf2.WriteByte(0);
			sf2.WriteByte(wMajor);
			sf2.WriteByte(0);
			sf2.WriteByte(wMinor);
            return true;
        }
    }
    
    class HeaderSubChunk : SF2Chunk
    {
        string field;
        
        public HeaderSubChunk(ref MemoryStream _sf2, string subchunk_type,  string s) : base(ref _sf2, subchunk_type, (uint)s.Length + 1)
        {		
            field = s; // The string is null-terminated, so the "size" argument is incremented one extra byte
        }

        public override bool Write()
        {
            base.Write();
            // Convert the string to ASCII, then write it followed by a null character
            byte[] stringBytes = getAsciiBytes(field + "\0");
            if (stringBytes == null) return false;
            
            sf2.Write(stringBytes, 0, stringBytes.Length);
            return true;
        }
    }
}
