﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginPage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public HomeMasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new HomeMasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class HomeMasterDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<HomeMasterDetailPageMasterMenuItem> MenuItems { get; set; }

            public HomeMasterDetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<HomeMasterDetailPageMasterMenuItem>(new[]
                {
                    new HomeMasterDetailPageMasterMenuItem { Id = 0, Title = "Page 1" },
                    new HomeMasterDetailPageMasterMenuItem { Id = 1, Title = "Page 2" },
                    new HomeMasterDetailPageMasterMenuItem { Id = 2, Title = "Page 3" },
                    new HomeMasterDetailPageMasterMenuItem { Id = 3, Title = "Page 4" },
                    new HomeMasterDetailPageMasterMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}