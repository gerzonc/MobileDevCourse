using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Hw7.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public string myName { get; set; }
        public MainPageViewModel()
        {
            myName = "classmates";
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
