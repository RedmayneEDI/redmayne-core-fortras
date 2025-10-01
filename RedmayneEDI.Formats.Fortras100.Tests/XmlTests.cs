using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace RedmayneEDI.Formats.Fortras100.Tests
{
    /// <summary>
    /// Tests that perform conversion to and from Fortras objects and serialised XML model representations.
    /// </summary>
    [TestClass]
    public class XmlTests
    {
        /// <summary>
        /// Converts a Sample BORD512 document from a BORD FortrasDocument to an XML document, and then back.
        /// </summary>
        [TestMethod]
        public void XmlFortrasBORD512Test()
        {
            var outputDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "edi-generated-samples");

            // Create a test BORD512 model
            var fortrasbord = new BORD512.BasicSampleMessage();

            // Serialise to Xml
            var xmlText = string.Empty;
            using (var stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(fortrasbord.Document.GetType());
                serializer.Serialize(stringwriter, fortrasbord.Document);
                xmlText = stringwriter.ToString();
            }

            // Create the XML output test file
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }
            File.WriteAllText(Path.Combine(outputDir, "fortras-bord512-test.xml"), xmlText);

            // Deserialise to an object
            var deserialisedModel = new Fortras100.BORD512.FortrasDocument();
            using (var stringReader = new System.IO.StringReader(xmlText))
            {
                var serializer = new XmlSerializer(typeof(Fortras100.BORD512.FortrasDocument));
                deserialisedModel = serializer.Deserialize(stringReader) as Fortras100.BORD512.FortrasDocument;
            }

            // Compare the Deserialised model to the initial model
            Assert.AreEqual(fortrasbord.Document.ToString(), deserialisedModel.ToString(), "Original model and interpretted model do not match!");
        }

        /// <summary>
        /// Converts a Sample STAT512 document from a STAT FortrasDocument to an XML document, and then back.
        /// </summary>
        [TestMethod]
        public void XmlFortrasSTAT512Test()
        {
            var outputDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "edi-generated-samples");

            // Create a test STAT512 model
            var fortrasstat = new STAT512.BasicSampleMessage();

            // Serialise to Xml
            var xmlText = string.Empty;
            using (var stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(fortrasstat.Document.GetType());
                serializer.Serialize(stringwriter, fortrasstat.Document);
                xmlText = stringwriter.ToString();
            }

            // Create the XML output test file
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }
            File.WriteAllText(Path.Combine(outputDir, "fortras-stat512-test.xml"), xmlText);

            // Deserialise to an object
            var deserialisedModel = new Fortras100.STAT512.FortrasDocument();
            using (var stringReader = new System.IO.StringReader(xmlText))
            {
                var serializer = new XmlSerializer(typeof(Fortras100.STAT512.FortrasDocument));
                deserialisedModel = serializer.Deserialize(stringReader) as Fortras100.STAT512.FortrasDocument;
            }

            // Compare the Deserialised model to the initial model
            Assert.AreEqual(fortrasstat.Document.ToString(), deserialisedModel.ToString(), "Original model and interpretted model do not match!");
        }

        /// <summary>
        /// Converts a Sample ENTL512 document from a ENTL FortrasDocument to an XML document, and then back.
        /// </summary>
        [TestMethod]
        public void XmlFortrasENTL512Test()
        {
            var outputDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "edi-generated-samples");

            // Create a test ENTL512 model
            var fortrasentl = new ENTL512.BasicSampleMessage();

            // Serialise to Xml
            var xmlText = string.Empty;
            using (var stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(fortrasentl.Document.GetType());
                serializer.Serialize(stringwriter, fortrasentl.Document);
                xmlText = stringwriter.ToString();
            }

            // Create the XML output test file
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }
            File.WriteAllText(Path.Combine(outputDir, "fortras-entl512-test.xml"), xmlText);

            // Deserialise to an object
            var deserialisedModel = new Fortras100.ENTL512.FortrasDocument();
            using (var stringReader = new System.IO.StringReader(xmlText))
            {
                var serializer = new XmlSerializer(typeof(Fortras100.ENTL512.FortrasDocument));
                deserialisedModel = serializer.Deserialize(stringReader) as Fortras100.ENTL512.FortrasDocument;
            }

            // Compare the Deserialised model to the initial model
            Assert.AreEqual(fortrasentl.Document.ToString(), deserialisedModel.ToString(), "Original model and interpretted model do not match!");
        }
    }
}
