using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency.BE;
using Emergency.BL;
namespace Emergency.model
{
    class ReportsModel
    {
        IBL BL = FactoryBL.GetBL();
        public List<Report> reports{ get; set; }
        public ReportsModel()
        {
            reports = new List<Report>(BL.GetReports());
        }
        public void AddReport(CallCenter Reporting,DateTime time,Address address,int NumOfBombs)
        {
            reports.Add(new Report(Reporting,time,address,NumOfBombs));
        }
        public void RemoveReport(int numReport)
        {
            reports.RemoveAll(T=>T.NumReport==numReport);
        }
    }
}
