using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProject.DataStructures.BinaryTree
{
    internal class Staff
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public Staff(string name, string position)
        {
            Name = name;
            Position = position;
        }

        public override string ToString()
        {
            return $"{Position}: {Name}";
        }
        public class Director : Staff
        {
            public Director(string name) : base(name, "Director") { }
        }

        public class Doctor : Staff
        {
            public Doctor(string name) : base(name, "Doctor") { }
        }

        public class Nurse : Staff
        {
            public Nurse(string name) : base(name, "Nurse") { }
        }

        public class MinorStaff : Staff
        {
            public MinorStaff(string name) : base(name, "Minor Staff") { }
        }
    }

}
