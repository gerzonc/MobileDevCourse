using LoginPage.Models;
using LoginPage.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginPage.ViewModels
{
    public class AddContactPageViewModel : INotifyPropertyChanged
    {
        public Contact contact { get; set; } = new Contact();
        public ICommand sendUser { get; set; }
        public AddContactPageViewModel()
        {
            sendUser = new Command(async () =>
            {
                MessagingCenter.Send<AddContactPageViewModel, Contact>(this, "AddNew", contact);
                await App.Current.MainPage.Navigation.PopAsync();
            });

            MessagingCenter.Subscribe<ContactsPageViewModel, Contact>(this, "AddNew", (sender, param) => {
                param.Name = sender.contact.Name;
                param.PhoneNumber = sender.contact.PhoneNumber;
                MessagingCenter.Unsubscribe<AddContactPageViewModel>(this, "AddNew");
            });
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
