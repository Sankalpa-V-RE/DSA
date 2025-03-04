using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProject.DataStructures.BinarySearchTree
{
    internal class DoctorNode
    {
        public Doctor Data;
        public DoctorNode? Left, Right;

        public DoctorNode(Doctor doctor)
        {
            Data = doctor;
            Left = Right = null;
        }
    }
}
