namespace RedmayneEDI.Formats.Fortras100.Base
{
    /// <summary>
    /// The standard Fortras end of message tag.
    /// </summary>
    public class PT
    {
        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith($"@@{nameof(PT)}")) { line = line.Substring(4); }
        }

        public override string ToString()
        {
            return $"@@PT" +
                $"{Formatting.CRLF}";
        }
    }
}
