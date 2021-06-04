using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.Base_Classes
{
    abstract public class Human
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public override string ToString()
        {
            return $@"ID : {Id}
Name : {Name}
Surname : {Surname}
Age : {Age}
City : {City}
Phone number : {PhoneNumber}";
        }
    }
}
