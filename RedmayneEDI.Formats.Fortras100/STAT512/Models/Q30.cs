using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmayneEDI.Formats.Fortras100.STAT512.Models
{
    public class Q30
    {
        private int max_length = 190;

        public string Qualifier_Reference_1 { get; set; }
        public string Reference_Date_1 { get; set; }
        public string Qualifier_Reference_2 { get; set; }
        public string Reference_Date_2 { get; set; }
        public string Qualifier_Reference_3 { get; set; }
        public string Reference_Date_3 { get; set; }
        public string Qualifier_Reference_4 { get; set; }
        public string Reference_Date_4 { get; set; }
        public string Qualifier_Reference_5 { get; set; }
        public string Reference_Date_5 { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(Q30))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(Q30)} length is invalid. Maximum length expected after {nameof(Q30)} code is {max_length} but processed {line.Trim().Length}"); }
            Qualifier_Reference_1 = Formatting.SafeSubstring(line, 0, 3);
            Reference_Date_1 = Formatting.SafeSubstring(line, 3, 35);
            Qualifier_Reference_2 = Formatting.SafeSubstring(line, 38, 3);
            Reference_Date_2 = Formatting.SafeSubstring(line, 41, 35);
            Qualifier_Reference_3 = Formatting.SafeSubstring(line, 76, 3);
            Reference_Date_3 = Formatting.SafeSubstring(line, 79, 35);
            Qualifier_Reference_4 = Formatting.SafeSubstring(line, 114, 3);
            Reference_Date_4 = Formatting.SafeSubstring(line, 117, 35);
            Qualifier_Reference_5 = Formatting.SafeSubstring(line, 152, 3);
            Reference_Date_5 = Formatting.SafeSubstring(line, 155, 35);
        }

        public override string ToString()
        {
            var line = $"{nameof(Q30)}{Formatting.SafeTruncate(Qualifier_Reference_1, 3)}" +
                $"{Formatting.SafeTruncate(Reference_Date_1, 35)}" +
                $"{Formatting.SafeTruncate(Qualifier_Reference_2, 3)}" +
                $"{Formatting.SafeTruncate(Reference_Date_2, 35)}" +
                $"{Formatting.SafeTruncate(Qualifier_Reference_3, 3)}" +
                $"{Formatting.SafeTruncate(Reference_Date_3, 35)}" +
                $"{Formatting.SafeTruncate(Qualifier_Reference_4, 3)}" +
                $"{Formatting.SafeTruncate(Reference_Date_4, 35)}" +
                $"{Formatting.SafeTruncate(Qualifier_Reference_5, 3)}" +
                $"{Formatting.SafeTruncate(Reference_Date_5, 35)}" +
                $"{Formatting.CRLF}";
            if (Formatting.TrimLines) { line = line.Trim() + $"{Formatting.CRLF}"; }
            return line;
        }
    }
}
