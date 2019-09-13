using ConsumeRestAPI.Models;
using ConsumeRestAPI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ConsumeRestAPI.ViewModels
{
    public class HeroesPageViewModel : INotifyPropertyChanged
    {
        IApiService apiService = new ApiService();

        public ObservableCollection<Heroes> Heroes { get; set; }

        public ICommand GetHeroCommand { get; set; }
        public HeroesPageViewModel()
        {
            GetHeroCommand = new Command(async() => {
                await GetHero();
            });
        }

        async Task GetHero()
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                var hero = await apiService.GetHeroes();
                Heroes = new ObservableCollection<Heroes>(hero);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "You don't have internet connection", "Ok");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
