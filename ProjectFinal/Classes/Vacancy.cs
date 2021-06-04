using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.Classes
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int PracticeRequeriment { get; set; }
        public string WorkPlace { get; set; }
        public int AgeRequeriment { get; set; }
        public string EmployerName { get; set; }
        public override string ToString()
        {
            return $@"ID : {Id}
Type : {Type}
Practice : {PracticeRequeriment}
Age : {AgeRequeriment}
Work adress : {WorkPlace}
Employeer name : {EmployerName}";
        }
    }
}
