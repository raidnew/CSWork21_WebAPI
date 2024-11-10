using CSWork21.Enities;
using CSWork21.Interfaces;
using CSWork21_WebClient.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CSWork21_WpfClient.Models;

public class PhoneBookData
{
    private IPhoneBookEntries _phoneBookEntries;

    private ObservableCollection<Contact> _contacts;

    public ReadOnlyObservableCollection<Contact> Contacts { get => new ReadOnlyObservableCollection<Contact>(_contacts); }

    public PhoneBookData()
    {
        _phoneBookEntries = new PhoneBookEntriesApi();
        LoadAllContacts();
    }

    public void RemoveContact(int id)
    {
        _phoneBookEntries.RemoveContact(id);
        LoadAllContacts();
    }

    public void AddContact(string lastName, string firstName, string thirdName, string phone, string address, string description)
    {
        Contact contact = new Contact();
        contact.FirstName = firstName;
        contact.LastName = lastName;
        contact.ThirdName = thirdName;
        contact.Phone = phone;
        contact.Address = address;
        contact.Desc = description;
        
        _phoneBookEntries.AddContact(contact);
        LoadAllContacts();
    }

    private void LoadAllContacts()
    {
        if (_contacts == null) _contacts = new ObservableCollection<Contact>();
        else _contacts.Clear();
        IEnumerable<Contact> contacts = _phoneBookEntries.GetContacts();
        foreach (Contact contact in contacts)
            _contacts.Add(contact);
    }
}
