using ProjectFinal.Base_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.Classes
{
    public class Worker : Human
    {
        public List<Notification> notifications { get; set; }
        public List<Cv> Cvs { get; set; }
        public override string ToString()
        {
            return $@"{base.ToString()}
Cv : {Cvs}";
        }
    }
}
