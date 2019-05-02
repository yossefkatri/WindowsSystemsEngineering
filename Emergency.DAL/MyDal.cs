using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency.BE;

namespace Emergency.DAL
{
    public class MyDal : IDal
    {
        public void AddAnalyst(analyst analyst)
        {
            throw new NotImplementedException();
        }

        public void AddCallCenter(CallCenter callCenter)
        {
            throw new NotImplementedException();
        }

        public void AddReport(Report report)
        {
            throw new NotImplementedException();
        }

        public void DeleteAnalyst(analyst analyst)
        {
            throw new NotImplementedException();
        }

        public void DeleteCallCenter(CallCenter callCenter)
        {
            throw new NotImplementedException();
        }

        public void DeleteReport(Report report)
        {
            throw new NotImplementedException();
        }

        public List<analyst> GetAnalysts()
        {
            throw new NotImplementedException();
        }

        public List<CallCenter> GetCallCenters()
        {
            throw new NotImplementedException();
        }

        public List<Report> GetReports()
        {
            throw new NotImplementedException();
        }

        public void UpdateAnalyst(analyst analyst)
        {
            throw new NotImplementedException();
        }

        public void UpdateCallCenter(CallCenter callCenter)
        {
            throw new NotImplementedException();
        }

        public void UpdateReport(Report report)
        {
            throw new NotImplementedException();
        }
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
        }
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
        }
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
        }
        public static void CheckReport(Report report)
        {
            if (!report.adress.City.All(x => char.IsLetter(x) || x == ' '))
                throw new Exception("city isnt correct");

            if (!report.adress.Street.All(x => char.IsLetter(x) || x == ' '))
                throw new Exception("street isnt correct");

            if (!report.adress.NumOfHome.All(char.IsDigit))
                throw new Exception("number of home isnt correct");
            IDal dal = FactoryDal.getDal();
            if (!dal.GetCallCenters().Exists(T => T.Id == report.callcanter.Id))
                throw new Exception("the call center isnt true");
            if (report.NumOfBombs < 0)
                throw new Exception("the nember of bombs isnt correct");
        }
    }
}
