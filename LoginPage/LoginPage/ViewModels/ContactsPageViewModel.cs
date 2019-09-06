using LoginPage.Models;
using LoginPage.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginPage.ViewModels
{
    public class ContactsPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Contact> Contacts { get; set; }
        public Contact contact { get; set; } = new Contact();
        public ICommand AddItem { get; set; } 

        public ContactsPageViewModel()
        {
            AddItem = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new AddContactPage());
            });


            MessagingCenter.Subscribe<Contact>(this, "AddNew", (values) =>
            {
                Contacts.Add(values);
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
