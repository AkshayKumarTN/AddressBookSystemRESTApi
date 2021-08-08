using RestSharp;
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
            // Contact object is created.............
            Contact contact = new Contact();
            // Adding Values in the Object...................
            contact.firstName = "Arun";
            contact.lastName = "Kumar";
            contact.address = "T-Nagar";
            contact.city = "Chennai";
            contact.state = "TN";
            contact.zipCode = 600032;
            contact.phoneNumber = 2345678902;
            contact.email = "Arun@gmail.com";


            service.AddContact(contact);
            // Calling GetEmployeeList which will return IRestResponse...............
            IRestResponse response = service.GetContctList();

            // Deserialize JSON Object ..............
            List<Contact> dataResponse = JsonConvert.DeserializeObject<List<Contact>>(response.Content);
            Console.WriteLine("Count of Contacts :" +dataResponse.Count);
        }
    }
}
