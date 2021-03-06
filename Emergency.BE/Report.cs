﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency.BE
{
  
   public class Report
    {
        public string NumReport { get; set; }
        public CallCenter callcanter { get; set; }
        public DateTime Time { get; set; }
        public Address adress { get; set; }
        public Coordinates coordinates { get; set; }
        public FileStyleUriParser Picture { get; set; }
        public int NumOfBombs { get; set; }
        public int numOfMinutes { get; set; }
        public Report(CallCenter callcanter, DateTime time, Address adress, int numOfBombs,int numMinutes,FileStyleUriParser p,Coordinates coordinates,string num)
        {
            this.NumReport = num;
            this.coordinates = coordinates;
            this.numOfMinutes = numMinutes;
            this.callcanter = callcanter;
            this.Time = time;
            this.adress = adress;
            this.NumOfBombs = numOfBombs;
            this.Picture = p;
        }
    }
}
