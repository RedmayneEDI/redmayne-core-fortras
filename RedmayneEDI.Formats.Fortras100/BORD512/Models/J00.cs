using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmayneEDI.Formats.Fortras100.BORD512.Models
{
    public class J00
    {
        private int max_length = 100;

        public string Total_Number_Of_Consignments { get; set; }
        public string Total_Number_Of_Packages { get; set; }
        public string Actual_Gross_Weight_In_KG { get; set; }
        public string Number_Of_Box_Pallets { get; set; }
        public string Number_Of_Euro_Flat_Pallets { get; set; }
        public string Number_Of_Additional_Loading_Tools_Flat_Pallets { get; set; }
        public string Number_Of_Additional_Loading_Tools_Box_Pallets { get; set; }
        public string Totals_Taxable_From_I00 { get; set; }
        public string Totals_Not_Taxable_From_I00 { get; set; }
        public string Totals_Of_Product_Value_COD_From_I00 { get; set; }
        public string Totals_Of_Customs_From_I00 { get; set; }
        public string Totals_Of_Imports_Turnover_Tax_From_I00 { get; set; }
        public string Totals_Of_Value_Added_Tax_From_I00 { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(J00))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(J00)} length is invalid. Maximum length expected after {nameof(J00)} code is {max_length} but processed {line.Trim().Length}"); }
            Total_Number_Of_Consignments = Formatting.SafeSubstring(line, 0, 3);
            Total_Number_Of_Packages = Formatting.SafeSubstring(line, 3, 6);
            Actual_Gross_Weight_In_KG = Formatting.SafeSubstring(line, 9, 9);
            Number_Of_Box_Pallets = Formatting.SafeSubstring(line, 18, 4);
            Number_Of_Euro_Flat_Pallets = Formatting.SafeSubstring(line, 22, 4);
            Number_Of_Additional_Loading_Tools_Flat_Pallets = Formatting.SafeSubstring(line, 26, 4);
            Number_Of_Additional_Loading_Tools_Box_Pallets = Formatting.SafeSubstring(line, 30, 4);
            Totals_Taxable_From_I00 = Formatting.SafeSubstring(line, 34, 11);
            Totals_Not_Taxable_From_I00 = Formatting.SafeSubstring(line, 45, 11);
            Totals_Of_Product_Value_COD_From_I00 = Formatting.SafeSubstring(line, 56, 11);
            Totals_Of_Customs_From_I00 = Formatting.SafeSubstring(line, 67, 11);
            Totals_Of_Imports_Turnover_Tax_From_I00 = Formatting.SafeSubstring(line, 78, 11);
            Totals_Of_Value_Added_Tax_From_I00 = Formatting.SafeSubstring(line, 89, 11);
        }

        public override string ToString()
        {
            var line = $"{nameof(J00)}{Formatting.SafeTruncate(Total_Number_Of_Consignments, 3, '0', true)}" +
                $"{Formatting.SafeTruncate(Total_Number_Of_Packages, 6, '0', true)}" +
                $"{Formatting.SafeTruncate(Actual_Gross_Weight_In_KG, 9, '0', true)}" +
                $"{Formatting.SafeTruncate(Number_Of_Box_Pallets, 4, '0', true)}" +
                $"{Formatting.SafeTruncate(Number_Of_Euro_Flat_Pallets, 4, '0', true)}" +
                $"{Formatting.SafeTruncate(Number_Of_Additional_Loading_Tools_Flat_Pallets, 4, '0', true)}" +
                $"{Formatting.SafeTruncate(Number_Of_Additional_Loading_Tools_Box_Pallets, 4, '0', true)}" +
                $"{Formatting.SafeTruncate(Totals_Taxable_From_I00, 11)}" +
                $"{Formatting.SafeTruncate(Totals_Not_Taxable_From_I00, 11)}" +
                $"{Formatting.SafeTruncate(Totals_Of_Product_Value_COD_From_I00, 11)}" +
                $"{Formatting.SafeTruncate(Totals_Of_Customs_From_I00, 11)}" +
                $"{Formatting.SafeTruncate(Totals_Of_Imports_Turnover_Tax_From_I00, 11)}" +
                $"{Formatting.SafeTruncate(Totals_Of_Value_Added_Tax_From_I00, 11)}" +
                $"{Formatting.CRLF}";
            if (Formatting.TrimLines) { line = line.Trim() + $"{Formatting.CRLF}"; }
            return line;
        }
    }
}
