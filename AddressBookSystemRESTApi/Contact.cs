using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystemRESTApi
{
    public class Contact
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string addresses { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
        public string email { get; set; }
    }
}
