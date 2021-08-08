﻿using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AddressBookSystemRESTApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n Address Book System REST Api");
            Console.WriteLine("**********************************************************************************");

            // Creating Object of EmployeeWebService to Run Fuctions on them...............
            AddressBookSystemWebService service = new AddressBookSystemWebService();
            // Calling GetEmployeeList which will return IRestResponse...............
            service.GetEmployeeList();
            IRestResponse response = service.GetEmployeeList();
            // Deserialize JSON Object ..............
            List<Contact> dataResponse = JsonConvert.DeserializeObject<List<Contact>>(response.Content);
            Console.WriteLine("Count of Contacts :" +dataResponse.Count);
        }
    }
}
