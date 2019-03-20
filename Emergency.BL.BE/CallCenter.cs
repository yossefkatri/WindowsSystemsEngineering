using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Emergency.BE
{
    public class CallCenter: User
    {
        public CallCenter(string familyName, string privateName, ImageSource face, int id, DateTime dOB, Gender gender, string phone):base( familyName,  privateName,  face,  id,  dOB,  gender,  phone)
        {

        }
    }

}
