using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmayneEDI.Formats.Fortras100.ENTL512.Models
{
    public class M20
    {
        private int max_length = 152;

        public string Lead_Seal_Number_1 { get; set; }
        public string Condition_Lead_Seal_Number_1 { get; set; }
        public string Lead_Seal_Number_2 { get; set; }
        public string Condition_Lead_Seal_Number_2 { get; set; }
        public string Lead_Seal_Number_3 { get; set; }
        public string Condition_Lead_Seal_Number_3 { get; set; }
        public string Lead_Seal_Number_4 { get; set; }
        public string Condition_Lead_Seal_Number_4 { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(M20))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(M20)} length is invalid. Maximum length expected after {nameof(M20)} code is {max_length} but processed {line.Trim().Length}"); }
            Lead_Seal_Number_1 = Formatting.SafeSubstring(line, 0, 35);
            Condition_Lead_Seal_Number_1 = Formatting.SafeSubstring(line, 35, 3);
            Lead_Seal_Number_2 = Formatting.SafeSubstring(line, 38, 35);
            Condition_Lead_Seal_Number_2 = Formatting.SafeSubstring(line, 73, 3);
            Lead_Seal_Number_3 = Formatting.SafeSubstring(line, 76, 35);
            Condition_Lead_Seal_Number_3 = Formatting.SafeSubstring(line, 111, 3);
            Lead_Seal_Number_4 = Formatting.SafeSubstring(line, 114, 35);
            Condition_Lead_Seal_Number_4 = Formatting.SafeSubstring(line, 149, 3);
        }

        public override string ToString()
        {
            var line = $"{nameof(M20)}{Formatting.SafeTruncate(Lead_Seal_Number_1, 35)}" +
                $"{Formatting.SafeTruncate(Condition_Lead_Seal_Number_1, 3)}" +
                $"{Formatting.SafeTruncate(Lead_Seal_Number_2, 35)}" +
                $"{Formatting.SafeTruncate(Condition_Lead_Seal_Number_2, 3)}" +
                $"{Formatting.SafeTruncate(Lead_Seal_Number_3, 35)}" +
                $"{Formatting.SafeTruncate(Condition_Lead_Seal_Number_3, 3)}" +
                $"{Formatting.SafeTruncate(Lead_Seal_Number_4, 35)}" +
                $"{Formatting.SafeTruncate(Condition_Lead_Seal_Number_4, 3)}" +
                $"{Formatting.CRLF}";
            if (Formatting.TrimLines) { line = line.Trim() + $"{Formatting.CRLF}"; }
            return line;
        }
    }
}
