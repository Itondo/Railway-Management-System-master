using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway_Management_System
{
    class Account
    {
        public string name;
        public string Id;
        public string Password;
        public string Email;
        public string Address;
        public string PhoneNumber;
       public static ArrayList Cust = new ArrayList();
        
        public static ArrayList User = new ArrayList();
        public Account (string Id, string name, string pass, string Phone, string Address) // Create new account for User/ Customer as Requested.
        {
            this.Id = Id;
            this.name = name;
            this.Password = pass;
            this.PhoneNumber = Phone;
            this.Address = Address;
        }
        
    }
}
