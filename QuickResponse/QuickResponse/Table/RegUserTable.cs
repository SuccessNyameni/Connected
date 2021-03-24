using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace QuickResponse.Table
{
   
    public class RegUserTable
    {

       
        
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Surname { get; set; }
        public string TrusteeUserName { get; set; } 
        public string TrusteeSurname { get; set; }
        public string TrusteePhoneNumber { get; set; }

        public List<string> PeoplePhoneNumbers { get; set; }

        public override string ToString()
        {
            return this.TrusteePhoneNumber;
        }

    }
}
