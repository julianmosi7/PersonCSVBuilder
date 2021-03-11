using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PersonCSVBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            //var builder = new Person.Builder("Julian", "Moshammer");

            //var person = builder.Build();
            //var person2 = builder.Age(18).Build();
            //Console.WriteLine(person);
            //Console.WriteLine(person2);

            //Console.ReadKey();
            List<Person> persons = new List<Person>();
            var lines = File.ReadAllLines("persons_with_address.csv").Skip(1).Select(x => x.Split(";"));
            foreach (var line in lines)
            {
                try
                {
                    var person = new Person.Builder(line[0], line[1]).Age(Int32.Parse(line[2])).Address(line[2]).Phone(line[3]).Build();
                    persons.Add(person);
                }
                catch(InvalidOperationException exc)
                {
                    Console.WriteLine(exc.Message);
                }
                
            }
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}
