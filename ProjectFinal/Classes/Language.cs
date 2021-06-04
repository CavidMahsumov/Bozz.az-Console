using ProjectFinal.Base_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.Classes
{
    public class Language : Base
    {
        public string Level { get; set; }
        public override string ToString()
        {
            return $@"{base.ToString()}
Level : {Level}";
        }
    }
}
