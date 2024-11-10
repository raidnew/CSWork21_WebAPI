﻿using CSWork21.Enities;
using System.Collections.Generic;

namespace CSWork21.Interfaces
{
    public interface IPhoneBookEntries
    {
        public IEnumerable<Contact> GetContacts();
        public Contact GetContactByID(int id);
        public void EditContact(Contact contact);
        public void AddContact(Contact contact);
        public void RemoveContact(int id);
    }
}
