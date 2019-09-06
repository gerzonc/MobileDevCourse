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
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        public ICommand AddItem { get; set; } 

        public ContactsPageViewModel()
        {
            AddItem = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new AddContactPage());
                MessagingCenter.Subscribe<AddContactPageViewModel, Contact>(this, "AddNew", (sender, args) =>
                {
                    Contacts.Add(args);
                });

            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
