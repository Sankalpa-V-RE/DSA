using DSAProject;
//using DSAProject.DataStructures.BinarySearchTree;
using DSAProject.DataStructures.LinkedList;
using DSAProject.DataStructures.Queue;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using DSAProject.DataStructures.BinaryTree;
using static DSAProject.DataStructures.BinaryTree.Staff;

// Initialize data structures
PatientsList patientsList = new PatientsList();
AppointmentQueue appointmentQueue = new AppointmentQueue();
//DoctorBST doctorTree = new DoctorBST();

// Load data from files
patientsList.LoadPatientsFromFile();
appointmentQueue.LoadAppointmentsFromFile();
//doctorTree.LoadDoctorsFromFile();
const string adminPassword = "admin123";
BinaryTree staffTree = new BinaryTree();
staffTree.AddStaff(new Director("Dr. John Smith"));
staffTree.AddStaff(new Doctor("Dr. Alice Johnson"));
staffTree.AddStaff(new Doctor("Dr. Robert White"));
staffTree.AddStaff(new Nurse("Nurse Mary Brown"));
staffTree.AddStaff(new MinorStaff("John Doe"));

while (true)
{
    try
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("\n===============================");
        Console.WriteLine("   Health Management System   ");
        Console.WriteLine("===============================");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("1.  Add Patient");
        Console.WriteLine("2.  Remove Patient");
        Console.WriteLine("3.  Search Patient");
        Console.WriteLine("4.  Display All Patients");
        Console.WriteLine("5.  Schedule Appointment");
        Console.WriteLine("6.  Process Next Appointment");
        Console.WriteLine("7.  View All Appointments");
        //Console.WriteLine("8.  Add Doctor");
        //Console.WriteLine("9.  Search Doctor");
        Console.WriteLine("8.  Staff Management");
        //Console.WriteLine("10. Display All Doctors");
        Console.WriteLine("9.  Exit");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\nChoose an option: ");
        Console.ResetColor();

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1: // Add Patient
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n--- Add New Patient ---");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Enter Patient ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Age: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Enter Gender: ");
                string gender = Console.ReadLine();

                Console.Write("Enter Medical History: ");
                string history = Console.ReadLine();
                Console.ResetColor();

                patientsList.AddPatient(new Patient(id, name, age, gender, history));

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nPatient added successfully!");
                Console.ResetColor();
                break;

            case 2: // Remove Patient
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n--- Remove Patient ---");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Enter Patient ID to remove: ");
                int removeId = int.Parse(Console.ReadLine());
                Console.ResetColor();

                if (patientsList.RemovePatient(removeId))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nPatient removed successfully!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPatient not found.");
                }
                Console.ResetColor();
                break;

            case 3: // Search Patient
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n--- Search Patient ---");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Enter Patient ID to search: ");
                int searchId = int.Parse(Console.ReadLine());
                Console.ResetColor();

                Patient foundPatient = patientsList.SearchPatient(searchId);
                if (foundPatient != null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nPATIENT DETAILS");
                    foundPatient.Display();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Patient not found.");
                }
                Console.ResetColor();
                break;

            case 4: // Display All Patients
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n---Display all Patients ---");
                Console.WriteLine("1.  Sort by name");
                Console.WriteLine("2.  Sort by age");
                int sortOption = int.Parse(Console.ReadLine());
                Console.ResetColor();
                switch (sortOption)
                {
                    case 1:
                        patientsList.SortPatients("name");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nPatients sorted by Name successfully!");
                        break;
                    case 2:
                        patientsList.SortPatients("age");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nPatients sorted by Age successfully!");
                        break;
                }
                Console.ForegroundColor = ConsoleColor.White;
                patientsList.DisplayAllPatients();
                Console.ResetColor();
                break;

            case 5: // Schedule Appointment
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n--- Schedule Appointment ---");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Enter Appointment ID: ");
                int appId = int.Parse(Console.ReadLine());
                Console.Write("Enter Patient ID: ");
                int patientId = int.Parse(Console.ReadLine());
                Console.Write("Enter Doctor's Name: ");
                string doctor = Console.ReadLine();
                Console.Write("Enter Appointment Date (yyyy-MM-dd HH:mm): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter Reason: ");
                string reason = Console.ReadLine();
                Console.ResetColor();
                appointmentQueue.Enqueue(new Appointment(appId, patientId, doctor, date, reason));

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nAppointment scheduled successfully!");
                Console.ResetColor();
                break;
            case 6: // Process Next Appointment
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n--- Process Next Appointment ---");
                Console.ResetColor();

                Appointment nextAppointment = appointmentQueue.Dequeue();
                if (nextAppointment != null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Processing Next Appointment:");
                    Console.ResetColor();
                    nextAppointment.Display();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No appointments in queue.");
                    Console.ResetColor();
                }
                break;
            case 7: // View All Appointments
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n--- All Scheduled Appointments ---");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nAPPOINTMENT DETAILS");
                appointmentQueue.DisplayAppointments();
                Console.ResetColor();
                break;

            //case 10:
            //    Console.WriteLine("All Doctors:");
            //    doctorTree.DisplayDoctors();
            //    break;

            case 8:
                ManageStaff(staffTree);
                break;

            case 9: // Exit
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n===============================");
                Console.WriteLine("        Exiting System...      ");
                Console.WriteLine("===============================");
                Console.ResetColor();
                return;

            // Add similar color formatting for other cases

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid choice. Please try again.");
                Console.ResetColor();
                break;
        }
    }
    catch { Console.WriteLine("Invalid Choice"); }
}


