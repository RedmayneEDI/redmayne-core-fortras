using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmayneEDI.Formats.Fortras100.ENTL512.Models
{
    public class M10
    {
        private int max_length = 233;

        public string Loading_Unit_Number { get; set; }
        public string Condition_Of_Loading_Unit_1 { get; set; }
        public string Additional_Text_1 { get; set; }
        public string Condition_Of_Loading_Unit_2 { get; set; }
        public string Additional_Text_2 { get; set; }
        public string Condition_Of_Loading_Unit_3 { get; set; }
        public string Additional_Text_3 { get; set; }
        public string Condition_Of_Loading_Unit_4 { get; set; }
        public string Additional_Text_4 { get; set; }
        public string Condition_Of_Loading_Unit_5 { get; set; }
        public string Additional_Text_5 { get; set; }
        public string Condition_Of_Loading_Unit_6 { get; set; }
        public string Additional_Text_6 { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(M10))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(M10)} length is invalid. Maximum length expected after {nameof(M10)} code is {max_length} but processed {line.Trim().Length}"); }
            Loading_Unit_Number = Formatting.SafeSubstring(line, 0, 35);
            Condition_Of_Loading_Unit_1 = Formatting.SafeSubstring(line, 35, 3);
            Additional_Text_1 = Formatting.SafeSubstring(line, 38, 30);
            Condition_Of_Loading_Unit_2 = Formatting.SafeSubstring(line, 68, 3);
            Additional_Text_2 = Formatting.SafeSubstring(line, 71, 30);
            Condition_Of_Loading_Unit_3 = Formatting.SafeSubstring(line, 101, 3);
            Additional_Text_3 = Formatting.SafeSubstring(line, 104, 30);
            Condition_Of_Loading_Unit_4 = Formatting.SafeSubstring(line, 134, 3);
            Additional_Text_4 = Formatting.SafeSubstring(line, 137, 30);
            Condition_Of_Loading_Unit_5 = Formatting.SafeSubstring(line, 167, 3);
            Additional_Text_5 = Formatting.SafeSubstring(line, 170, 30);
            Condition_Of_Loading_Unit_6 = Formatting.SafeSubstring(line, 200, 3);
            Additional_Text_6 = Formatting.SafeSubstring(line, 203, 30);
        }

        public override string ToString()
        {
            var line = $"{nameof(M10)}{Formatting.SafeTruncate(Loading_Unit_Number, 35)}" +
                $"{Formatting.SafeTruncate(Condition_Of_Loading_Unit_1, 3)}" +
                $"{Formatting.SafeTruncate(Additional_Text_1, 30)}" +
                $"{Formatting.SafeTruncate(Condition_Of_Loading_Unit_2, 3)}" +
                $"{Formatting.SafeTruncate(Additional_Text_2, 30)}" +
                $"{Formatting.SafeTruncate(Condition_Of_Loading_Unit_3, 3)}" +
                $"{Formatting.SafeTruncate(Additional_Text_3, 30)}" +
                $"{Formatting.SafeTruncate(Condition_Of_Loading_Unit_4, 3)}" +
                $"{Formatting.SafeTruncate(Additional_Text_4, 30)}" +
                $"{Formatting.SafeTruncate(Condition_Of_Loading_Unit_5, 3)}" +
                $"{Formatting.SafeTruncate(Additional_Text_5, 30)}" +
                $"{Formatting.SafeTruncate(Condition_Of_Loading_Unit_6, 3)}" +
                $"{Formatting.SafeTruncate(Additional_Text_6, 30)}" +
                $"{Formatting.CRLF}";
            if (Formatting.TrimLines) { line = line.Trim() + $"{Formatting.CRLF}"; }
            return line;
        }
    }
}
