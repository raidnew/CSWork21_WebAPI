using CSWork21.Enities;
using CSWork21_WpfClient.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Task.Common;

namespace CSWork21_WpfClient.ViewModels;

public class WindowContactsListViewModel
{
    public Action OnAddContact;
    public Action<int> OnRemoveContact;
    public ReadOnlyObservableCollection<Contact> Contacts { get; set; }

    private ICommand _clickAddContact;
    private ICommand _clickRemoveContact;
    private PhoneBookData _phoneBookData;

    public ICommand ClickAddContact
    {
        get
        {
            return _clickAddContact ?? (_clickAddContact = new CommandHandler(() => OnAddContact?.Invoke(), () => true));
        }
    }
    public ICommand ClickRemoveContact
    {
        get
        {
            return _clickRemoveContact ?? (_clickRemoveContact = new CommandHandler(() => RemoveContact(), () => IsEntrySelected));
        }
    }

    public Contact SelectedItem { get; set; }

    private bool IsEntrySelected { get { return SelectedItem != null; }}

    public void SetModelPhoneBook(PhoneBookData phoneBookData)
    {
        _phoneBookData = phoneBookData;
        Contacts = phoneBookData.Contacts;
    }

    private void RemoveContact() => _phoneBookData.RemoveContact(SelectedItem.Id);
}
