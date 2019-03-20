using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency.BE
{
   public class Report
    {
        public int NumReport { get; set; }
        public CallCenter callcanter { get; set; }
        public DateTime Time { get; set; }
        public Address adress { get; set; }
        public int NumOfBombs { get; set; }
        public Report(CallCenter callcanter, DateTime time, Address adress, int numOfBombs)
        {
            this.callcanter = callcanter;
            Time = time;
            this.adress = adress;
            NumOfBombs = numOfBombs;
        }
    }
}
