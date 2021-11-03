using FileParser;
using FileParser.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileParserTest
{
    [TestClass]
    [DeploymentItem(@"TestData\PeopleTest.csv", "TestData")]
    public class ParseTest
    {
        [TestMethod]
        public void Parse_GetPeopleFromCSV()
        {
            string fileName = "PeopleTest.csv";
            string filePath =
                Path.Combine(
                    Environment.CurrentDirectory,
                    @"TestData\", fileName);

            int expected = 12;
            var actual = Parse
                .GetPeopleFromCSV(filePath)
                .Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Parse_LoadCSVCheckByLineCount()
        {
            string fileName = "PeopleTest.csv";
            string filePath = 
                Path.Combine(
                    Environment.CurrentDirectory, 
                    @"TestData\", fileName);

            int expected = 13;
            int actual = Parse.LoadCSV(filePath).Length;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Parse_SplitCSV_TestCommasInString()
        {
            string csvRow = "2,\"Abe\",\"Testing\",\"199 Any Where Drive, Apartment E\"";
            List<string> expected = new()
            {
                "2", 
                "Abe", 
                "Testing", 
                "199 Any Where Drive, Apartment E"
            };

            var actual = Parse.SplitCSV(csvRow);

            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
            Assert.AreEqual(expected[3], actual[3]);
        }

        [TestMethod]
        public void Parse_SplitCSV_TestDoubleQuotesInString()
        {
            string csvRow = "52,\"Rolo\",\"Candy\",\"600 \"\"Zebra Stripe\"\" Avenue";
            List<string> expected = new()
            {
                "52",
                "Rolo",
                "Candy",
                "600 Zebra Stripe Avenue"
            };

            var actual = Parse.SplitCSV(csvRow);

            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
            Assert.AreEqual(expected[3], actual[3]);
        }

        [TestMethod]
        public void Parse_ParseToObject()
        {
            List<string> csvRow = new()
            {
                "7",
                "Gabe",
                "Testing",
                "500 Abe Street"
            };

            Person expected = new()
            {
                Id = 7,
                FirstName = "Gabe",
                LastName = "Testing",
                Address = "500 Abe Street"
            };

            var actual = Parse.ParseToObject(csvRow);

            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.Address, actual.Address);
        }
    }
}
