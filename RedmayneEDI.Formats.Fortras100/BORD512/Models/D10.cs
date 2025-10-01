namespace RedmayneEDI.Formats.Fortras100.BORD512.Models
{
    public class D10
    {
        private int max_length = 208;
        public string Sequential_Waybill_Item { get; set; }
        public string Consignment_Position { get; set; }
        public string Product_Number { get; set; }
        public string Country_Of_Origin { get; set; }
        public string Raw_Mass_In_Grams { get; set; }
        public string Fixed_Load_In_Grams { get; set; }
        public string Procedure_Code { get; set; }
        public string Customs_Value { get; set; }
        public string Customs_Value_Currency { get; set; }
        public string Statistical_Value { get; set; }
        public string Statistical_Value_Currency { get; set; }
        public string Appendix_Type_1 { get; set; }
        public string Appendix_Number_1 { get; set; }
        public string Appendix_Date_1 { get; set; }
        public string Appendix_Type_2 { get; set; }
        public string Appendix_Number_2 { get; set; }
        public string Appendix_Date_2 { get; set; }
        public string Appendix_Type_3 { get; set; }
        public string Appendix_Number_3 { get; set; }
        public string Appendix_Date_3 { get; set; }
        public string Appendix_Type_4 { get; set; }
        public string Appendix_Number_4 { get; set; }
        public string Appendix_Date_4 { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(D10))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(D10)} length is invalid. Maximum length expected after {nameof(D10)} code is {max_length} but processed {line.Trim().Length}"); }
            Sequential_Waybill_Item = Formatting.SafeSubstring(line, 0, 3);
            Consignment_Position = Formatting.SafeSubstring(line, 3, 3);
            Product_Number = Formatting.SafeSubstring(line, 6, 15);
            Country_Of_Origin = Formatting.SafeSubstring(line, 21, 3);
            Raw_Mass_In_Grams = Formatting.SafeSubstring(line, 24, 9);
            Fixed_Load_In_Grams = Formatting.SafeSubstring(line, 33, 9);
            Procedure_Code = Formatting.SafeSubstring(line, 42, 5);
            Customs_Value = Formatting.SafeSubstring(line, 47, 11);
            Customs_Value_Currency = Formatting.SafeSubstring(line, 58, 3);
            Statistical_Value = Formatting.SafeSubstring(line, 62, 11);
            Statistical_Value_Currency = Formatting.SafeSubstring(line, 73, 3);
            Appendix_Type_1 = Formatting.SafeSubstring(line, 76, 6);
            Appendix_Number_1 = Formatting.SafeSubstring(line, 82, 20);
            Appendix_Date_1 = Formatting.SafeSubstring(line, 102, 8);
            Appendix_Type_2 = Formatting.SafeSubstring(line, 110, 6);
            Appendix_Number_2 = Formatting.SafeSubstring(line, 116, 20);
            Appendix_Date_2 = Formatting.SafeSubstring(line, 136, 8);
            Appendix_Type_3 = Formatting.SafeSubstring(line, 144, 6);
            Appendix_Number_3 = Formatting.SafeSubstring(line, 150, 20);
            Appendix_Date_3 = Formatting.SafeSubstring(line, 170, 8);
            Appendix_Type_4 = Formatting.SafeSubstring(line, 178, 6);
            Appendix_Number_4 = Formatting.SafeSubstring(line, 184, 20);
            Appendix_Date_4 = Formatting.SafeSubstring(line, 204, 8);
        }

        public override string ToString()
        {
            return $"{nameof(D10)}{Formatting.SafeTruncate(Sequential_Waybill_Item, 3, '0', true)}" +
                $"{Formatting.SafeTruncate(Consignment_Position, 3, '0', true)}" +
                $"{Formatting.SafeTruncate(Product_Number, 15)}" +
                $"{Formatting.SafeTruncate(Country_Of_Origin, 3)}" +
                $"{Formatting.SafeTruncate(Raw_Mass_In_Grams, 9)}" +
                $"{Formatting.SafeTruncate(Fixed_Load_In_Grams, 9)}" +
                $"{Formatting.SafeTruncate(Procedure_Code, 5)}" +
                $"{Formatting.SafeTruncate(Customs_Value, 11)}" +
                $"{Formatting.SafeTruncate(Customs_Value_Currency, 3)}" +
                $"{Formatting.SafeTruncate(Statistical_Value, 11)}" +
                $"{Formatting.SafeTruncate(Statistical_Value_Currency, 3)}" +
                $"{Formatting.SafeTruncate(Appendix_Type_1, 6)}" +
                $"{Formatting.SafeTruncate(Appendix_Number_1, 20)}" +
                $"{Formatting.SafeTruncate(Appendix_Date_1, 8)}" +
                $"{Formatting.SafeTruncate(Appendix_Type_2, 6)}" +
                $"{Formatting.SafeTruncate(Appendix_Number_2, 20)}" +
                $"{Formatting.SafeTruncate(Appendix_Date_2, 8)}" +
                $"{Formatting.SafeTruncate(Appendix_Type_3, 6)}" +
                $"{Formatting.SafeTruncate(Appendix_Number_3, 20)}" +
                $"{Formatting.SafeTruncate(Appendix_Date_3, 8)}" +
                $"{Formatting.SafeTruncate(Appendix_Type_4, 6)}" +
                $"{Formatting.SafeTruncate(Appendix_Number_4, 20)}" +
                $"{Formatting.SafeTruncate(Appendix_Date_4, 8)}" +
                $"{Formatting.CRLF}";
        }
    }
}
