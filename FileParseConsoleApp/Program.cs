using FileParser;
using System;
using System.IO;
using System.Linq;

namespace FileParseConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "PeopleTest.csv";

            if (!File.Exists(fileName)) 
            {
                Console.WriteLine("File does not exist.");
                return;
            }

            var people = Parse
                .GetPeopleFromCSV(fileName);

            foreach (var person in people.OrderBy(p => p.LastName))
            {
                Console.WriteLine("Id: {0}\t " +
                    "Last Name: {1}\t " +
                    "First Name: {2}\t " +
                    "Address: {3}",
                    person.Id,
                    person.LastName,
                    person.FirstName,
                    person.Address);
            }

        }
    }
}
