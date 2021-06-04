using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.Base_Classes
{
    abstract public class Base
    {
        public int Count { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $@"Count : {Count}
Name : {Name}";
        }
    }
}
