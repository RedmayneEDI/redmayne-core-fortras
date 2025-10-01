using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmayneEDI.Formats.Fortras100.ENTL512.Models
{
    public class O00
    {
        private int max_length = 260;

        public string Preliminary_Consignment_No_Receiving_Depot { get; set; }
        public string Qualifier { get; set; }
        public string Name_1 { get; set; }
        public string Name_2 { get; set; }
        public string Street_And_Street_Number { get; set; }
        public string Country_Code { get; set; }
        public string Postcode { get; set; }
        public string Place { get; set; }
        public string Town_Area { get; set; }
        public string Consignor_ID { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(O00))) { line = Formatting.SafeSubstring(line,3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(O00)} length is invalid. Maximum length expected after {nameof(O00)} code is {max_length} but processed {line.Trim().Length}"); }
            Preliminary_Consignment_No_Receiving_Depot = Formatting.SafeSubstring(line, 0, 35);
            Qualifier = Formatting.SafeSubstring(line, 35, 3);
            Name_1 = Formatting.SafeSubstring(line, 38, 35);
            Name_2 = Formatting.SafeSubstring(line, 73, 35);
            Street_And_Street_Number = Formatting.SafeSubstring(line, 108, 35);
            Country_Code = Formatting.SafeSubstring(line, 143, 3);
            Postcode = Formatting.SafeSubstring(line, 146, 9);
            Place = Formatting.SafeSubstring(line, 155, 35);
            Town_Area = Formatting.SafeSubstring(line, 190, 35);
            Consignor_ID = Formatting.SafeSubstring(line, 225, 35);
        }

        public override string ToString()
        {
            var line = $"{nameof(O00)}{Formatting.SafeTruncate(Preliminary_Consignment_No_Receiving_Depot, 35)}" +
                $"{Formatting.SafeTruncate(Qualifier, 3)}" +
                $"{Formatting.SafeTruncate(Name_1, 35)}" +
                $"{Formatting.SafeTruncate(Name_2, 35)}" +
                $"{Formatting.SafeTruncate(Street_And_Street_Number, 35)}" +
                $"{Formatting.SafeTruncate(Country_Code, 3)}" +
                $"{Formatting.SafeTruncate(Postcode, 9)}" +
                $"{Formatting.SafeTruncate(Place, 35)}" +
                $"{Formatting.SafeTruncate(Town_Area, 35)}" +
                $"{Formatting.SafeTruncate(Consignor_ID, 35)}" +
                $"{Formatting.CRLF}";
            if (Formatting.TrimLines) { line = line.Trim() + $"{Formatting.CRLF}"; }
            return line;
        }
    }
}
