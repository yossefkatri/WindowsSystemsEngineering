using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency.BE;
using Emergency.BL;
namespace Emergency.model
{
    class AnalystModel
    {
        IBL BL = FactoryBL.GetBL();
        public analyst analyst{ get; set; }
        public static void Addanalyst(analyst analyst)
        {
            //add analyst to the list


        }
        public static void Removeanalyst(analyst analyst)
        {
            //remove analyst to the list
        }
    }
}
