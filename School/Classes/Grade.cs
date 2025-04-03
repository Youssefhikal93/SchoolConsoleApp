using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace School.Classes
{
    class Grade
    {
        public Guid GradeId { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }

        public GradeType GradeSign { get; set; }

        public Grade(GradeType grade,Course course, Student student)
        {
            this.GradeSign = grade;
            this.GradeId = new Guid();
            this.Course = course;
            this.Student = student;
        }

        public override string ToString()
        {
            switch (GradeSign)
            {
                case GradeType.A:
                    return "A- Perfect, full mark";
                case GradeType.B:
                    return "B- Good job!";
                case GradeType.C:
                    return "C- Not bad, you can do better";
                case GradeType.D:
                    return "D- You just made it kid!";
                case GradeType.E:
                    return "E- Very bad, you should study more.";
                case GradeType.F:
                    return "F- Are you even with us in the class?";
                default:
                    return "Unknown grade";
            }
        }

        public enum GradeType
        {
            A,
            B,
            C,
            D,
            E,
            F
        }
    }
}