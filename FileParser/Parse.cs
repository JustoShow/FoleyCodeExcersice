using FileParser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FileParser
{
    public static class Parse
    {
        public static List<Person> GetPeopleFromCSV(
            string filePath, bool hasHeader = true)
        {
            List<Person> people = new();
            string[] peopleData = LoadCSV(filePath);
            foreach (var person in peopleData)
            {
                if (hasHeader) 
                {
                    hasHeader = false;
                    continue;
                }
                var line = SplitCSV(person);
                people.Add(ParseToObject(line));
            }

            return people;
        }

        public static string[] LoadCSV(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                return lines;
            }
            catch (Exception)
            {                
                return null;
            }
        }

        public static Person ParseToObject(List<string> line)
        {
            Person person = new()
            {
                Id = Convert.ToInt32(line[0]),
                FirstName = line[1].Trim(),
                LastName = line[2].Trim(),
                Address = line[3].Trim()
            };

            return person;
        }

        private static readonly Regex csvSplit =
                new Regex("(?:^|,)(\"(?:[^\"]+)*\"|[^,]*)");

        public static List<string> SplitCSV(string line)
        {
            string cleanLine = line.Replace("\"\"", "");
            List<string> splitLine = new();
            string currentValue = null;
            var matches = csvSplit.Matches(cleanLine);

            foreach (Match match in matches)
            {
                currentValue = match.Value;

                if (currentValue.Length == 0) 
                { splitLine.Add(""); }

                splitLine.Add(
                    match.Value
                    .Trim(',')
                    .Replace('"', ' ')
                    .Trim());
            }

            return splitLine; 
        }
    }
}
