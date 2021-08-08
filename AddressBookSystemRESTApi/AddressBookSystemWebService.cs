using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystemRESTApi
{
    public class AddressBookSystemWebService
    {
        RestClient client;
        public AddressBookSystemWebService()
        {
            // Creating RestClient Object ................
            client = new RestClient("http://localhost:3000");
        }
        public IRestResponse GetContctList()
        {
            // Creating RestRequest Object with Method.GET................
            RestRequest request = new RestRequest("/AddressBook", Method.GET);
            // Executing request...........
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse AddContact(Contact contact)
        {
            // Creating RestRequest Object with Method.POST...............
            RestRequest request = new RestRequest("/AddressBook", Method.POST);
            // Creating JsonObject Object to insert values................
            JsonObject json = new JsonObject();
            json.Add("FirstName", contact.firstName);
            json.Add("LastName", contact.lastName);            
            json.Add("Address", contact.address);
            json.Add("City", contact.city);
            json.Add("State", contact.state);
            json.Add("Zip", contact.zipCode);
            json.Add("PhoneNumber", contact.phoneNumber);
            json.Add("Email", contact.email);
            // Adding into JSON file..............
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            // Executing request...........
            IRestResponse response = client.Execute(request);
            return response;
        }
        public void AddMultipleContact(List<Contact> contactList)
        {
            AddressBookSystemWebService service = new AddressBookSystemWebService();
            // Creating RestRequest Object with Method.POST...............
            RestRequest request = new RestRequest("/AddressBook", Method.POST);
            foreach (Contact contact in contactList)
            {
                service.AddContact(contact);
            }
        }
    }
}
