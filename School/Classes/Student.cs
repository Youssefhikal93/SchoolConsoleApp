using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace School.Classes
{
    class Student : Person
    {
        private int _studentAge { get; set; }

        public Student(string studentFirstName, string studentLastName, DateOnly studentDateOfBirth)
            : base(studentFirstName, studentLastName, studentDateOfBirth)
        {
            ValidateStudentBirthDate();
        }

        

        private void ValidateStudentBirthDate()
        {
            this._studentAge = ValidateBirthDate(_dateOfBirth);
            // Validate the student's age
            if (_studentAge < 4)
            {
                throw new ArgumentException($"Student age is too young");
            }
            else if (_studentAge > 90)
            {
                throw new ArgumentException("Student age is too old");
            }
        }

        public override string ToString()
        {
            return $"Studnet Details:\nFullname:{_firstName} {_lastName}\nStudent id: {Id} \nBirthdate: {_dateOfBirth}";
        }
    }
}
