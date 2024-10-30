using EnrollmentTask;
using System;

namespace enrollmentTask {
	public class Menu
	{
		public Menu()
		{
		}

		public static void DisplayMenu()
		{
			int choice = 0;

			do
			{
				Console.WriteLine("\t xxxxxxMENUxxxxxx");
				Console.WriteLine("1. Assign lecturer to a course");
				Console.WriteLine("2. Display Lecturers");
				Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Display All");
                Console.WriteLine("5. Exit program");
				choice = int.Parse(Console.ReadLine());

				switch(choice)
				{
					case 1:
						/*  tried something and couldnt really get it to work
						 Console.WriteLine("\t Add Lecturer");
						Person lecturer1 = new Person();
						lecturer1.GetFirstName();
						lecturer1.GetLastName();
						lecturer1.GetAge();*/
						AssignLecturer assignNewCourses1 = new AssignLecturer();
						assignNewCourses1.DisplayAllLecturers();
						assignNewCourses1.assignNewCourse();


                        break;
					case 2: 
						AssignLecturer display = new AssignLecturer();
						display.DisplayAllLecturers();
						break;
					case 3: 
						Console.WriteLine("");
						break;
					case 4: 
						Console.WriteLine("");
                        loadfiles.DisplayDataList();
						Console.ReadKey();
						break;
					case 5: 
						Console.WriteLine("");
						Console.ReadKey();
						break;
					default: 
						Console.WriteLine("Enter a valid input");
						break;
				}

			} while (choice != 5);
		}
	}
}
