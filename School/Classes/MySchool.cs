using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static School.Classes.Grade;

namespace School.Classes
{
    class MySchool : ISchool
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Grade> Grades { get; set; }
        public Dictionary<Guid, Course> Courses { get; set; } 
        public MySchool(string name)
        {
            this.Name = name;
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
            this.Grades = new List<Grade>();
            this.Courses = new Dictionary<Guid, Course>(); 
        }

        public bool HasCourse(Guid courseId)
        {
            return Courses.ContainsKey(courseId); // because we added the GUID as the key in the dictionary
            //return Courses.Values.Any(c => c.CourseId.Equals(courseId)); // another way to get the value and compare it
        }

        public void AddCourse(Course course)
        {
         
            if (Courses.TryGetValue(course.CourseId,out _))
            {
                throw new ArgumentException($"Course with ID {course.CourseId} already exists.");
            }

            Courses.Add(course.CourseId, course);
        }

        public void RemoveCourse(Guid courseId)
        {

            bool existingCourse =Courses.TryGetValue(courseId, out var course);

            if (!existingCourse)
            {
                throw new ArgumentException($"Course with ID {courseId} does not exist.");
            }

            Courses.Remove(courseId);
        }


        public void AddStudent(Student student)
        {
            var isStudentExist =IsStudentEnrolled(student.Id);

            if (isStudentExist)
            {
                throw new ArgumentException("Student already exist!");
            }

            this.Students.Add(student);
           
        }

        public void RemoveStudent(Student student)
        {
            var isStudentExist = IsStudentEnrolled(student.Id);

            if (!isStudentExist)
            {
                throw new ArgumentException("Student dosent exist to remove");
            }
            this.Students.Remove(student);
        }

        public void RemoveStudentFromCourse(Guid courseId,Guid studentId)
        {
            var isStudentExist = this.IsStudentEnrolled(studentId);
            var isCourseExist = this.HasCourse(courseId);
            if(!isCourseExist || !isStudentExist)
            {
                throw new ArgumentException("Student or course not ecist!");
            }

            var student = this.GetStudentById(studentId);
            var course = Courses[courseId];

            course.Student.Remove(student);
            
        }

        public bool IsStudentEnrolled(Guid studentId)
        {
            bool IsEnrolled = Students.Any(s => s.Id.Equals(studentId));
            return IsEnrolled;
        }

        public bool IsCourseAssiociotedWithStudent(Guid studentId, Guid courseId)
        {
            bool isStudentExistInSchool = Students.Any(s => s.Id.Equals(studentId));
            bool isCourseEnrolledInTheSchool = Courses.ContainsKey(courseId);

            if (!isStudentExistInSchool)
            {
                throw new ArgumentException($"Student with ID {studentId} does not exist in the school.");
            }

            if (!isCourseEnrolledInTheSchool)
            {
                throw new ArgumentException($"Course with ID {courseId} does not exist in the school.");
            }

            var course = Courses[courseId];
            bool isStudnetEnrolledInTheCourse = course.Student.Any(e => e.Id.Equals(studentId));

            if (isStudnetEnrolledInTheCourse)
            {

                Console.WriteLine("studnet linked to the course and enrolled in the school");
                return true;
            }
            else
            {
                throw new ArgumentException($"Student with ID {studentId} is not enrolled in the course with ID {courseId}.");
            }
        }




        public void EnrollStudentToCourse(Guid studentId, Guid courseId)
        {
            var isExistingStudent = this.IsStudentEnrolled(studentId);
            var isExsitingCourse= this.HasCourse(courseId);

            if (!isExistingStudent || !isExsitingCourse)
            {
                throw new AggregateException("Student or course not found!");
            }

            Course existingCourse = this.GetCourseById(courseId);
            Student existingStudent  =this.GetStudentById(studentId);

            existingCourse.Student.Add(existingStudent);

        }

        public void SetGrade(Grade.GradeType gradeType, Guid courseId, Guid studentId)
        {
            var isStudentExist = this.IsStudentEnrolled(studentId);
            var isCourseExist = this.HasCourse(courseId);
            var isEnrolledinTheCourse = this.IsCourseAssiociotedWithStudent(studentId, courseId);
            if (!isCourseExist || !isStudentExist || !isEnrolledinTheCourse)
            {
                throw new ArgumentException("Student or course not exist!");
            }

            var student = this.GetStudentById(studentId);
            var course = Courses[courseId];
            Grade newGrade = new Grade(gradeType, course, student);


            this.Grades.Add(newGrade);
        }

        public void GetGrades(Guid studentId)
        {

            var gradeForStudent = this.Grades.FirstOrDefault(g => g.Student.Id.Equals(studentId));
        
            Console.WriteLine($"Student name: {gradeForStudent.Student.ToString()}\nYour grade : {gradeForStudent.GradeSign}\ntheCourse: {gradeForStudent.Course.Name}");
        }

        public void RemoveGrade(Guid courseId, Guid studentId)
        {
            var isStudentExist = this.IsStudentEnrolled(studentId);
            var isCourseExist = this.HasCourse(courseId);
            var isEnrolledinTheCourse = this.IsCourseAssiociotedWithStudent(studentId, courseId);
            if (!isCourseExist || !isStudentExist || !isEnrolledinTheCourse)
            {
                throw new ArgumentException("Student or course not exist!");
            }

            var student = this.GetStudentById(studentId);
            var course = Courses[courseId];
            var gradeToRemove = this.Grades.FirstOrDefault(g => g.Student.Equals( studentId) && g.Course.Equals( courseId));

            if (gradeToRemove != null)
            {
                this.Grades.Remove(gradeToRemove);
            }
            else
            {
                throw new ArgumentException("Grade not found for the given student and course.");
            }
        }

        // Teachears methods 

        public void AddTeacher(Teacher teacher)
        {
            if (Teachers.Any(t => t.Id == teacher.Id))
            {
                throw new ArgumentException("Teacher already exists!");
            }

            this.Teachers.Add(teacher);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            if (!Teachers.Any(t => t.Id == teacher.Id))
            {
                throw new ArgumentException("Teacher does not exist!");
            }

            this.Teachers.Remove(teacher);
        }

        public List<Teacher> GetTeachers()
        {
            return this.Teachers;
        }

        public void AssignTeacherToCourse(Guid teacherId, Guid courseId)
        {
            var teacher = this.Teachers.FirstOrDefault(t => t.Id == teacherId);
            if (teacher == null)
            {
                throw new ArgumentException("Teacher does not exist!");
            }

            var course = this.GetCourseById(courseId);
            if (course == null)
            {
                throw new ArgumentException("Course does not exist!");
            }

            course.Teacher = teacher;
        }

        public void RemoveTeacherFromCourse(Guid teacherId, Guid courseId)
        {
            var course = this.GetCourseById(courseId);
            if (course == null)
            {
                throw new ArgumentException("Course does not exist!");
            }

            if (course.Teacher == null || course.Teacher.Id != teacherId)
            {
                throw new ArgumentException("Teacher is not assigned to this course!");
            }

            course.Teacher = null;
        }
        private Student GetStudentById(Guid studentId)
        {
            
            var  studnet = this.Students.FirstOrDefault(s => s.Id.Equals(studentId));

            if(studnet == null)
            {
                Console.WriteLine("Student not found");
            }

            return studnet;
        }

        private Course GetCourseById(Guid courseId)
        {
            var course = this.Courses.GetValueOrDefault(courseId);
            if (course == null)
            {
                Console.WriteLine("course not found");
            }
            return course;
        }

        


    }
}