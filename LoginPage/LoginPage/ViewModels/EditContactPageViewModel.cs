using LoginPage.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginPage.ViewModels
{
    public class EditContactPageViewModel : INotifyPropertyChanged
    {
        public ICommand editItem { get; set; }
        public Contact Contact { get; set; } = new Contact();
        public EditContactPageViewModel()
        {
            MessagingCenter.Subscribe<ContactsPageViewModel, Contact>(this, "Edit", (sender, param) =>
            {
                MessagingCenter.Unsubscribe<ContactsPageViewModel, Contact>(this, "Edit");
                Contact = param;
            });

            editItem = new Command(async () =>
            {
                MessagingCenter.Send<EditContactPageViewModel, Contact>(this, "EditP", Contact);
                await App.Current.MainPage.Navigation.PopAsync();
            });
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
