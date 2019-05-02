using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency.BL
{
    public class FactoryBL
    {
        static IBL instance = null;
        public static IBL GetBL()
        {
            if (instance == null)
                instance = new MyBL();
            return instance;
        }
    }
}
