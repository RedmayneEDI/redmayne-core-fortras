using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmayneEDI.Formats.Fortras100.ENTL512.Models
{
    public class O20
    {
        private int max_length = 181;

        public string Preliminary_Consignment_No_Receiving_Depot { get; set; }
        public string Barcode_1 { get; set; }
        public string Error_Message_Code_1 { get; set; }
        public string Additional_Text_1 { get; set; }
        public string Barcode_2 { get; set; }
        public string Error_Message_Code_2 { get; set; }
        public string Additional_Text_2 { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(O20))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(O20)} length is invalid. Maximum length expected after {nameof(O20)} code is {max_length} but processed {line.Trim().Length}"); }
            Preliminary_Consignment_No_Receiving_Depot = Formatting.SafeSubstring(line,0, 35);
            Barcode_1 = Formatting.SafeSubstring(line,35, 35);
            Error_Message_Code_1 = Formatting.SafeSubstring(line,70, 3);
            Additional_Text_1 = Formatting.SafeSubstring(line,73, 35);
            Barcode_2 = Formatting.SafeSubstring(line,108, 35);
            Error_Message_Code_2 = Formatting.SafeSubstring(line,111, 3);
            Additional_Text_2 = Formatting.SafeSubstring(line,114, 35);
        }

        public override string ToString()
        {
            var line = $"{nameof(O20)}{Formatting.SafeTruncate(Preliminary_Consignment_No_Receiving_Depot, 35)}" +
                $"{Formatting.SafeTruncate(Barcode_1, 35)}" +
                $"{Formatting.SafeTruncate(Error_Message_Code_1, 3)}" +
                $"{Formatting.SafeTruncate(Additional_Text_1, 35)}" +
                $"{Formatting.SafeTruncate(Barcode_2, 35)}" +
                $"{Formatting.SafeTruncate(Error_Message_Code_2, 3)}" +
                $"{Formatting.SafeTruncate(Additional_Text_2, 35)}" +
                $"{Formatting.CRLF}";
            if (Formatting.TrimLines) { line = line.Trim() + $"{Formatting.CRLF}"; }
            return line;
        }
    }
}
