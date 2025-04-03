using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace School.Classes
{
    class Course
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public List<Student>? Student { get; set; }
        public Teacher? Teacher { get; set; }

        public Course(string name)
        {
            this.CourseId = Guid.NewGuid();
            this.Name = name;
            this.Student = new List<Student>();
        }

        public Course(string name, Student student) : this(name)
        {
            Student.Add(student);
        }

        public Course(string name, Student student, Teacher teacher) : this(name)
        {
            this.Teacher = teacher;
            Student.Add(student);
        }

        public override string ToString()
        {
            return $"Course Details:\nCourse Name: {Name}\nCourse ID: {CourseId}\nTeacher: {Teacher?.ToString() ?? "No teacher assigned"}\nStudents: {(Student != null && Student.Count > 0 ? string.Join(", ", Student) : "No students enrolled")}";
        }
    }
}
