using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace RedmayneEDI.Formats.Fortras100.Tests
{
    /// <summary>
    /// Tests that populate a Fortras model, convert to text, and then import the text back to a model.
    /// </summary>
    [TestClass]
    public class FortrasTests
    {
        /// <summary>
        /// Creates a sample BORD512 object, write to text file and then read into an object.
        /// </summary>
        [TestMethod]
        public void BasicFortrasBORD512Test()
        {
            var outputDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "edi-generated-samples");

            // Create a model using the basic sample message example
            //   See the SampleMessage for an example of code-based document creation/population
            var originalModel = new BORD512.BasicSampleMessage();

            // Save the model and return the file path
            //   This will write the plain-text version of the model1 object to disk
            var file1 = originalModel.CreateMessage(outputDir);
            
            // Read in the saved file and interpret as a Fortras document model
            //   This will confirm a plain-text model can be read to a model
            var bordInterpreter = new Formats.Fortras100.BORD512.Interpreter();
            bordInterpreter.FileFormatEncoding = System.Text.Encoding.Latin1; // Use standard Windows ISO-8859-1 format to read the file.
            var file1Model = bordInterpreter.ReadFile(file1);
            
            // Write the model back to disk as a new plain-text file
            //   This will test converting a loaded model back to plain-text
            var file2 = Path.Combine(outputDir, "fortras512.bord.sample2.txt");
            File.WriteAllText(file2, file1Model.ToString());

            // Read in the plain-text of file2 as just a String
            var file2Text = File.ReadAllText(file2);

            // Compare the text of the originalModel to the text of file2Text.
            //   The resulting comparison should succeed if serialising/deserialising worked.
            Assert.AreEqual(originalModel.Document.ToString(), file2Text, "Original model and re-interpretted model do not match!");
        }

        /// <summary>
        /// Creates a sample STAT512 object, write to text file and then read into an object.
        /// </summary>
        [TestMethod]
        public void BasicFortrasSTAT512Test()
        {
            var outputDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "edi-generated-samples");

            // Create a model using the basic sample message example
            //   See the SampleMessage for an example of code-based document creation/population
            var originalModel = new STAT512.BasicSampleMessage();

            // Save the model and return the file path
            //   This will write the plain-text version of the model1 object to disk
            var file1 = originalModel.CreateMessage(outputDir);

            // Read in the saved file and interpret as a Fortras document model
            //   This will confirm a plain-text model can be read to a model
            var statInterpreter = new Formats.Fortras100.STAT512.Interpreter();
            statInterpreter.FileFormatEncoding = System.Text.Encoding.ASCII; // Use ASCII format for reading the file.
            var file1Model = statInterpreter.ReadFile(file1);

            // Write the model back to disk as a new plain-text file
            //   This will test converting a loaded model back to plain-text
            var file2 = Path.Combine(outputDir, "fortras512.stat.sample2.txt");
            File.WriteAllText(file2, file1Model.ToString());

            // Read in the plain-text of file2 as just a String
            var file2Text = File.ReadAllText(file2);

            // Compare the text of the originalModel to the text of file2Text.
            //   The resulting comparison should succeed if serialising/deserialising worked.
            Assert.AreEqual(originalModel.Document.ToString(), file2Text, "Original model and re-interpretted model do not match!");
        }

        /// <summary>
        /// Creates a sample ENTL512 object, write to text file and then read into an object.
        /// </summary>
        [TestMethod]
        public void BasicFortrasENTL512Test()
        {
            var outputDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "edi-generated-samples");

            // Create a model using the basic sample message example
            //   See the SampleMessage for an example of code-based document creation/population
            var originalModel = new ENTL512.BasicSampleMessage();

            // Save the model and return the file path
            //   This will write the plain-text version of the model1 object to disk
            var file1 = originalModel.CreateMessage(outputDir);

            // Read in the saved file and interpret as a Fortras document model
            //   This will confirm a plain-text model can be read to a model
            var entlInterpreter = new Formats.Fortras100.ENTL512.Interpreter();
            entlInterpreter.FileFormatEncoding = System.Text.Encoding.UTF8; // Use UTF8 format for reading the ENTL file.
            var file1Model = entlInterpreter.ReadFile(file1);

            // Write the model back to disk as a new plain-text file
            //   This will test converting a loaded model back to plain-text
            var file2 = Path.Combine(outputDir, "fortras512.entl.sample2.txt");
            File.WriteAllText(file2, file1Model.ToString());

            // Read in the plain-text of file2 as just a String
            var file2Text = File.ReadAllText(file2);

            // Compare the text of the originalModel to the text of file2Text.
            //   The resulting comparison should succeed if serialising/deserialising worked.
            Assert.AreEqual(originalModel.Document.ToString(), file2Text, "Original model and re-interpretted model do not match!");
        }
    }
}
