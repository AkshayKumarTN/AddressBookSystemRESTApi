using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBookSystemRESTApi;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace AddressBookSystemRESTApiTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void OnCallingGET_ReturnEmployeeList()
        {
            // Creating Object of EmployeeWebService to Run Fuctions on them...............
            AddressBookSystemWebService service = new AddressBookSystemWebService();
            // Calling GetEmployeeList which will return IRestResponse...............
            IRestResponse response = service.GetEmployeeList();
            // HttpStatusCode.OK = 200................
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            // Deserialize JSON Object ..............
            List<Contact> dataResponse = JsonConvert.DeserializeObject<List<Contact>>(response.Content);
            Assert.AreEqual(2, dataResponse.Count);
        }
    }
}
