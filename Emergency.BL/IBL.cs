using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency.BE;
namespace Emergency.BL
{
    public interface IBL
    {
        //Analyst
        /// <summary>
        /// func that add a analyst to the system 
        /// </summary>
        /// <param name="analyst"></param>
        void AddAnalyst(analyst analyst);
        /// <summary>
        /// func that delete a analyst from the system
        /// </summary>
        /// <param name="analyst"></param>
        void DeleteAnalyst(analyst analyst);
        /// <summary>
        /// Func that update a analyst
        /// </summary>
        /// <param name="analyst"></param>
        void UpdateAnalyst(analyst analyst);
        //callcenter
        /// <summary>
        /// func that add a callcenter to the system 
        /// </summary>
        /// <param name="callCenter"></param>
        void AddCallCenter(CallCenter callCenter);
        /// <summary>
        /// func that delete a callcenter from the system
        /// </summary>
        /// <param name="callCenter"></param>
        void DeleteCallCenter(CallCenter callCenter);
        /// <summary>
        /// Func that update a callcenter
        /// </summary>
        /// <param name="callCenter"></param>
        void UpdateCallCenter(CallCenter callCenter);
        //report
        /// <summary>
        /// func that add a report to the system
        /// </summary>
        /// <param name="report"></param>
        void AddReport(Report report);
        /// <summary>
        /// func that delete a report from the system
        /// </summary>
        /// <param name="report"></param>
        void DeleteReport(Report report);
        /// <summary>
        /// Func that update a report
        /// </summary>
        /// <param name="report"></param>
        void UpdateReport(Report report);
        //lists
        /// <summary>
        /// return list of all the analysts in the system
        /// </summary>
        /// <returns></returns>
        List<analyst> GetAnalysts();
        /// <summary>
        /// return list of all the callcenters in the system
        /// </summary>
        /// <returns></returns>
        List<CallCenter> GetCallCenters();
        /// <summary>
        /// return list of all the reports in the system
        /// </summary>
        /// <returns></returns>
        List<Report> GetReports();
        //another functions

    }
}
