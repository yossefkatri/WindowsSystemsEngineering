using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Media;

namespace Emergency.BE
{
    public class CallCenter: User
    {
        public int HashPassword { get; set; }
        public CallCenter(string familyName, string privateName, FileStyleUriParser face, string id, DateTime dOB, Gender gender, string phone,string password):base( familyName,  privateName,  face,  id,  dOB,  gender,  phone)
        {
            HashPassword = password.GetHashCode();
        }
    }

}
