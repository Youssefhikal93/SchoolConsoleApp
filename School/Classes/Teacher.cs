using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Classes
{
    class Teacher :Person
    {
        private int _teachersAge { get; set; }

        public Teacher(string teacherFirstName, string teacherLastName , DateOnly teacherDateOfBirth) :base(teacherFirstName, teacherLastName, teacherDateOfBirth)
        {
            ValidateTeacherBirthDate();
        }
        

        private void ValidateTeacherBirthDate()
        {

            this._teachersAge = ValidateBirthDate(this._dateOfBirth); 

            if(_teachersAge < 18)
            {
                throw new ArgumentException($"Teacher age is too young");
            }
            else if (_teachersAge > 90)
            {
                throw new ArgumentException("Teacher age is too old");
            }
        }

        public override string ToString()
        {
            return $"Teacher Details:\nFullname:{_firstName} {_lastName}\nTeacher id: {Id} \nBirthdate: {_dateOfBirth}";
        }
    }
}
