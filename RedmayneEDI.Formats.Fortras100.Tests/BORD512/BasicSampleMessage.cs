using RedmayneEDI.Formats.Fortras100.BORD512;
using RedmayneEDI.Formats.Fortras100.Enums;
using System;
using System.IO;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace RedmayneEDI.Formats.Fortras100.Tests.BORD512
{
    public class BasicSampleMessage
    {
        public FortrasDocument Document { get; set; }
        
        public BasicSampleMessage()
        {
            Document = new FortrasDocument();

            // Send the Sending and Receiving Party ID's
            Document.PH.Sending_Party = "SHIPPER";
            Document.PH.Receiving_Party = "DELIVERY";

            // Set the Message Header
            Document.A00 = new Formats.Fortras100.BORD512.Models.A00()
            {
                Data_Type_Qualifier = DataTypeQualifiers.Standard,
                Arrival_Date = DateTime.UtcNow.AddDays(7).ToString("ddMMyyyy"),
                Arrival_Time = "0900",
                Waybill_Number = "TESTWAYBILL123456"
            };

            // Create a collection of Consignments - these are the inidividual units of work in the manifest.
            Document.CONSIGNMENTS = new System.Collections.Generic.List<CONSIGNMENT>()
            {
                new CONSIGNMENT()
                {
                    ADDRESSES = new System.Collections.Generic.List<ADDRESS>()
                    {
                        new ADDRESS()
                        {
                            // Sender Address
                            B00 = new Formats.Fortras100.BORD512.Models.B00()
                            {
                                Address_Type_Qualifier = AddressTypeQualifiers.Shipper,
                                Country_Code = "GB",
                                Name_1 = "SENDER NAME HERE",
                                Postcode = "AD12 1AS",
                                Stree_Name_And_Number = "1 SOME STREET",
                                Town_Area = "MANCHESTER"
                            }, B10 = new System.Collections.Generic.List<Formats.Fortras100.BORD512.Models.B10>()
                            {
                                new Formats.Fortras100.BORD512.Models.B10()
                                {
                                    Communication_Type_Qualifier = CommunicationTypeQualifiers.Email,
                                    Content = "SOURCECONTACT@SOURCECOMPANY.COM"
                                }
                            }
                        },
                        new ADDRESS()
                        {
                            // Receipient Address
                            B00 = new Formats.Fortras100.BORD512.Models.B00()
                            {
                                Address_Type_Qualifier = AddressTypeQualifiers.Consignee,
                                Country_Code = "GB",
                                Name_1 = "RECEIPIENT NAME HERE",
                                Postcode = "N11 123",
                                Stree_Name_And_Number = "1 SOME OTHER STREET",
                                Town_Area = "LONDON"
                            }, B10 = new System.Collections.Generic.List<Formats.Fortras100.BORD512.Models.B10>()
                            {
                                new Formats.Fortras100.BORD512.Models.B10()
                                {
                                    Communication_Type_Qualifier = CommunicationTypeQualifiers.Name,
                                    Content = "SOME CONTACT PERSON"
                                },
                                new Formats.Fortras100.BORD512.Models.B10()
                                {
                                    Communication_Type_Qualifier = CommunicationTypeQualifiers.Email,
                                    Content = "CONTACT@DELIVERYCOMPANY.COM"
                                },
                                new Formats.Fortras100.BORD512.Models.B10()
                                {
                                    Communication_Type_Qualifier = CommunicationTypeQualifiers.Telephone,
                                    Content = "+441234567890"
                                }
                            }
                        }
                    }
                    // A collection of Consignment Lines - the individual items that constitute this work unit
                    ,CONSIGNMENT_LINES = new System.Collections.Generic.List<CONSIGNMENT_LINE>()
                    {
                        new CONSIGNMENT_LINE()
                        {
                            D00 = new Formats.Fortras100.BORD512.Models.D00()
                            {
                                Actual_Weight = "500",
                                Chargable_Weight = "500",
                                Consignment_Position = "1",
                                Content_Of_Goods = "SHINY THINGS",
                                Cubic_Meters = "1",
                                Height_In_Meters = "1",
                                Width_In_Meters = "1",
                                Length_In_Meters = "1",
                                Number_Of_Packages = "2",
                                Number_Of_Packages_On_Pallets = "2",
                                Packaging_Type = "PAL"
                            },
                            F00 = new System.Collections.Generic.List<Formats.Fortras100.BORD512.Models.F00>()
                            {
                                new Formats.Fortras100.BORD512.Models.F00()
                                {
                                    Barcode = "0034123456765432"
                                },
                                new Formats.Fortras100.BORD512.Models.F00()
                                {
                                    Barcode = "0034123456765433"
                                }
                            }
                        }
                    },
                    G00 = new Formats.Fortras100.BORD512.Models.G00()
                    {
                        Delivery_Terms = "EXW",
                        Actual_Consignment_Gross_Weight_In_Grams = "500",
                        Chargeable_Consignment_Weight_In_Grams = "500",
                        Cubic_Metres = "1"
                    },
                    TEXTS = new TEXT()
                    {
                        H00 = new System.Collections.Generic.List<Formats.Fortras100.BORD512.Models.H00>()
                        {
                            new Formats.Fortras100.BORD512.Models.H00()
                            {
                                Text_Code_1 = "503",
                                Additional_Text_1 = "SOME TEST CODE HERE"
                            }
                        }
                    }
                },
                new CONSIGNMENT()
                {
                    ADDRESSES = new System.Collections.Generic.List<ADDRESS>()
                    {
                        new ADDRESS()
                        {
                            B00 = new Formats.Fortras100.BORD512.Models.B00()
                            {
                                Address_Type_Qualifier = AddressTypeQualifiers.Shipper,
                                Country_Code = "GB",
                                Name_1 = "SENDER NAME HERE",
                                Postcode = "AD12 1AS",
                                Stree_Name_And_Number = "1 SOME STREET",
                                Town_Area = "MANCHESTER"
                            }, B10 = new System.Collections.Generic.List<Formats.Fortras100.BORD512.Models.B10>()
                            {
                                new Formats.Fortras100.BORD512.Models.B10()
                                {
                                    Communication_Type_Qualifier = CommunicationTypeQualifiers.Email,
                                    Content = "SOURCECONTACT@SOURCECOMPANY.COM"
                                }
                            }
                        },
                        new ADDRESS()
                        {
                            B00 = new Formats.Fortras100.BORD512.Models.B00()
                            {
                                Address_Type_Qualifier = AddressTypeQualifiers.Consignee,
                                Country_Code = "DE",
                                Name_1 = "GERMAN COMPANY NAME",
                                Postcode = "86100",
                                Stree_Name_And_Number = "DEUTCH RD 4",
                                Town_Area = "BERLIN"
                            }, B10 = new System.Collections.Generic.List<Formats.Fortras100.BORD512.Models.B10>()
                            {
                                new Formats.Fortras100.BORD512.Models.B10()
                                {
                                    Communication_Type_Qualifier = CommunicationTypeQualifiers.Email,
                                    Content = "CONTACT@GERMANCOMPANY.COM"
                                }
                            }
                        }
                    }
                    ,CONSIGNMENT_LINES = new System.Collections.Generic.List<CONSIGNMENT_LINE>()
                    {
                        new CONSIGNMENT_LINE()
                        {
                            D00 = new Formats.Fortras100.BORD512.Models.D00()
                            {
                                Actual_Weight = "500",
                                Chargable_Weight = "500",
                                Consignment_Position = "1",
                                Content_Of_Goods = "SHINY THINGS",
                                Cubic_Meters = "1",
                                Height_In_Meters = "1",
                                Width_In_Meters = "1",
                                Length_In_Meters = "1",
                                Number_Of_Packages = "2",
                                Number_Of_Packages_On_Pallets = "2",
                                Packaging_Type = "PAL"
                            },
                            F00 = new System.Collections.Generic.List<Formats.Fortras100.BORD512.Models.F00>()
                            {
                                new Formats.Fortras100.BORD512.Models.F00()
                                {
                                    Barcode = "0034121234567890"
                                },
                                new Formats.Fortras100.BORD512.Models.F00()
                                {
                                    Barcode = "0034121234567891"
                                }
                            }
                        }
                    },
                    G00 = new Formats.Fortras100.BORD512.Models.G00()
                    {
                        Delivery_Terms = "EXW",
                        Actual_Consignment_Gross_Weight_In_Grams = "500",
                        Chargeable_Consignment_Weight_In_Grams = "500",
                        Cubic_Metres = "1"
                    },
                    TEXTS = new TEXT()
                    {
                        H00 = new System.Collections.Generic.List<Formats.Fortras100.BORD512.Models.H00>()
                        {
                            new Formats.Fortras100.BORD512.Models.H00()
                            {
                                Text_Code_1 = "503",
                                Additional_Text_1 = "SOME TEST CODE HERE"
                            }
                        }
                    }
                }
            };

        }

        public string CreateMessage(string outputDir = "")
        {
            // Create the output directory if provided and it doesn't exist.
            if (!string.IsNullOrWhiteSpace(outputDir) && !Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                var outputFile = Path.Combine(outputDir, "fortras512.bord.sample.txt");
                File.WriteAllText(outputFile, Document.ToString());
                System.Console.WriteLine($"Created {outputFile}");
                return outputFile;
            }
            else
            {
                System.Console.WriteLine(Document.ToString());
                return Document.ToString();
            }
        }
    }
}