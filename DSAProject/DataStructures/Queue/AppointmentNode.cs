using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProject.DataStructures.Queue
{
    internal class AppointmentNode
    {
        public Appointment Data { get; set; }
        public AppointmentNode? Next { get; set; }

        public AppointmentNode(Appointment new_appointment)
        {
            Data = new_appointment;
            Next = null;
        }
    }
}
