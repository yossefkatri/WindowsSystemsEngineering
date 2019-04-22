using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency.BE;
namespace Emergency.DAL
{
    interface IDal
    {
        void AddAnalyst(analyst analyst);
        void DeleteAnalyst(analyst analyst);
        void UpdateAnalyst(analyst analyst);
        
        void AddCallCenter(CallCenter CallCenter);
        void DeleteCallCenter(CallCenter CallCenter);
        void UpdateCallCenter(CallCenter CallCenter);

        void AddReport(Report Report);
        void DeleteReport(Report Report);
        void UpdateReport(Report Report);
        //lists
        List<analyst> analystsCollection();
        List<CallCenter> CallCenterCollection();
        List<Report> ReportsCollection();
    }
}
