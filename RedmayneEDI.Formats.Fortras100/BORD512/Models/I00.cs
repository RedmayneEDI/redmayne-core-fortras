using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmayneEDI.Formats.Fortras100.BORD512.Models
{
    /// <summary>
    /// Invoicing-related information for the Consignment.
    /// </summary>
    public class I00
    {
        private int max_length = 133;

        public string Sequential_Waybill_Item { get; set; }
        public string Service_Type_1 { get; set; }
        public string Tax_Code_1 { get; set; }
        public string Amount_1 { get; set; }
        public string Service_Type_2 { get; set; }
        public string Tax_Code_2 { get; set; }
        public string Amount_2 { get; set; }
        public string Service_Type_3 { get; set; }
        public string Tax_Code_3 { get; set; }
        public string Amount_3 { get; set; }
        public string Service_Type_4 { get; set; }
        public string Tax_Code_4 { get; set; }
        public string Amount_4 { get; set; }
        public string Service_Type_5 { get; set; }
        public string Tax_Code_5 { get; set; }
        public string Amount_5 { get; set; }
        public string Service_Type_6 { get; set; }
        public string Tax_Code_6 { get; set; }
        public string Amount_6 { get; set; }
        public string Service_Type_7 { get; set; }
        public string Tax_Code_7 { get; set; }
        public string Amount_7 { get; set; }
        public string Service_Type_8 { get; set; }
        public string Tax_Code_8 { get; set; }
        public string Amount_8 { get; set; }
        public string Service_Type_9 { get; set; }
        public string Tax_Code_9 { get; set; }
        public string Amount_9 { get; set; }
        public string Service_Type_10 { get; set; }
        public string Tax_Code_10 { get; set; }
        public string Amount_10 { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(I00))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(I00)} length is invalid. Maximum length expected after {nameof(I00)} code is {max_length} but processed {line.Trim().Length}"); }
            Sequential_Waybill_Item = Formatting.SafeSubstring(line, 0, 3);
            Service_Type_1 = Formatting.SafeSubstring(line, 3, 3);
            Tax_Code_1 = Formatting.SafeSubstring(line, 6, 1);
            Amount_1 = Formatting.SafeSubstring(line, 7, 9);
            Service_Type_2 = Formatting.SafeSubstring(line, 16, 3);
            Tax_Code_2 = Formatting.SafeSubstring(line, 19, 1);
            Amount_2 = Formatting.SafeSubstring(line, 20, 9);
            Service_Type_3 = Formatting.SafeSubstring(line, 29, 3);
            Tax_Code_3 = Formatting.SafeSubstring(line, 32, 1);
            Amount_3 = Formatting.SafeSubstring(line, 33, 9);
            Service_Type_4 = Formatting.SafeSubstring(line, 40, 3);
            Tax_Code_4 = Formatting.SafeSubstring(line, 43, 1);
            Amount_4 = Formatting.SafeSubstring(line, 44, 9);
            Service_Type_5 = Formatting.SafeSubstring(line, 53, 3);
            Tax_Code_5 = Formatting.SafeSubstring(line, 56, 1);
            Amount_5 = Formatting.SafeSubstring(line, 57, 9);
            Service_Type_6 = Formatting.SafeSubstring(line, 66, 3);
            Tax_Code_6 = Formatting.SafeSubstring(line, 69, 1);
            Amount_6 = Formatting.SafeSubstring(line, 70, 9);
            Service_Type_7 = Formatting.SafeSubstring(line, 79, 3);
            Tax_Code_7 = Formatting.SafeSubstring(line, 82, 1);
            Amount_7 = Formatting.SafeSubstring(line, 83, 9);
            Service_Type_8 = Formatting.SafeSubstring(line, 90, 3);
            Tax_Code_8 = Formatting.SafeSubstring(line, 93, 1);
            Amount_8 = Formatting.SafeSubstring(line, 94, 9);
            Service_Type_9 = Formatting.SafeSubstring(line, 103, 3);
            Tax_Code_9 = Formatting.SafeSubstring(line, 106, 1);
            Amount_9 = Formatting.SafeSubstring(line, 107, 9);
            Service_Type_10 = Formatting.SafeSubstring(line, 116, 3);
            Tax_Code_10 = Formatting.SafeSubstring(line, 119, 1);
            Amount_10 = Formatting.SafeSubstring(line, 120, 9);
        }

        public override string ToString()
        {
            var line = $"{nameof(I00)}{Formatting.SafeTruncate(Sequential_Waybill_Item, 3, '0', true)}" +
                $"{Formatting.SafeTruncate(Service_Type_1, 3)}" +
                $"{Formatting.SafeTruncate(Tax_Code_1, 1)}" +
                $"{Formatting.SafeTruncate(Amount_1, 9)}" +
                $"{Formatting.SafeTruncate(Service_Type_2, 3)}" +
                $"{Formatting.SafeTruncate(Tax_Code_2, 1)}" +
                $"{Formatting.SafeTruncate(Amount_2, 9)}" +
                $"{Formatting.SafeTruncate(Service_Type_3, 3)}" +
                $"{Formatting.SafeTruncate(Tax_Code_3, 1)}" +
                $"{Formatting.SafeTruncate(Amount_3, 9)}" +
                $"{Formatting.SafeTruncate(Service_Type_4, 3)}" +
                $"{Formatting.SafeTruncate(Tax_Code_4, 1)}" +
                $"{Formatting.SafeTruncate(Amount_4, 9)}" +
                $"{Formatting.SafeTruncate(Service_Type_5, 3)}" +
                $"{Formatting.SafeTruncate(Tax_Code_5, 1)}" +
                $"{Formatting.SafeTruncate(Amount_5, 9)}" +
                $"{Formatting.SafeTruncate(Service_Type_6, 3)}" +
                $"{Formatting.SafeTruncate(Tax_Code_6, 1)}" +
                $"{Formatting.SafeTruncate(Amount_6, 9)}" +
                $"{Formatting.SafeTruncate(Service_Type_7, 3)}" +
                $"{Formatting.SafeTruncate(Tax_Code_7, 1)}" +
                $"{Formatting.SafeTruncate(Amount_7, 9)}" +
                $"{Formatting.SafeTruncate(Service_Type_8, 3)}" +
                $"{Formatting.SafeTruncate(Tax_Code_8, 1)}" +
                $"{Formatting.SafeTruncate(Amount_8, 9)}" +
                $"{Formatting.SafeTruncate(Service_Type_9, 3)}" +
                $"{Formatting.SafeTruncate(Tax_Code_9, 1)}" +
                $"{Formatting.SafeTruncate(Amount_9, 9)}" +
                $"{Formatting.SafeTruncate(Service_Type_10, 3)}" +
                $"{Formatting.SafeTruncate(Tax_Code_10, 1)}" +
                $"{Formatting.SafeTruncate(Amount_10, 9)}" +
                $"{Formatting.CRLF}";
            if (Formatting.TrimLines) { line = line.Trim() + $"{Formatting.CRLF}"; }
            return line;
        }
    }
}
