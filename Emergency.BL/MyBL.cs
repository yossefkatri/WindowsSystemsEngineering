using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency.BE;
using Emergency.DAL;
using Emergency.BL.MapQuestAPI;
namespace Emergency.BL
{
    class MyBL : IBL
    {
        private IDal Dal = FactoryDal.getDal();
        public void AddAnalyst(analyst analyst)
        {
            CheckAnalyst(analyst);
            Dal.AddAnalyst(analyst);
        }//

        public void AddCallCenter(CallCenter callCenter)
        {
            CheckCallCenter(callCenter);
            Dal.AddCallCenter(callCenter);
        }//

        public void AddReport(Report report)
        {
            CheckReport(report);
            report.coordinates=geocodingApi.ConvertToCoordinates(report.adress);
            if(!GetReports().Exists(T=>Math.Abs((T.Time-report.Time).Minutes)<10&&(T.adress.Equals(report.adress)))||report.numOfMinutes==-1)
                Dal.AddReport(report);
        }//

        public void DeleteAnalyst(analyst analyst)
        {
            if (!GetAnalysts().Exists(T => T.Id == analyst.Id))
                throw new Exception("the analyst does not exist");
            Dal.DeleteAnalyst(analyst);
        }//
        public void DeleteCallCenter(CallCenter callCenter)
        {
            if (!GetCallCenters().Exists(T => T.Id == callCenter.Id))
                throw new Exception("the analyst does not exist");
            Dal.DeleteCallCenter(callCenter);
        }//

        public void DeleteReport(Report report)
        {
            if (!GetReports().Exists(T => T.NumReport == report.NumReport))
                throw new Exception("the analyst does not exist");
            Dal.DeleteReport(report);
        }//

        public List<analyst> GetAnalysts()
        {
            return Dal.GetAnalysts();
        }//

        public List<CallCenter> GetCallCenters()
        {
            return Dal.GetCallCenters();
        }//

        public List<Report> GetReports()
        {
            return Dal.GetReports();
        }//

        public void UpdateAnalyst(analyst analyst)
        {
            CheckAnalyst(analyst);
            if (!GetAnalysts().Exists(T => T.Id == analyst.Id))
                throw new Exception("the analyst does not exist");
            Dal.UpdateAnalyst(analyst);
        }//

        public void UpdateCallCenter(CallCenter callCenter)
        {
            CheckCallCenter(callCenter);
            if (!GetCallCenters().Exists(T => T.Id == callCenter.Id))
                throw new Exception("the analyst does not exist");
            Dal.UpdateCallCenter(callCenter);
        }//

        public void UpdateReport(Report report)
        {
            CheckReport(report);
            report.coordinates = geocodingApi.ConvertToCoordinates(report.adress);
            if (!GetReports().Exists(T => T.NumReport == report.NumReport))
                throw new Exception("the analyst does not exist");
            if (!GetReports().Exists(T => Math.Abs((T.Time - report.Time).Minutes) < 10 && (T.adress.Equals(report.adress))) || report.numOfMinutes == -1)
                Dal.UpdateReport(report);

        }//
        public static bool IdCheck(string id)
        {
            if (id == null)
                return false;

            int tmp, count = 0;

            if (!(int.TryParse(id, out tmp)) || id.Length != 9)
                return false;

            int[] id_12_digits = { 1, 2, 1, 2, 1, 2, 1, 2, 1 };
            id = id.PadLeft(9, '0');

            for (int i = 0; i < 9; i++)
            {
                int num = Int32.Parse(id.Substring(i, 1)) * id_12_digits[i];

                if (num > 9)
                    num = (num / 10) + (num % 10);

                count += num;
            }

            return (count % 10 == 0);
        }//
        public static void CheckAnalyst(analyst analyst)
        {

            if (!analyst.PrivateName.All(x => char.IsLetter(x) || x == ' '))
                throw new Exception("private name isnt correct");

            if (!analyst.FamilyName.All(x => char.IsLetter(x) || x == ' '))
                throw new Exception("family name isnt correct");

            if ((analyst.Id != null) && !IdCheck(analyst.Id))
                throw new Exception("id isnt correct");

            if (analyst.Phone.Length != 10 || !analyst.Phone.All(Char.IsDigit))
                throw new Exception("phone isnt correct");
        }//
        public static void CheckCallCenter(CallCenter callCenter)
        {

            if (!callCenter.PrivateName.All(x => char.IsLetter(x) || x == ' '))
                throw new Exception("private name isnt correct");

            if (!callCenter.FamilyName.All(x => char.IsLetter(x) || x == ' '))
                throw new Exception("family name isnt correct");

            if ((callCenter.Id != null) && !IdCheck(callCenter.Id))
                throw new Exception("id isnt correct");

            if (callCenter.Phone.Length != 10 || !callCenter.Phone.All(Char.IsDigit))
                throw new Exception("phone isnt correct"); 
        }//
        public static void CheckReport(Report report)
        {
            if (!report.adress.City.All(x => char.IsLetter(x) || x == ' '))
                throw new Exception("city isnt correct");

            if (!report.adress.Street.All(x => char.IsLetter(x) || x == ' '))
                throw new Exception("street isnt correct");

            if (!report.adress.NumOfHome.All(char.IsDigit))
                throw new Exception("number of home isnt correct");
            IBL bl = FactoryBL.GetBL();
            if (!bl.GetCallCenters().Exists(T => T.Id == report.callcanter.Id))
                throw new Exception("the call center isnt true");
            if (report.NumOfBombs < 0)
                throw new Exception("the nember of bombs isnt correct");
        }//
        public static double Distance(Coordinates a, Coordinates b)
        {
            return Math.Sqrt(Math.Pow(a.Latitude - b.Latitude, 2) + Math.Pow(a.Longitude - b.Longitude, 2));
        }//
        public static Coordinates averge(List<Report> reports)
        {
            double x = reports.Average(T=>T.coordinates.Longitude);
            double y = reports.Average(T => T.coordinates.Latitude);
            return new Coordinates(y,x);
        }//
        public IEnumerable<Coordinates> kmeans(int k, List<Report> reports,List<Coordinates> B)
        {
            int[] C = new int[reports.Count];
            for(int j = 0; j < reports.Count; j++)
            {
                int min = 0;
                for (int i = 0; i < B.Count; i++)
                    if (Distance(B[i], reports[j].coordinates) < Distance(B[min], reports[j].coordinates))
                        min = i;
                C[j] = min;
            }
            bool stop=true;
            for (int i = 0; i < B.Count; i++)
            {
                List<Report> rB=new List<Report>();
                for (int j = 0; j < reports.Count; j++)
                {
                    if (B[i].Equals(B[C[j]]))
                    {
                        rB.Add(reports[j]);
                    }
                }
                Coordinates excepted = averge(rB);
                if (!B[i].Equals(excepted))
                {
                    B[i] = excepted;
                    stop = false;
                }
            }
            if (!stop)
            {
                return kmeans(k, reports, B);
            }
            else
            {
                return B; 
            }
        }//
        public IEnumerable<Coordinates> kmeanStart(int k)
        {
            List<Coordinates> B = new List<Coordinates>();
            for (int i = 0; i < k; i++)
            {
            B[i] = new Coordinates(0, i);
            }
            return kmeans(k,GetReports(),B);
        }//
    }
}
