using System;
using System.Windows.Input;
using Task.Common;

namespace CSWork21_WpfClient.ViewModels;

public class WindowAddContactViewModel
{
    public Action<string, string, string, string, string, string> OnAddEntry;
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string ThirdName { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Desc { get; set; }

    private ICommand _clickAddCommand;

    public ICommand ClickAddCommand
    {
        get
        {
            return _clickAddCommand ?? (_clickAddCommand = new CommandHandler(AddEntry, () => true));
        }
    }

    private void AddEntry()
    {
        OnAddEntry?.Invoke(LastName, FirstName, ThirdName, Phone, Address, Desc);
    }
}
