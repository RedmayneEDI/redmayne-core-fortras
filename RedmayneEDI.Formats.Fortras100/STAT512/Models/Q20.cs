using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmayneEDI.Formats.Fortras100.STAT512.Models
{
    public class Q20
    {
        private int max_length = 125;

        public string Shipment_No { get; set; }
        public string Measuring_Point_Qualifier { get; set; }
        public string Barcode { get; set; }
        public string Scan_Date { get; set; }
        public string Scan_Time { get; set; }
        public string Scan_Code { get; set; }
        public string Additional_Text { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(Q20))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(Q20)} length is invalid. Maximum length expected after {nameof(Q20)} code is {max_length} but processed {line.Trim().Length}"); }
            Shipment_No = Formatting.SafeSubstring(line, 0, 35);
            Measuring_Point_Qualifier = Formatting.SafeSubstring(line, 35, 3);
            Barcode = Formatting.SafeSubstring(line, 38, 35);
            Scan_Date = Formatting.SafeSubstring(line, 73, 8);
            Scan_Time = Formatting.SafeSubstring(line, 81, 6);
            Scan_Code = Formatting.SafeSubstring(line, 87, 3);
            Additional_Text = Formatting.SafeSubstring(line, 90, 35);
        }

        public override string ToString()
        {
            var line = $"{nameof(Q20)}{Formatting.SafeTruncate(Shipment_No, 35)}" +
                $"{Formatting.SafeTruncate(Measuring_Point_Qualifier, 3)}" +
                $"{Formatting.SafeTruncate(Barcode, 35)}" +
                $"{Formatting.SafeTruncate(Scan_Date, 8)}" +
                $"{Formatting.SafeTruncate(Scan_Time, 6)}" +
                $"{Formatting.SafeTruncate(Scan_Code, 3)}" +
                $"{Formatting.SafeTruncate(Additional_Text, 35)}" +
                $"{Formatting.CRLF}";
            if (Formatting.TrimLines) { line = line.Trim() + $"{Formatting.CRLF}"; }
            return line;
        }
    }
}
