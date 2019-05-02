using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Emergency.BE
{
      public class User
    {
        public string FamilyName { get; set; }
        public string PrivateName { get; set; }
        public ImageSource Face { get; set; }
        public string Id { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }

        public User(string familyName, string privateName, ImageSource face, string id, DateTime dOB, Gender gender, string phone)
        {
            FamilyName = familyName;
            PrivateName = privateName;
            Face = face;
            Id = id;
            DOB = dOB;
            Gender = gender;
            Phone = phone;
        }
    }
}
