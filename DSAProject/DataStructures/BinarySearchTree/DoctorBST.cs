using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProject.DataStructures.BinarySearchTree
{
    internal class DoctorBST
    {
        private DoctorNode? Root;
        private string filePath = "C:\\Users\\Vihanga\\Documents\\DSA\\DSAProject\\doctors.csv";

        // Insert a new doctor
        public DoctorBST() { Root = null; }
        public void Insert(Doctor doctor)
        {
            Root = InsertRecusively(doctor, Root);
            SaveDoctorsToFile();
        }

        private DoctorNode InsertRecusively(Doctor doctor, DoctorNode? root)
        {
            if (root == null)
                return new DoctorNode(doctor);

            if (doctor.Id < root.Data.Id)
                root.Left = InsertRecusively(doctor, root.Left);
            else if (doctor.Id > root.Data.Id)
                root.Right = InsertRecusively(doctor, root.Right);

            return root;
        }

        // Search doctor by ID
        public Doctor Search(int id)
        {
            return SearchRec(Root, id);
        }

        private Doctor SearchRec(DoctorNode? root, int id)
        {
            if (root == null || root.Data.Id == id)
                return root?.Data;

            return id < root.Data.Id ? SearchRec(root.Left, id) : SearchRec(root.Right, id);
        }

        // In-order traversal (sorted output)
        public void DisplayDoctors()
        {
            InOrderTraversal(Root);
        }

        private void InOrderTraversal(DoctorNode root)
        {
            if (root != null)
            {
                InOrderTraversal(root.Left);
                root.Data.Display();
                InOrderTraversal(root.Right);
            }
        }

        // CSV Persistence
        public void SaveDoctorsToFile()
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                SaveRec(Root, writer);
            }
        }

        private void SaveRec(DoctorNode? root, StreamWriter writer)
        {
            if (root != null)
            {
                writer.WriteLine($"{root.Data.Id},{root.Data.Name},{root.Data.Specialty},{root.Data.Experience}");
                SaveRec(root.Left, writer);
                SaveRec(root.Right, writer);
            }
        }

        public void LoadDoctorsFromFile()
        {
            if (!File.Exists(filePath)) return;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        int id = int.Parse(parts[0]);
                        string name = parts[1];
                        string specialty = parts[2];
                        int experience = int.Parse(parts[3]);

                        Root = InsertRecusively(new Doctor(id, name, specialty, experience), Root);
                    }
                }
            }
        }
    }
}
