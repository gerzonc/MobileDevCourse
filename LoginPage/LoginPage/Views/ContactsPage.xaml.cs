using LoginPage.Models;
using LoginPage.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginPage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {
        public Contact contact { get; set; }
        public ObservableCollection<string> Items { get; set; }

        public ContactsPage()
        {
            InitializeComponent();
            BindingContext = new ContactsPageViewModel();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayActionSheet(string.Empty, "Cancel", string.Empty, string.Empty);

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
