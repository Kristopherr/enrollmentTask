using enrollmentTask;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enrollmentTask
{
    public class loadfiles
    {
        /// <summary>
        /// Kristopher mann
        /// Class that stores the data files as dictionaries.
        /// </summary>
            
        public static void DisplayDataList()
        {
            var departments = new Dictionary<int, string>();
            foreach (var line in File.ReadLines("../../../Departments.txt"))
            {
                var parts = line.Split(','); // splits the file into 2 sections via the comma, 1,Computing. will become [0] - 1, and [1] - computing
                int departmentId = int.Parse(parts[0].Trim()); // Assigns the number as departmentID
                string departmentName = parts[1].Trim(); // Assigns the text within the file to DepartmentName
                departments[departmentId] = departmentName;
            }

            // Step 2: Read the courses file
            var courses = new Dictionary<int, List<(int courseId, string courseName)>>(); //first int is departmentId, then returns a tuuple for course name and id.
            foreach (var line in File.ReadLines("../../../Course.txt"))
            {
                var parts = line.Split(",");
                int departmentId = int.Parse(parts[0].Trim());
                int courseId = int.Parse(parts[1].Trim());
                string courseName = parts[2].Trim();

                if (!courses.ContainsKey(departmentId)) // checks if courses DOES NOT contain a key for department
                {
                    courses[departmentId] = new List<(int, string)>();
                }
                courses[departmentId].Add((courseId, courseName));
            }

            // Read the students file
            var students = new Dictionary<int, List<string>>();
            foreach (var line in File.ReadLines("../../../Student.txt"))
            {
                var parts = line.Split(",");
                int courseId = int.Parse(parts[0].Trim());
                string studentName = parts[1].Trim();

                if (!students.ContainsKey(courseId))// checks if student DOES NOT contain a key for courses
                {
                    students[courseId] = new List<string>();
                }
                students[courseId].Add("\n \t" + studentName);
            }

            //creating a data list for lecturers
            var lecturers = new Dictionary<int, List<string>>();
            foreach (var line in File.ReadLines("../../../Lecturers.txt"))
            {
                var parts = line.Split(',');
                int courseID = int.Parse(parts[0].Trim());
                string lecturerName = parts[1].Trim();

                if (!lecturers.ContainsKey(courseID))
                {
                    lecturers[courseID] = new List<string>();
                    // adds lecturers name with a courseID as the key
                }
                lecturers[courseID].Add(lecturerName);


            }

            // Slinking the dataa together with the keys
            var linkedData = new Dictionary<string, Dictionary<string, (List<string> Students, List<string> Lecturers)>>();

            foreach (var department in departments)
            {
                string departmentName = department.Value;
                int departmentId = department.Key;

                if (!linkedData.ContainsKey(departmentName))
                {
                    linkedData[departmentName] = new Dictionary<string, (List<string>, List<string>)>();
                }

                if (courses.ContainsKey(departmentId))
                {
                    foreach (var course in courses[departmentId])
                    {
                        string courseName = course.courseName;
                        int courseId = course.courseId;

                        // Get students for the course
                        List<string> courseStudents = students.ContainsKey(courseId) ? students[courseId] : new List<string>();

                        // Get lecturers for the course
                        List<string> courseLecturers = lecturers.ContainsKey(courseId) ? lecturers[courseId] : new List<string>();

                        linkedData[departmentName][courseName] = (courseStudents, courseLecturers);
                    }
                }
            }


            

            // Display the linked data
            /*foreach (var department in linkedData)
            {
                Console.WriteLine($"Department: {department.Key}");
                foreach (var course in department.Value)
                {
                    // this will display them in a format of course then the students within this course
                    Console.WriteLine($"Course: {course.Key}");
                    Console.WriteLine("Students: " + string.Join(" ", course.Value));
                }
            }*/

            foreach (var department in linkedData)
            {
                Console.WriteLine($"Department: {department.Key}"); // Print department name
                foreach (var course in department.Value)
                {
                    Console.WriteLine($"Course: {course.Key}"); // Print course name

                    List<string> courseStudents = course.Value.Students; //get all students in the course
                    List<string> courseLecturers = course.Value.Lecturers;//get all lectueres that are teaching the courses

                    // Print students, joining them with commas, or show "None" if there are no students
                    if (courseStudents.Count > 0)
                        Console.WriteLine("Students: " + string.Join(", ", courseStudents));
                    else
                        Console.WriteLine("Students: None");

                    // Print lecturers, joining them with commas, or show "None" if there are no lecturers
                    if (courseLecturers.Count > 0)
                        Console.WriteLine("Lecturers: " + string.Join(", ", courseLecturers));
                    else
                        Console.WriteLine("Lecturers: None");
                }
            }
            
        }
        
    }
}
