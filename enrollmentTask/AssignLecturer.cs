using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentTask
{
    /// <summary>
    /// Kristopher mann
    /// Class to assign lecturers to a new course of your choice
    /// </summary>
    public class AssignLecturer
    {
        private const string FilePath = "../../../Lecturers.txt";  // File path to the lecturers data file
        private Dictionary<int, List<string>> lecturers;           // Dictionary to store course IDs with associated lecturer names

        public AssignLecturer()
        {
            lecturers = LoadLecturers();  // Initialize lecturers by loading from file
        }

        // Loads lecturer data from the file using StreamReader
        private Dictionary<int, List<string>> LoadLecturers()
        {
            var lecturers = new Dictionary<int, List<string>>();

            // Opens the file
            using (StreamReader reader = new StreamReader(FilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null) // Read each line until end of file
                {
                    var parts = line.Split(',');           // Split line by comma to separate course ID and lecturer name
                    int courseId = int.Parse(parts[0].Trim()); // Parse and trim course ID
                    string lecturerName = parts[1].Trim();

                    // If course ID doesn't exist in the dictionary, create a new list for it
                    if (!lecturers.ContainsKey(courseId))
                    {
                        lecturers[courseId] = new List<string>();
                    }
                    lecturers[courseId].Add(lecturerName); // Add lecturer name to the course ID
                }
            }
            return lecturers; // Return populated dictionary
        }

        // Method to assign a lecturer to a new course
        public void AssignLecturerToCourse(string lecturerName, int newCourseId)
        {
            
            // If the new course ID doesn't have a list, create one
            if (!lecturers.ContainsKey(newCourseId))
            {
                lecturers[newCourseId] = new List<string>();
            }
            lecturers[newCourseId].Add(lecturerName); // Assign lecturer to the new course

            UpdateLecturerFile(); // Update file to save changes
            Console.WriteLine($"Lecturer {lecturerName} has been assigned to course ID {newCourseId}.");
        }

        // Update the file with the current lecturer data using StreamWriter
        private void UpdateLecturerFile()
        {
            using (StreamWriter writer = new StreamWriter(FilePath, false)) // Overwrite file (false parameter)
            {
                foreach (var course in lecturers)
                {
                    foreach (var lecturer in course.Value)
                    {
                        writer.WriteLine($"{course.Key}, {lecturer}"); // Write course ID and lecturer name to file
                    }
                }
            }
        }


        public void DisplayAllLecturers() //displays all the lecturers at the start so you can see which one to move
        {
            Console.WriteLine("Lecturers by Course:");
            foreach (var course in lecturers)
            {
                int courseId = course.Key;
                List<string> lecturerList = course.Value;

                Console.WriteLine($"\nCourse ID: {courseId}");
                if (lecturerList.Count > 0)
                {
                    Console.WriteLine("Lecturers:");
                    foreach (var lecturer in lecturerList)
                    {
                        Console.WriteLine($"\t{lecturer}");
                    }
                }
                else
                {
                    Console.WriteLine("No lecturers assigned.");
                }
            }
        }

        public bool LecturerExists(string lecturerName)
        {
            // Loop through each list of lecturers in the dictionary
            foreach (var lecturerList in lecturers.Values)
            {
                // Check if the lecturer's name exists in the current list
                foreach (var lecturer in lecturerList)
                {
                    if (lecturer == lecturerName)
                    {
                        return true; // Return true if the lecturer is found
                    }
                }
            }
            return false; // Return false if no matching lecturer is found
        }

        public void assignNewCourse()
        {
            AssignLecturer lecturerCourse = new AssignLecturer(); // Initialize lecturer manager to handle lecturer data

            Console.WriteLine("Enter the lecturers name to assign:");
            string lecturerName = Console.ReadLine();

            // Verify if the lecturer exists in the file
            if (!lecturerCourse.LecturerExists(lecturerName))
            {
                Console.WriteLine("Lecturer does not exist");
                return;
            }

            Console.WriteLine("Enter the course ID to assign the lecturer to:");
            if (int.TryParse(Console.ReadLine(), out int newCourseId)) // Validate course ID input
            {
                lecturerCourse.AssignLecturerToCourse(lecturerName, newCourseId); // Assign lecturer to course
            }
            else
            {
                Console.WriteLine("Invalid course ID. Please enter a numeric value.");
            }

        }
    }
}