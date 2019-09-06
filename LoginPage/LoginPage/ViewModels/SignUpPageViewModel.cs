using LoginPage.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginPage.ViewModels
{
    public class SignUpPageViewModel : INotifyPropertyChanged
    {
        public string fieldValidate { get; set; }
        public ICommand SignupCommand { get; set; }
        public User user { get; set; } = new User();

        public SignUpPageViewModel()
        {
            fieldValidate = "";

            SignupCommand = new Command(async () => {

                if (string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.ConfirmPassword))
                    fieldValidate = "You can't leave empty fields!";

                else if (!user.ConfirmPassword.Equals(user.Password) && !string.IsNullOrWhiteSpace(user.Password) && 
                                                                        !string.IsNullOrWhiteSpace(user.ConfirmPassword))
                    fieldValidate = "Passwords are different!";
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
