namespace RedmayneEDI.Formats.Fortras100.BORD512.Models
{
    /// <summary>
    /// Representation of an address for a Consignment.
    /// </summary>
    public class B00
    {
        private int max_length = 333;

        public string Sequential_Waybill_Item { get; set; }
        public string Address_Type_Qualifier { get; set; }
        public string Name_1 { get; set; }
        public string Stree_Name_And_Number { get; set; }
        public string Country_Code { get; set; }
        public string Postcode { get; set; }
        public string Place { get; set; }
        public string Partner_ID { get; set; }
        public string Name_2 { get; set; }
        public string Name_3 { get; set; }
        public string Town_Area { get; set; }
        public string Global_Localization_Number { get; set; }
        public string Customs_ID { get; set; }


        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(B00))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(B00)} length is invalid. Maximum length expected after {nameof(B00)} code is {max_length} but processed {line.Trim().Length}"); }
            Sequential_Waybill_Item = Formatting.SafeSubstring(line, 0, 3);
            Address_Type_Qualifier = Formatting.SafeSubstring(line, 3, 3);
            Name_1 = Formatting.SafeSubstring(line, 6, 35);
            Stree_Name_And_Number = Formatting.SafeSubstring(line, 41, 35);
            Country_Code = Formatting.SafeSubstring(line, 76, 3);
            Postcode = Formatting.SafeSubstring(line, 79, 9);
            Place = Formatting.SafeSubstring(line, 88, 35);
            Partner_ID = Formatting.SafeSubstring(line, 123, 35);
            Name_2 = Formatting.SafeSubstring(line, 158, 35);
            Name_3 = Formatting.SafeSubstring(line, 193, 35);
            Town_Area = Formatting.SafeSubstring(line, 228, 35);
            Global_Localization_Number = Formatting.SafeSubstring(line, 263, 35);
            Customs_ID = Formatting.SafeSubstring(line, 298, 35);
        }

        public override string ToString()
        {
            var line = $"{nameof(B00)}{Formatting.SafeTruncate(Sequential_Waybill_Item, 3, '0', true)}" +
                $"{Formatting.SafeTruncate(Address_Type_Qualifier, 3)}" +
                $"{Formatting.SafeTruncate(Name_1, 35)}" +
                $"{Formatting.SafeTruncate(Stree_Name_And_Number, 35)}" +
                $"{Formatting.SafeTruncate(Country_Code, 3)}" +
                $"{Formatting.SafeTruncate(Postcode, 9)}" +
                $"{Formatting.SafeTruncate(Place, 35)}" +
                $"{Formatting.SafeTruncate(Partner_ID, 35)}" +
                $"{Formatting.SafeTruncate(Name_2, 35)}" +
                $"{Formatting.SafeTruncate(Name_3, 35)}" +
                $"{Formatting.SafeTruncate(Town_Area, 35)}" +
                $"{Formatting.SafeTruncate(Global_Localization_Number, 35)}" +
                $"{Formatting.SafeTruncate(Customs_ID, 35)}" +
                $"{Formatting.CRLF}";
            if (Formatting.TrimLines) { line = line.Trim() + $"{Formatting.CRLF}"; }
            return line;
        }

    }
}
