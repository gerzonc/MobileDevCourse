using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace XamExercise1.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public IDeviceOrientationService deviceOrientation { get; set; }

        public ICommand OrientationText { get; set; }
        public MainPageViewModel()
        {

            OrientationText = new Command(()=> {
                DeviceOrientation orientation = DependencyService.Get<IDeviceOrientationService>().GetOrientation();

                App.Current.MainPage.DisplayAlert("Orientation", orientation.ToString(), "OK");
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
