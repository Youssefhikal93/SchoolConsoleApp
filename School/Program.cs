
using School.Classes;
using System;
using static School.Classes.Grade;

namespace SchoolExcersice
{
    internal class Program
    {
  
        static MySchool mySchool = new MySchool("My School");

        static void Main(string[] args)
        {
            try
            {
                MainMenu();

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message); ;
            }
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Display teachers/students/courses");
                Console.WriteLine("2. Add teacher/student/course");
                Console.WriteLine("3. Withdraw student/teacher/course");
                Console.WriteLine("4. Show/Remove/Set grades");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayMenu();
                        break;
                    case "2":
                        AddMenu();
                        break;
                    case "3":
                        WithdrawMenu();
                        break;
                    case "4":
                        GradesMenu();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Display Menu:");
                Console.WriteLine("1. Display teachers");
                Console.WriteLine("2. Display students");
                Console.WriteLine("3. Display courses");
                Console.WriteLine("4. Back to main menu");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayTeachers();
                        break;
                    case "2":
                        DisplayStudents();
                        break;
                    case "3":
                        DisplayCourses();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Add Menu:");
                Console.WriteLine("1. Add teacher");
                Console.WriteLine("2. Add student");
                Console.WriteLine("3. Add course");
                Console.WriteLine("4. Back to main menu");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTeacher();
                        break;
                    case "2":
                        AddStudent();
                        break;
                    case "3":
                        AddCourse();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void WithdrawMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Withdraw Menu:");
                Console.WriteLine("1. Withdraw teacher");
                Console.WriteLine("2. Withdraw student");
                Console.WriteLine("3. Withdraw course");
                Console.WriteLine("4. Back to main menu");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        WithdrawTeacher();
                        break;
                    case "2":
                        WithdrawStudent();
                        break;
                    case "3":
                        WithdrawCourse();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void GradesMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Grades Menu:");
                Console.WriteLine("1. Show grades");
                Console.WriteLine("2. Remove grade");
                Console.WriteLine("3. Set grade");
                Console.WriteLine("4. Back to main menu");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowGrades();
                        break;
                    case "2":
                        RemoveGrade();
                        break;
                    case "3":
                        SetGrade();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void DisplayTeachers()
        {
            Console.Clear();
            var teachers = mySchool.GetTeachers();
            foreach (var teacher in teachers)
            {
                Console.WriteLine(teacher);
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        static void DisplayStudents()
        {
            Console.Clear();
            foreach (var student in mySchool.Students)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        static void DisplayCourses()
        {
            Console.Clear();
            foreach (var course in mySchool.Courses.Values)
            {
                Console.WriteLine(course);
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        static void AddTeacher()
        {
            Console.Clear();
            Console.Write("Enter teacher first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter teacher last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter teacher date of birth (yyyy-mm-dd): ");
            DateOnly dateOfBirth = DateOnly.Parse(Console.ReadLine());
            Teacher teacher = new Teacher(firstName, lastName, dateOfBirth);
            mySchool.AddTeacher(teacher);
            Console.WriteLine("Teacher added successfully.");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        static void AddStudent()
        {
            Console.Clear();
            Console.Write("Enter student first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter student last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter student date of birth (yyyy-mm-dd): ");
            DateOnly dateOfBirth = DateOnly.Parse(Console.ReadLine());
            Student student = new Student(firstName, lastName, dateOfBirth);
            mySchool.AddStudent(student);
            Console.WriteLine("Student added successfully.");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        static void AddCourse()
        {
            Console.Clear();
            Console.Write("Enter course name: ");
            string courseName = Console.ReadLine();
            Course course = new Course(courseName);
            mySchool.AddCourse(course);
            Console.WriteLine("Course added successfully.");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        static void WithdrawTeacher()
        {
            Console.Clear();
            Console.Write("Enter teacher ID: ");
            Guid teacherId = Guid.Parse(Console.ReadLine());
            var teacher = mySchool.Teachers.FirstOrDefault(t => t.Id == teacherId);
            if (teacher != null)
            {
                mySchool.RemoveTeacher(teacher);
                Console.WriteLine("Teacher withdrawn successfully.");
            }
            else
            {
                Console.WriteLine("Teacher not found.");
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        static void WithdrawStudent()
        {
            Console.Clear();
            Console.Write("Enter student ID: ");
            Guid studentId = Guid.Parse(Console.ReadLine());
            var student = mySchool.Students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                mySchool.RemoveStudent(student);
                Console.WriteLine("Student withdrawn successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        static void WithdrawCourse()
        {
            Console.Clear();
            Console.Write("Enter course ID: ");
            Guid courseId = Guid.Parse(Console.ReadLine());
            if (mySchool.HasCourse(courseId))
            {
                mySchool.RemoveCourse(courseId);
                Console.WriteLine("Course withdrawn successfully.");
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        static void ShowGrades()
        {
            Console.Clear();
            Console.Write("Enter student ID: ");
            Guid studentId = Guid.Parse(Console.ReadLine());
            mySchool.GetGrades(studentId);
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        static void RemoveGrade()
        {
            Console.Clear();
            Console.Write("Enter course ID: ");
            Guid courseId = Guid.Parse(Console.ReadLine());
            Console.Write("Enter student ID: ");
            Guid studentId = Guid.Parse(Console.ReadLine());
            mySchool.RemoveGrade(courseId, studentId);
            Console.WriteLine("Grade removed successfully.");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        static void SetGrade()
        {
            Console.Clear();
            Console.Write("Enter course ID: ");
            Guid courseId = Guid.Parse(Console.ReadLine());
            Console.Write("Enter student ID: ");
            Guid studentId = Guid.Parse(Console.ReadLine());
            Console.Write("Enter grade (A-F): ");
            GradeType gradeType = Enum.Parse<GradeType>(Console.ReadLine(), true);
            mySchool.SetGrade(gradeType, courseId, studentId);
            Console.WriteLine("Grade set successfully.");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }
}
