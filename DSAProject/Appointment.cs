using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProject
{
    internal class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public string DoctorName { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }

        public Appointment(int appointmentId, int patientId, string doctorName, DateTime date, string reason)
        {
            AppointmentId = appointmentId;
            PatientId = patientId;
            DoctorName = doctorName;
            Date = date;
            Reason = reason;
        }

        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            Console.ResetColor();
            Console.WriteLine($"{"Appointment ID:",-20} {AppointmentId}");
            Console.WriteLine($"{"Patient ID:",-20} {PatientId}");
            Console.WriteLine($"{"Doctor:",-20} {DoctorName}");
            Console.WriteLine($"{"Date:",-20} {Date:yyyy-MM-dd HH:mm}");
            Console.WriteLine($"{"Reason:",-20} {Reason}\n");
        }
    }
}
