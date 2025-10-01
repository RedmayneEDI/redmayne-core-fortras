namespace RedmayneEDI.Formats.Fortras100.BORD512.Models
{
    public class E00
    {
        private int max_length = 422;

        public string Sequential_Waybill_Item { get; set; }
        public string Consignment_Position { get; set; }
        public string GG_Release { get; set; }
        public string Number_Of_Packages { get; set; }
        public string Gross_Weight_In_Grams { get; set; }
        public string UN_Number { get; set; }
        public string Packaging_Description { get; set; }
        public string Multiplier { get; set; }
        public string GG_Database_ID { get; set; }
        public string Unique_Key { get; set; }
        public string Material_Name { get; set; }
        public string Additional_Text_For_Nag { get; set; }
        public string Dangerous_Goods_Sample_Major { get; set; }
        public string Dangerous_Goods_Sample_1 { get; set; }
        public string Dangerous_Goods_Sample_2 { get; set; }
        public string Dangerous_Goods_Sample_3 { get; set; }
        public string PackingGroup_ClassificationCode { get; set; }
        public string Net_Explosive_Mass_In_Grams { get; set; }
        public string Transport_Class { get; set; }
        public string Limited_Amount { get; set; }
        public string Calculated_Dangerous_Goods_Points { get; set; }
        public string Tunnel_Limitation_Code { get; set; }
        public string Packaging_Group { get; set; }
        public string Classification_Code { get; set; }
        public string Exempt_Quantity { get; set; }
        public string Net_Weight_In_Grams { get; set; }
        public string Classification_Qualifiers { get; set; }
        public string Harmful_To_Environment { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(E00))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(E00)} length is invalid. Maximum length expected after {nameof(E00)} code is {max_length} but processed {line.Trim().Length}"); }
            Sequential_Waybill_Item = Formatting.SafeSubstring(line, 0, 3);
            Consignment_Position = Formatting.SafeSubstring(line, 3, 3);
            GG_Release = Formatting.SafeSubstring(line, 6, 3);
            Number_Of_Packages = Formatting.SafeSubstring(line, 9, 4);
            Gross_Weight_In_Grams = Formatting.SafeSubstring(line, 13, 9);
            UN_Number = Formatting.SafeSubstring(line, 22, 4);
            Packaging_Description = Formatting.SafeSubstring(line, 26, 35);
            Multiplier = Formatting.SafeSubstring(line, 61, 4);
            GG_Database_ID = Formatting.SafeSubstring(line, 65, 3);
            Unique_Key = Formatting.SafeSubstring(line, 68, 10);
            Material_Name = Formatting.SafeSubstring(line, 78, 210);
            Additional_Text_For_Nag = Formatting.SafeSubstring(line, 288, 70);
            Dangerous_Goods_Sample_Major = Formatting.SafeSubstring(line, 358, 3);
            Dangerous_Goods_Sample_1 = Formatting.SafeSubstring(line, 361, 3);
            Dangerous_Goods_Sample_2 = Formatting.SafeSubstring(line, 364, 3);
            Dangerous_Goods_Sample_3 = Formatting.SafeSubstring(line, 367, 3);
            PackingGroup_ClassificationCode = Formatting.SafeSubstring(line, 371, 4);
            Net_Explosive_Mass_In_Grams = Formatting.SafeSubstring(line, 375, 9);
            Transport_Class = Formatting.SafeSubstring(line, 384, 1);
            Limited_Amount = Formatting.SafeSubstring(line, 385, 1);
            Calculated_Dangerous_Goods_Points = Formatting.SafeSubstring(line, 386, 9);
            Tunnel_Limitation_Code = Formatting.SafeSubstring(line, 395, 6);
            Packaging_Group = Formatting.SafeSubstring(line, 401, 4);
            Classification_Code = Formatting.SafeSubstring(line, 405, 4);
            Exempt_Quantity = Formatting.SafeSubstring(line, 409, 1);
            Net_Weight_In_Grams = Formatting.SafeSubstring(line, 410, 9);
            Classification_Qualifiers = Formatting.SafeSubstring(line, 419, 3);
            Harmful_To_Environment = Formatting.SafeSubstring(line, 422, 1);
        }

        public override string ToString()
        {
            return $"{nameof(E00)}{Formatting.SafeTruncate(Sequential_Waybill_Item, 3, '0', true)}" +
                $"{Formatting.SafeTruncate(Consignment_Position, 3, '0', true)}" +
                $"{Formatting.SafeTruncate(GG_Release, 3)}" +
                $"{Formatting.SafeTruncate(Number_Of_Packages, 4)}" +
                $"{Formatting.SafeTruncate(Gross_Weight_In_Grams, 9)}" +
                $"{Formatting.SafeTruncate(UN_Number, 4)}" +
                $"{Formatting.SafeTruncate(Packaging_Description, 35)}" +
                $"{Formatting.SafeTruncate(Multiplier, 4)}" +
                $"{Formatting.SafeTruncate(GG_Database_ID, 3)}" +
                $"{Formatting.SafeTruncate(Unique_Key, 10)}" +
                $"{Formatting.SafeTruncate(Material_Name, 210)}" +
                $"{Formatting.SafeTruncate(Additional_Text_For_Nag, 70)}" +
                $"{Formatting.SafeTruncate(Dangerous_Goods_Sample_Major, 3)}" +
                $"{Formatting.SafeTruncate(Dangerous_Goods_Sample_1, 3)}" +
                $"{Formatting.SafeTruncate(Dangerous_Goods_Sample_2, 3)}" +
                $"{Formatting.SafeTruncate(Dangerous_Goods_Sample_3, 3)}" +
                $"{Formatting.SafeTruncate(PackingGroup_ClassificationCode, 4)}" +
                $"{Formatting.SafeTruncate(Net_Explosive_Mass_In_Grams, 9)}" +
                $"{Formatting.SafeTruncate(Transport_Class, 1)}" +
                $"{Formatting.SafeTruncate(Limited_Amount, 1)}" +
                $"{Formatting.SafeTruncate(Calculated_Dangerous_Goods_Points, 9)}" +
                $"{Formatting.SafeTruncate(Tunnel_Limitation_Code, 6)}" +
                $"{Formatting.SafeTruncate(Packaging_Group, 4)}" +
                $"{Formatting.SafeTruncate(Classification_Code, 4)}" +
                $"{Formatting.SafeTruncate(Exempt_Quantity, 1)}" +
                $"{Formatting.SafeTruncate(Net_Weight_In_Grams, 9)}" +
                $"{Formatting.SafeTruncate(Classification_Qualifiers, 3)}" +
                $"{Formatting.SafeTruncate(Harmful_To_Environment, 1)}" +
                $"{Formatting.CRLF}";
        }
    }
}
