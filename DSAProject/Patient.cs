using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProject
{
    internal class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string MedicalHistory { get; set; }

        public Patient(int id, string name, int age, string gender, string medicalHistory)
        {
            Id = id;
            Name = name;
            Age = age;
            Gender = gender;
            MedicalHistory = medicalHistory;
        }

        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            
            Console.ResetColor();
            Console.WriteLine($"{"ID:",-15} {Id}");
            Console.WriteLine($"{"Name:",-15} {Name}");
            Console.WriteLine($"{"Age:",-15} {Age}");
            Console.WriteLine($"{"Gender:",-15} {Gender}");
            Console.WriteLine($"{"Medical History:",-15} {MedicalHistory}\n");
        }
    }
}
