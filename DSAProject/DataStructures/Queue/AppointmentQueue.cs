using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProject.DataStructures.Queue
{
    internal class AppointmentQueue
    {
        private AppointmentNode? front;
        private AppointmentNode? rear;
        private string filePath = "C:\\Users\\Vihanga\\Documents\\New folder (5)\\DSA\\appointments.csv";

        public AppointmentQueue()
        {
            front = null;
            rear = null;
        }
        public bool IsEmpty()
        {
            return front == null && rear == null;
        }

        public void Enqueue(Appointment appointment, bool saveToFile = true)
        {
            AppointmentNode newNode = new AppointmentNode(appointment);
            if (rear == null)
            {
                front = rear = newNode;
            }
            else
            {
                rear.Next = newNode;
                rear = newNode;
            }
            if (saveToFile)
            {
                SaveAppointmentsToFile();
            }
        }

        public Appointment Dequeue(bool saveToFile = true)
        {
            if (IsEmpty()) return null;

            Appointment temp = front.Data;
            front = front.Next;

            if (front == null)
                rear = null;

            if (saveToFile)
            {
                SaveAppointmentsToFile();
            }
            return temp;
        }

        public Appointment Peek()
        {
            if (!IsEmpty()) {
                return null;
            }
            return front.Data;
        }

        public void DisplayAppointments()
        {
            if (IsEmpty())
            {
                Console.WriteLine("No appointments scheduled.\n");
                return;
            }

            AppointmentNode temp = front;
            while (temp != null)
            {
                temp.Data.Display();
                temp = temp.Next;
            }
        }

        public void SaveAppointmentsToFile()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                AppointmentNode temp = front;
                while (temp != null)
                {
                    writer.WriteLine($"{temp.Data.AppointmentId},{temp.Data.PatientId},{temp.Data.DoctorName},{temp.Data.Date},{temp.Data.Reason}");
                    temp = temp.Next;
                }
            }
        }
        public void LoadAppointmentsFromFile()
    {
        if (!File.Exists(filePath)) return;

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 5)
                {
                    int appId = int.Parse(parts[0]);
                    int patientId = int.Parse(parts[1]);
                    string doctorName = parts[2];
                    DateTime date = DateTime.Parse(parts[3]);
                    string reason = parts[4];

                    Enqueue(new Appointment(appId, patientId, doctorName, date, reason),false);
                }
            }
        }
    }
    }
}
