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
        public IRestResponse GetEmployeeList()
        {
            // Creating RestRequest Object with Method.GET................
            RestRequest request = new RestRequest("/AddressBook", Method.GET);
            // Executing request...........
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}
