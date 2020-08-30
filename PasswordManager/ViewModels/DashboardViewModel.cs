﻿using PasswordManager.Controllers;
using PasswordManager.Dependancies;
using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Infrastructure;
using System.Runtime.InteropServices;
using PasswordManager.BusinessLogic;

namespace PasswordManager.ViewModels
{
    class DashboardViewModel : BaseViewModel, IViewModelRefreshable
    {
        private ObservableCollection<PasswordRecord> passwords;
        public ObservableCollection<PasswordRecord> Passwords { get => passwords; set { passwords = value; OnPropertyChanged(); } }

        private PasswordRecord selectedPassword;
        public PasswordRecord SelectedPassword { get => selectedPassword; set { selectedPassword = value; OnPropertyChanged(); } }

        public ICommand GetPassword { get; set; }

        public DashboardViewModel()
        {
            SetupCommands();
            Refresh();
        }

        public void SetupCommands()
        {
            GetPassword = new RelayCommand(() => DI.Provider.GetService<DashboardController>().GetPassword());
        }

        public void Refresh()
        {
            var repo = DI.Provider.GetService<IAppRepository>();
            Passwords = new ObservableCollection<PasswordRecord>(repo.GetPasswords());
        }
    }
}
