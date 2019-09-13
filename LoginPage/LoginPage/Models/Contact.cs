using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LoginPage.Models
{
    public class Contact : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
