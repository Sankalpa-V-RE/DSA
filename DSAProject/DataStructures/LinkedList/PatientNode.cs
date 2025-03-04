using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProject.DataStructures.LinkedList
{
    internal class PatientNode
    {
        public Patient Data { get; set; }
        public PatientNode? Next { get; set; }

        public PatientNode(Patient patient)
        {
            Data = patient;
            Next = null;
        }
    }
}
