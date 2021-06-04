using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.Classes
{
    public class Notification
    {
        public string From { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return $@"From : {From}
Time : {Time.ToLongDateString()}
Description : {Description}";
        }
    }
}
