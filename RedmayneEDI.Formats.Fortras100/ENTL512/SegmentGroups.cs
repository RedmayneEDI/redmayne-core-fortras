using RedmayneEDI.Formats.Fortras100.ENTL512.Models;
using System;
using System.Collections.Generic;

namespace RedmayneEDI.Formats.Fortras100.ENTL512
{
    public class LOADING_UNIT
    {
        public M10 M10 { get; set; }

        public M20 M20 { get; set; }
        
        public LOADING_UNIT()
        {
            M10 = new M10();
            M20 = new M20();
        }

        public override string ToString()
        {
            return $"{M10}" +
                $"{M20}";
        }
    }

    public class UEZ
    {
        public List<O00> O00 { get; set; }
        
        public List<O10> O10 { get; set; }

        public List<O20> O20 { get; set; }

        public UEZ()
        {
            O00 = new List<O00>();
            O10 = new List<O10>();
            O20 = new List<O20>();
        }

        public override string ToString()
        {
            return $"{Formatting.RecordSet<O00>(O00, 2)}"+
                $"{Formatting.RecordSet<O10>(O10, 999)}"+
                $"{Formatting.RecordSet<O20>(O20, 999)}";
        }
    }
}
