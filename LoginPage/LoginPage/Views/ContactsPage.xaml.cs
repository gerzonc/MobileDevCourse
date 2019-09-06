using LoginPage.Models;
using LoginPage.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginPage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {
        public ObservableCollection<Contact> Contact { get; set; }
        public ICommand AddItem { get; set; }
        public ContactsPage()
        {
            InitializeComponent();
            BindingContext = new ContactsPageViewModel();


            AddItem = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new AddContactPage());
            });


            MessagingCenter.Subscribe<Contact>(this, "AddNew", (values) =>
            {
                Contact.Add(values);
            });
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayActionSheet("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
