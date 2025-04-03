using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace School.Classes
{
    class Person
    {
        public Guid Id { get; set; }
        protected string _firstName { get; set; }
        protected string _lastName { get; set; }

        protected DateOnly _dateOfBirth { get; set; }


        public Person(string firstName, string lastName, DateOnly dateOfBirth)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._dateOfBirth = dateOfBirth;
            this.Id = Guid.NewGuid();
        }


        public void GetAge()
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            int todaysYear = today.Year;
            int todaysMonth = today.Month;
            int todaysDay = today.Day;

            int birthYear = _dateOfBirth.Year;
            int birthMonth = _dateOfBirth.Month;
            int birthDay = _dateOfBirth.Day;

            int years = todaysYear - birthYear;

            // Calculate the age in months
            int months = todaysMonth - birthMonth;
            if (months <= 0)
            {
                months += 12;  
                years--;        
            }

            // Calculate the age in days
            int days = todaysDay - birthDay;
            if (days < 0)
            {
                
                var previousMonth = today.AddMonths(-1);  
                days += DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month);
                months--;  
            }


            Console.WriteLine($"{_firstName} {_lastName} age is {years} years {months} months and {days} days.");
        }


        protected int ValidateBirthDate(DateOnly dateOfBirth)
        {

            DateOnly today = DateOnly.FromDateTime(DateTime.Today);

            int age = today.Year - dateOfBirth.Year;

            // Check if the person has already had their birthday this year
            if (today < dateOfBirth.AddYears(age))
            {
                age--;
            }

            return age;

            

        }

        public override string ToString()
        {
            return $"Person Details:\nFullname:{_firstName} {_lastName}\nPerson id: {Id} \nBirthdate: {_dateOfBirth}";
        }
    }
}
