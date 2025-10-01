using RedmayneEDI.Formats.Fortras100.STAT512.Models;
using System;
using System.Collections.Generic;

namespace RedmayneEDI.Formats.Fortras100.STAT512
{
    public class CONSIGNMENT
    {
        public Q10 Q10 { get; set; }
        public List<Q11> Q11 { get; set; }
        public List<BARCODE> BARCODES { get; set; }
        
        public CONSIGNMENT()
        {
            Q10 = new Q10();
            Q11 = new List<Q11>();
            BARCODES = new List<BARCODE>();
        }

        public override string ToString()
        {
            return $"{Q10}" +
                $"{Formatting.RecordSet<Q11>(Q11, 999)}" +
                $"{Formatting.RecordSet<BARCODE>(BARCODES, 999)}";
        }

   }

    public class BARCODE
    {
        public Q20 Q20 { get; set; }
        public List<Q30> Q30 { get; set; }

        public  BARCODE()
        {
            Q20 = new Q20();
            Q30 = new List<Q30>();
        }

        public override string ToString()
        {
            return $"{Q20}" +
                $"{Formatting.RecordSet<Q30>(Q30, 999)}";
        }

    }

}
