using CSWork21.Enities;
using CSWork21.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CSWork21_WebClient.Data
{
    public class PhoneBookEntriesApi : IPhoneBookEntries
    {
        private readonly string _serverAddress;
        private HttpClient HttpClient { get; set; }

        public PhoneBookEntriesApi()
        {
            _serverAddress = "http://localhost:5000";
            HttpClient = new HttpClient();
        }

        public Contact GetContactByID(int id)
        {
            string url = GetUrl($"contacts/Id/{id}");
            string json = HttpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<Contact>(json);
        }

        public void EditContact(Contact contact)
        {
            HttpResponseMessage message = HttpClient.PostAsync(
                requestUri: GetUrl("contacts"),
                content: new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8,
                mediaType: "application/json")
            ).Result;
        }

        public void AddContact(Contact contact)
        {
            HttpResponseMessage message = HttpClient.PutAsync(
                requestUri: GetUrl("contacts"),
                content: new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8,
                mediaType: "application/json")
            ).Result;
        }

        public void RemoveContact(int id)
        {
            HttpResponseMessage message = HttpClient.DeleteAsync(
                requestUri: GetUrl($"contacts/{id}")
            ).Result;
        }

        public IEnumerable<Contact> GetContacts()
        {
            string json = HttpClient.GetStringAsync(GetUrl("contacts")).Result;
            return JsonConvert.DeserializeObject<IEnumerable<Contact>>(json);
        }

        private string GetUrl(string action)
        {
            return $"{_serverAddress}/api/{action}";
        }

    }
}
