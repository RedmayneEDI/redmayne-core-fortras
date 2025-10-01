using System;
using System.Collections.Generic;

namespace RedmayneEDI.Formats.Fortras100
{
    /// <summary>
    /// A Global utilties class available to all Fortras models.
    /// </summary>
    public class Formatting
    {
        /// <summary>
        /// The Carriage Return, Line Feed character to append to the end of lines.
        /// This is a customisable parameter and is usually Unix, Mac or Windows EOL characters.
        /// </summary>
        public static string CRLF = "\n";

        /// <summary>
        /// When enabled, the standard limits on the maximum repetitions of records is lifted.
        /// </summary>
        public static bool DisableRecordLimits = false;

        /// <summary>
        /// Should lines be trimmed of empty space where possible? Defaults to True. When disabled lines are fully specified.
        /// </summary>
        public static bool TrimLines = true;

        /// <summary>
        /// Safely returns a substringed version of the given text up to the maximum length if specified, or returns an empty string for nullable values.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="start">The starting position for the substring</param>
        /// <param name="length">The maximum length of the string to extract</param>
        /// <param name="trim">When true, the return value is trimmed</param>
        /// <returns></returns>
        public static string SafeSubstring(string text, int start, int length = 0, bool trim = true)
        {
            if (text.Length <= (start + length))
            {
                if (text.Length > start) {  text = text.Substring(start); }
                else { return string.Empty; }
            }
            else
            {
                text = text.Substring(start, length).Trim();
            }

            if (trim)
            {
                text = text.Trim();
            }

            return text;
        }

        /// <summary>
        /// Safely returns a truncated version of the given text up to the maximum length, or returns an empty string for nullable values.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maximumLength"></param>
        /// <param name="padWith">Character used to pad the field to maximum length</param>
        /// <param name="padLeft">When enabled, the fields is padded on the left side of the value (often for trailing zeroes)</param>
        /// <returns></returns>
        public static string SafeTruncate(string text, int maximumLength, char padWith = ' ', bool padLeft = false)
        {
            var newText = text;
            if (!string.IsNullOrWhiteSpace(newText))
            {
                if (text.Length > maximumLength)
                {
                    newText = text.Substring(0, maximumLength);
                }
            }
            else { newText = string.Empty; }
            if (padLeft) { newText = newText.PadLeft(maximumLength, padWith); }
            else { newText = newText.PadRight(maximumLength, padWith); }
            return newText;
        }

        /// <summary>
        /// Generates a ToString()'d output of a Fortras list, limited by the maxRecords specified, or the full set if maximum limits are disabled.
        /// </summary>
        /// <typeparam name="T">The Data Type of the List.</typeparam>
        /// <param name="records">The contents of the List.</param>
        /// <param name="maxRecords">Maximum repetitions (can be disabled via DisableRecordLimits)</param>
        /// <returns></returns>
        public static string RecordSet<T>(List<T> records, int maxRecords)
        {
            string output = string.Empty;
            if (records == null) { return output; }
            if (DisableRecordLimits)
            {
                foreach (var record in records)
                {
                    output = $"{output}{record}";
                }
            }
            else
            {
                for (int i = 0; i < maxRecords; i++)
                {
                    if (i >= records.Count) { break; }
                    output = $"{output}{records[i]}";
                }
            }
            return output;
        }

        /// <summary>
        /// Scans for and attempts to identify the EOL character within the given string based upon the highest number of usages. Returns an empty string when unidentified, or the string representation of the EOL character (eg: "\r\n")
        /// </summary>
        /// <param name="text">The text to identify the EOL character in.</param>
        /// <returns>Either the EOL character (\r,\n, or \r\n), or empty on failure to find the character.</returns>
        public static string GetEOLFormat(string text)
        {
            int crlf = 0;
            int cr = 0;
            int lf = 0;
            if (text.Contains("\r\n"))
            {
                crlf = (text.Split(new string[] { "\r\n" }, StringSplitOptions.None).Length - 1);
                text = text.Replace("\r\n", "");
            }
            if (text.Contains("\r"))
            {
                cr = (text.Split(new string[] { "\r" }, StringSplitOptions.None).Length - 1);
                text = text.Replace("\r", "");
            }
            if (text.Contains("\n"))
            {
                lf = (text.Split(new string[] { "\n" }, StringSplitOptions.None).Length - 1);
                text = text.Replace("\n", "");
            }
            if (crlf <= 0 && cr <= 0 && lf <= 0) { return string.Empty; }
            else if (crlf == cr && crlf == lf) { return "\r\n"; }
            else if (crlf > cr && crlf > lf) { return "\r\n"; }
            else if (cr > crlf && cr > lf) { return "\r"; }
            else if (lf > crlf && lf > cr) { return "\n"; }
            else { return string.Empty; }
        }

        /// <summary>
        /// Returns a string date and string time as a single DateTime object
        /// </summary>
        /// <param name="dateStr">The Date in a ddMMyyyy pattern.</param>
        /// <param name="timeStr">The Time in a HHmm pattern.</param>
        /// <param name="dateTimeKind">Optional indicator if the date is UTC or Local timezone.</param>
        /// <returns></returns>
        public static DateTime GetDateTime(string dateStr, string timeStr, DateTimeKind dateTimeKind = DateTimeKind.Utc)
        {
            var dateTime = new DateTime(int.Parse(dateStr.Substring(4, 4)), int.Parse(dateStr.Substring(2, 2)), int.Parse(dateStr.Substring(0, 2)), int.Parse(timeStr.Substring(0, 2)), int.Parse(timeStr.Substring(2, 2)), 0, dateTimeKind);
            return dateTime;
        }

        /// <summary>
        /// Returns a string date as a DateTime object
        /// </summary>
        /// <param name="dateStr">The Date in a ddMMyyyy pattern.</param>
        /// <param name="dateTimeKind">Optional indicator if the date is UTC or Local timezone.</param>
        /// <returns></returns>
        public static DateTime GetDate(string dateStr, DateTimeKind dateTimeKind = DateTimeKind.Utc)
        {
            var dateTime = new DateTime(int.Parse(dateStr.Substring(4, 4)), int.Parse(dateStr.Substring(2, 2)), int.Parse(dateStr.Substring(0, 2)), 0, 0, 0, dateTimeKind);
            return dateTime;
        }
    }
}
