using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmayneEDI.Formats.Fortras100.ENTL512.Models
{
    public class N00
    {
        private int max_length = 288;

        public string Waybill_Number_Sending_Depot { get; set; }
        public string Sequential_Waybill_Item { get; set; }
        public string Consignment_Number_Sending_Depot { get; set; }
        public string Consignment_Number_Receiving_Depot { get; set; }
        public string Status_Code_1 { get; set; }
        public string Discrepancy_Number_1 { get; set; }
        public string Packaging_Type_1 { get; set; }
        public string Text_Notes_1 { get; set; }
        public string Status_Code_2 { get; set; }
        public string Discrepancy_Number_2 { get; set; }
        public string Packaging_Type_2 { get; set; }
        public string Text_Notes_2 { get; set; }
        public string Status_Code_3 { get; set; }
        public string Discrepancy_Number_3 { get; set; }
        public string Packaging_Type_3 { get; set; }
        public string Text_Notes_3 { get; set; }
        public string Status_Code_4 { get; set; }
        public string Discrepancy_Number_4 { get; set; }
        public string Packaging_Type_4 { get; set; }
        public string Text_Notes_4 { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(N00))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(N00)} length is invalid. Maximum length expected after {nameof(N00)} code is {max_length} but processed {line.Trim().Length}"); }
            Waybill_Number_Sending_Depot = Formatting.SafeSubstring(line, 0, 35);
            Sequential_Waybill_Item = Formatting.SafeSubstring(line, 35, 3);
            Consignment_Number_Sending_Depot = Formatting.SafeSubstring(line, 38, 35);
            Consignment_Number_Receiving_Depot = Formatting.SafeSubstring(line, 73, 35);
            Status_Code_1 = Formatting.SafeSubstring(line, 108, 3);
            Discrepancy_Number_1 = Formatting.SafeSubstring(line, 111, 4);
            Packaging_Type_1 = Formatting.SafeSubstring(line, 115, 3);
            Text_Notes_1 = Formatting.SafeSubstring(line, 118, 35);
            Status_Code_2 = Formatting.SafeSubstring(line, 153, 3);
            Discrepancy_Number_2 = Formatting.SafeSubstring(line, 156, 4);
            Packaging_Type_2 = Formatting.SafeSubstring(line, 160, 3);
            Text_Notes_2 = Formatting.SafeSubstring(line, 163, 35);
            Status_Code_3 = Formatting.SafeSubstring(line, 198, 3);
            Discrepancy_Number_3 = Formatting.SafeSubstring(line, 201, 4);
            Packaging_Type_3 = Formatting.SafeSubstring(line, 205, 3);
            Text_Notes_3 = Formatting.SafeSubstring(line, 208, 35);
            Status_Code_4 = Formatting.SafeSubstring(line, 243, 3);
            Discrepancy_Number_4 = Formatting.SafeSubstring(line, 246, 4);
            Packaging_Type_4 = Formatting.SafeSubstring(line, 250, 3);
            Text_Notes_4 = Formatting.SafeSubstring(line, 253, 35);
        }

        public override string ToString()
        {
            var line = $"{nameof(N00)}{Formatting.SafeTruncate(Waybill_Number_Sending_Depot, 35)}" +
                $"{Formatting.SafeTruncate(Sequential_Waybill_Item, 3)}" +
                $"{Formatting.SafeTruncate(Consignment_Number_Sending_Depot, 35)}" +
                $"{Formatting.SafeTruncate(Consignment_Number_Receiving_Depot, 35)}" +
                $"{Formatting.SafeTruncate(Status_Code_1, 3)}" +
                $"{Formatting.SafeTruncate(Discrepancy_Number_1, 4)}" +
                $"{Formatting.SafeTruncate(Packaging_Type_1, 3)}" +
                $"{Formatting.SafeTruncate(Text_Notes_1, 35)}" +
                $"{Formatting.SafeTruncate(Status_Code_2, 3)}" +
                $"{Formatting.SafeTruncate(Discrepancy_Number_2, 4)}" +
                $"{Formatting.SafeTruncate(Packaging_Type_2, 3)}" +
                $"{Formatting.SafeTruncate(Text_Notes_2, 35)}" +
                $"{Formatting.SafeTruncate(Status_Code_3, 3)}" +
                $"{Formatting.SafeTruncate(Discrepancy_Number_3, 4)}" +
                $"{Formatting.SafeTruncate(Packaging_Type_3, 3)}" +
                $"{Formatting.SafeTruncate(Text_Notes_3, 35)}" +
                $"{Formatting.SafeTruncate(Status_Code_4, 3)}" +
                $"{Formatting.SafeTruncate(Discrepancy_Number_4, 4)}" +
                $"{Formatting.SafeTruncate(Packaging_Type_4, 3)}" +
                $"{Formatting.SafeTruncate(Text_Notes_4, 35)}" +
                $"{Formatting.CRLF}";
            if (Formatting.TrimLines) { line = line.Trim() + $"{Formatting.CRLF}"; }
            return line;
        }
    }
}
