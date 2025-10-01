using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmayneEDI.Formats.Fortras100.ENTL512.Models
{
    public class O10
    {
        private int max_length = 195;

        public string Preliminary_Consignment_No_Receiving_Depot { get; set; }
        public string Code_and_Number_1 { get; set; }
        public string Number_1 { get; set; }
        public string Packaging_Type_1 { get; set; }
        public string Error_Message_Code_1 { get; set; }
        public string Additional_Text_1 { get; set; }
        public string Code_and_Number_2 { get; set; }
        public string Number_2 { get; set; }
        public string Packaging_Type_2 { get; set; }
        public string Error_Message_Code_2 { get; set; }
        public string Additional_Text_2 { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(O10))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(O10)} length is invalid. Maximum length expected after {nameof(O10)} code is {max_length} but processed {line.Trim().Length}"); }
            Preliminary_Consignment_No_Receiving_Depot = Formatting.SafeSubstring(line,0, 35);
            Code_and_Number_1 = Formatting.SafeSubstring(line,35, 35);
            Number_1 = Formatting.SafeSubstring(line,70, 4);
            Packaging_Type_1 = Formatting.SafeSubstring(line,74, 3);
            Error_Message_Code_1 = Formatting.SafeSubstring(line,77, 3);
            Additional_Text_1 = Formatting.SafeSubstring(line,80, 35);
            Code_and_Number_2 = Formatting.SafeSubstring(line,125, 35);
            Number_2 = Formatting.SafeSubstring(line,160, 4);
            Packaging_Type_2 = Formatting.SafeSubstring(line,164, 3);
            Error_Message_Code_2 = Formatting.SafeSubstring(line,167, 3);
            Additional_Text_2 = Formatting.SafeSubstring(line,170, 35);
        }

        public override string ToString()
        {
             var line = $"{nameof(O10)}{Formatting.SafeTruncate(Preliminary_Consignment_No_Receiving_Depot, 35)}" +
                $"{Formatting.SafeTruncate(Code_and_Number_1, 35)}" +
                $"{Formatting.SafeTruncate(Number_1, 4)}" +
                $"{Formatting.SafeTruncate(Packaging_Type_1, 3)}" +
                $"{Formatting.SafeTruncate(Error_Message_Code_1, 3)}" +
                $"{Formatting.SafeTruncate(Additional_Text_1, 35)}" +
                $"{Formatting.SafeTruncate(Code_and_Number_2, 35)}" +
                $"{Formatting.SafeTruncate(Number_2, 4)}" +
                $"{Formatting.SafeTruncate(Packaging_Type_2, 3)}" +
                $"{Formatting.SafeTruncate(Error_Message_Code_2, 3)}" +
                $"{Formatting.SafeTruncate(Additional_Text_2, 35)}" +
                $"{Formatting.CRLF}";
            if (Formatting.TrimLines) { line = line.Trim() + $"{Formatting.CRLF}"; }
            return line;
        }
    }
}
