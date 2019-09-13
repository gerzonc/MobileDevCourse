using ConsumeRestAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConsumeRestAPI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeroesPage : ContentPage
    {
        public HeroesPage()
        {
            InitializeComponent();
            BindingContext = new HeroesPageViewModel();
        }
    }
}