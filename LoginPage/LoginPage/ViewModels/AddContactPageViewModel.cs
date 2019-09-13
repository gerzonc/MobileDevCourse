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
        public Contact Contact { get; set; } = new Contact();
        public ICommand sendUser { get; set; }
        public AddContactPageViewModel()
        {
            sendUser = new Command(async () =>
            {
                MessagingCenter.Send<AddContactPageViewModel, Contact>(this, "AddNew", Contact);
                await App.Current.MainPage.Navigation.PopAsync();
            });

        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
