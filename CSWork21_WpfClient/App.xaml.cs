using CSWork21_WpfClient.Models;
using CSWork21_WpfClient.ViewModels;
using CSWork21_WpfClient.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CSWork21_WpfClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private PhoneBookData _phoneBookData;

        public App()
        {
            _phoneBookData = new PhoneBookData();
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            WindowContactsListViewModel contactsListViewModel = new WindowContactsListViewModel();
            contactsListViewModel.SetModelPhoneBook(_phoneBookData);
            contactsListViewModel.OnAddContact += OnAddContact;
            WindowContactsList contactsList = new WindowContactsList();
            contactsList.DataContext = contactsListViewModel;
            contactsList.Show();
        }

        private void OnAddContact()
        {
            WindowAddContactViewModel contactViewModel = new WindowAddContactViewModel();
            contactViewModel.OnAddEntry += _phoneBookData.AddContact;
            WindowAddContact editUser = new WindowAddContact();
            editUser.DataContext = contactViewModel;
            editUser.Show();
        }
    }
}
