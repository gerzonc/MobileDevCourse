using LoginPage.Models;
using LoginPage.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace LoginPage.ViewModels
{
    public class ContactsPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        public Contact contact { get; set; }
        public ICommand AddItem { get; set; } 
        public ICommand DeleteItem { get; set; }
        public ICommand MoreItem { get; set; }

        public ContactsPageViewModel()
        {
            AddItem = new Command(async () =>
            {       
                await App.Current.MainPage.Navigation.PushAsync(new AddContactPage());
                
            });

            MoreItem = new Command<Contact>(async(args) =>
            {
                var actionSheet = await App.Current.MainPage.DisplayActionSheet(string.Empty, "Cancel", string.Empty, $"Call +{args.PhoneNumber}", "Edit");

                switch (actionSheet)
                {
                    case "Edit":
                        MessagingCenter.Send<ContactsPageViewModel, Contact>(this, "Edit", args);
                        await App.Current.MainPage.Navigation.PushAsync(new EditContactPage());
                        break;
                    default:
                        CallContact(args.PhoneNumber);
                        break;
                }
            });

            DeleteItem = new Command<Contact>(async(args) =>
            {
                Contacts.Remove(args);
            });

            MessagingCenter.Subscribe<EditContactPageViewModel, Contact>(this, "Edit", (sender, args) =>
            {
                MessagingCenter.Unsubscribe<EditContactPageViewModel>(this, "Edit");
                contact = args;
            });

            MessagingCenter.Subscribe<AddContactPageViewModel, Contact>(this, "AddNew", (sender, args) =>
            {
                MessagingCenter.Unsubscribe<AddContactPageViewModel>(this, "AddNew");
                Contacts.Add(args);
            });

            
        }


        public async void CallContact(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return;

            try
            {
                PhoneDialer.Open(phoneNumber);
            }
            catch (FeatureNotSupportedException ex)
            {
                await App.Current.MainPage.DisplayAlert("Dialing not supported", ex.Message, "Cancel");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Cancel");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
