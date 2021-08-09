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
        public void OnCallingGET_ReturnContactList()
        {
            // Creating Object of EmployeeWebService to Run Fuctions on them...............
            AddressBookSystemWebService service = new AddressBookSystemWebService();
            // Calling GetEmployeeList which will return IRestResponse...............
            IRestResponse response = service.GetContctList();
            // HttpStatusCode.OK = 200................
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            // Deserialize JSON Object ..............
            List<Contact> dataResponse = JsonConvert.DeserializeObject<List<Contact>>(response.Content);
            Assert.AreEqual(2, dataResponse.Count);
        }

        [TestMethod]
        public void OnCallingPostAPI_Adding_MultipleData()
        {
            AddressBookSystemWebService service = new AddressBookSystemWebService();

            List<Contact> contactList = new List<Contact>();
            // Contact object is created.............
            Contact contact = new Contact();
            Contact contact1 = new Contact();
            // Adding Values in the Object...................
            contact.firstName = "Arun";
            contact.lastName = "Kumar";
            contact.address = "T-Nagar";
            contact.city = "Chennai";
            contact.state = "TN";
            contact.zipCode = 600032;
            contact.phoneNumber = 9345678902;
            contact.email = "Arun@gmail.com";
            contactList.Add(contact);
            contact.firstName = "Guru";
            contact.lastName = "V";
            contact.address = "Arakkonam";
            contact.city = "Arakkonam";
            contact.state = "TN";
            contact.zipCode = 631002;
            contact.phoneNumber = 678901234;
            contact.email = "GuruV@gmail.com";
            contactList.Add(contact1);


            service.AddMultipleContact(contactList);
            IRestResponse response = service.GetContctList();
            // HttpStatusCode.OK = 200................
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            // Deserialize JSON Object ..............
            List<Contact> dataResponse = JsonConvert.DeserializeObject<List<Contact>>(response.Content);
            Assert.AreEqual(4, dataResponse.Count);

        }

        [TestMethod]
        public void OnCallingPutAPI_UpdateContactDetails()
        {
            AddressBookSystemWebService service = new AddressBookSystemWebService();
            // Contact object is created.............
            Contact contact = new Contact();
            // Adding Values in the Object...................
            contact.firstName = "Guru";
            contact.lastName = "V";
            contact.address = "Arakkonam";
            contact.city = "Arakkonam";
            contact.state = "TN";
            contact.zipCode = 631002;
            contact.phoneNumber = 678901234;
            contact.email = "Guru123@gmail.com";
            IRestResponse response = service.UpdateContact(contact);
            // Convert the jsonobject to Contact object............
            var res = JsonConvert.DeserializeObject<Contact>(response.Content);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void OnCallingDeleteAPI_DeleteContactDetails()
        {
            AddressBookSystemWebService service = new AddressBookSystemWebService();
            IRestResponse response1 = service.DeleteContact();
            IRestResponse response = service.GetContctList();
            List<Contact> result = JsonConvert.DeserializeObject<List<Contact>>(response.Content);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}
