using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Classes
{
    interface ISchool
    {
        string Name { get; set; }
        List<Student> Students { get; set; }
        List<Teacher> Teachers { get; set; }
        List<Grade> Grades { get; set; }
        Dictionary<Guid,Course> Courses { get; set; }

        
    }
}

