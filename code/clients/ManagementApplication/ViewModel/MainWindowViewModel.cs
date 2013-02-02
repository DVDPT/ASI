﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private NavigatePanelCommand _naviationButtonCommand;
        public NavigatePanelCommand NavigationButtonCommand
        {
            get { return _naviationButtonCommand; }
            set { _naviationButtonCommand = value; NotifyPropertyChanged("NavigationButtonCommand"); }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
