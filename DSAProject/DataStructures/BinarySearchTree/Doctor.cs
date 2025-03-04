using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProject.DataStructures.BinarySearchTree
{
    internal class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public int Experience { get; set; } // Years of experience

        public Doctor(int id, string name, string specialty, int experience)
        {
            Id = id;
            Name = name;
            Specialty = specialty;
            Experience = experience;
        }

        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nDOCTOR DETAILS");
            Console.ResetColor();
            Console.WriteLine($"{"ID:",-15} {Id}");
            Console.WriteLine($"{"Name:",-15} {Name}");
            Console.WriteLine($"{"Specialty:",-15} {Specialty}");
            Console.WriteLine($"{"Experience:",-15} {Experience} years\n");
        }
    }
}
