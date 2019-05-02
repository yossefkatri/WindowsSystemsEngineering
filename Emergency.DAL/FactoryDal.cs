using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency.DAL
{
    public class FactoryDal
    {
        
            static IDal instance = null;
            public static IDal getDal()
            {
            if (instance == null)
                instance = new MyDal();
                return instance;
            }
    }
    
}
