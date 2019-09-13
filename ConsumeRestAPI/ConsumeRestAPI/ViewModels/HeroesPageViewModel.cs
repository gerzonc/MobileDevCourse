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
        public Heroes Hero { get; set; }

        public int id { get; set; }
        public string localized_name { get; set; }
        public string attack_type { get; set; }

        public ICommand heroSearch { get; set; }
        public HeroesPageViewModel()
        {
            heroSearch = new Command(async() => {
                await GetHero();
            });
        }

        async Task GetHero()
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                var heroe = await apiService.GetHeroes();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "You don't have internet connection", "Ok");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
