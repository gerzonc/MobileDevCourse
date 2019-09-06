using LoginPage.Models;
using System.Windows.Input;
using LoginPage.Controls;
using Xamarin.Forms;
using System.ComponentModel;
using LoginPage.Views;

namespace LoginPage.ViewModels
{
    public class SignInViewModel : INotifyPropertyChanged
    {
        public string fieldValidate { get; set; }
        public ICommand LoginCommand { get; set; }
        public User user { get; set; } = new User();

        public SignInViewModel()
        {

            LoginCommand = new Command(async () => {

                if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
                    fieldValidate = "Fields can't be empty";
                else
                    await App.Current.MainPage.Navigation.PushModalAsync(new HomeMasterDetailPage());
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