static void ManageStaff(BinaryTree tree)
{
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n===============================");
        Console.WriteLine("Staff Management Menu");
        Console.WriteLine("===============================");
        Console.WriteLine("1. Add Staff");
        Console.WriteLine("2. Remove Staff");
        Console.WriteLine("3. Search Staff");
        Console.WriteLine("4. Display All Staff");
        Console.WriteLine("5. Change Director");
        Console.WriteLine("6. Back to Main Menu");
        Console.WriteLine("===============================");

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Choose an option: ");
        string option = Console.ReadLine();
        Console.Clear();

        switch (option)
        {
            case "1":
                AddStaffMember(tree);
                break;
            case "2":
                Console.Write("Enter the staff name to remove: ");
                string nameToRemove = Console.ReadLine();
                RemoveStaffMember(tree, nameToRemove);
                break;
            case "3":
                Console.Write("Enter the staff name to search: ");
                string nameToSearch = Console.ReadLine();
                SearchStaffMember(tree, nameToSearch);
                break;
            case "4":
                DisplayStaffByPosition(tree);
                break;
            case "5":
                ChangeDirector(tree);
                break;
            case "6":
                return;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid option! Please choose a valid option.");
                break;
        }
    }
}

static void AddStaffMember(BinaryTree tree)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("Enter the staff name: ");
    string name = Console.ReadLine();
    Console.WriteLine("Enter the position of the staff (Doctor, Nurse, Minor Staff): ");
    string position = Console.ReadLine();

    Staff newStaff;
    switch (position.ToLower())
    {
        case "doctor":
            newStaff = new Doctor(name);
            break;
        case "nurse":
            newStaff = new Nurse(name);
            break;
        case "minor staff":
            newStaff = new MinorStaff(name);
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid position. Only Doctor, Nurse, or Minor Staff can be added using this option.");
            return;
    }

    tree.AddStaff(newStaff);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"{position} {name} added successfully!");
}

static void RemoveStaffMember(BinaryTree tree, string name)
{
    tree.RemoveStaff(name);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Staff member {name} removed successfully.");
}

static void SearchStaffMember(BinaryTree tree, string name)
{
    var result = tree.SearchStaff(name);
    if (result != null)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Staff member found: {result.StaffMember}");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Staff member not found.");
    }
}

static void DisplayStaffByPosition(BinaryTree tree)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\nDisplaying All Staff by Position:\n=======================");

    var allStaff = tree.GetAllStaff(tree.Root);
    var sortedStaff = allStaff.OrderBy(s => s.Position).ThenBy(s => s.Name).ToList();
    List<string> positionOrder = new List<string> { "Director", "Doctor", "Nurse", "Minor Staff" };

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("{0,-20} {1,-10}", "Name", "Position");
    Console.WriteLine(new string('-', 30));

    foreach (var position in positionOrder)
    {
        var staffInPosition = sortedStaff.Where(s => s.Position.Equals(position, StringComparison.OrdinalIgnoreCase)).ToList();
        foreach (var staff in staffInPosition)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0,-20} {1,-10}", staff.Name, staff.Position);
        }
    }
}

static void ChangeDirector(BinaryTree tree)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("Enter admin password to change director: ");
    string password = Console.ReadLine();
    if (password != adminPassword)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid admin password. Access denied.");
        return;
    }
    Console.Write("Enter new director's name: ");
    string newDirectorName = Console.ReadLine();
    var allStaff = tree.GetAllStaff(tree.Root);
    var currentDirector = allStaff.FirstOrDefault(s => s.Position.Equals("Director", StringComparison.OrdinalIgnoreCase));
    if (currentDirector != null)
        tree.RemoveStaff(currentDirector.Name);
    tree.AddStaff(new Director(newDirectorName));
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Director changed successfully to {newDirectorName}.");
}