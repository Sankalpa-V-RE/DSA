using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DSAProject.DataStructures.LinkedList
{
    internal class PatientsList
    {
        private PatientNode? head;
        private PatientNode? tail;
        private string filePath = "C:\\Users\\Vihanga\\Documents\\New folder (5)\\DSA\\patients.csv";

        public PatientsList()
        {
            this.head = null;
            this.tail = null;
        }

        public void AddPatient(Patient patient, bool saveToFile = true)
        {
            PatientNode temp = new PatientNode(patient);
            if (head == null)
            {
                head = temp;
                tail = temp;
            }
            else
            {
                tail.Next = temp;
                tail = temp;
                temp.Next = null;
            }
            if (saveToFile)
            {
                SavePatientsToFile();
            }
        }

        public bool RemovePatient(int id)
        {
            if (head == null) return false;

            if (head.Data.Id == id)
            {
                head = head.Next;
                return true;
            }

            PatientNode temp = head;
            while (temp.Next != null)
            {
                if (temp.Next.Data.Id == id)
                {
                    temp.Next = temp.Next.Next;
                    return true;
                }
                temp = temp.Next;
            }
            SavePatientsToFile();
            return false;
        }

        public Patient SearchPatient(int id)
        {
            PatientNode? temp = head;
            while (temp != null)
            {
                if (temp.Data.Id == id)
                    return temp.Data;
                temp = temp.Next;
            }
            return null;
        }

        public void DisplayAllPatients()
        {
            PatientNode? temp = head;
            while (temp != null)
            {
                temp.Data.Display();
                temp = temp.Next;
            }
        }

        public void SavePatientsToFile()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                PatientNode temp = head;
                while (temp != null)
                {
                    writer.WriteLine($"{temp.Data.Id},{temp.Data.Name},{temp.Data.Age},{temp.Data.Gender},{temp.Data.MedicalHistory}");
                    temp = temp.Next;
                }
            }
        }

        public void LoadPatientsFromFile()
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
                        int id = int.Parse(parts[0]);
                        string name = parts[1];
                        int age = int.Parse(parts[2]);
                        string gender = parts[3];
                        string history = parts[4];

                        AddPatient(new Patient(id, name, age, gender, history), false);
                    }
                }
            }
        }

        public void SortPatients(string criteria)
        {
            head = MergeSort(head, criteria);
        }

        private PatientNode MergeSort(PatientNode node, string criteria)
        {
            if (node == null || node.Next == null)
                return node;

            PatientNode middle = GetMiddle(node);
            PatientNode nextToMiddle = middle.Next;
            middle.Next = null;

            PatientNode left = MergeSort(node, criteria);
            PatientNode right = MergeSort(nextToMiddle, criteria);

            return Merge(left, right, criteria);
        }

        private PatientNode Merge(PatientNode left, PatientNode right, string criteria)
        {
            if (left == null) return right;
            if (right == null) return left;

            PatientNode result;

            if (criteria == "name")
            {
                if (string.Compare(left.Data.Name, right.Data.Name, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    result = left;
                    result.Next = Merge(left.Next, right, criteria);
                }
                else
                {
                    result = right;
                    result.Next = Merge(left, right.Next, criteria);
                }
            }
            else // Sort by age
            {
                if (left.Data.Age <= right.Data.Age)
                {
                    result = left;
                    result.Next = Merge(left.Next, right, criteria);
                }
                else
                {
                    result = right;
                    result.Next = Merge(left, right.Next, criteria);
                }
            }

            return result;
        }

        private PatientNode GetMiddle(PatientNode node)
        {
            if (node == null) return null;

            PatientNode slow = node, fast = node.Next;
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return slow;
        }
    }
}
