using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency.BE;
using Emergency.BL;
namespace Emergency.model
{
    class CallCenterModel
    {
        IBL BL = FactoryBL.GetBL();
        public CallCenter CallCenters{ get; set; }
        public void AddCallCenter(CallCenter callCenter)
        {
            CallCenters.Add(callCenter);
        }
        public void RemoveCallCenter(CallCenter callCenter)
        {
            CallCenters.Remove(callCenter);
        }
    }
}
