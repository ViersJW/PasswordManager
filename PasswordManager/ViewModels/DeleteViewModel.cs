﻿using PasswordManager.Dependancies;
using PasswordManager.Infrastructure;
using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;
using PasswordManager.Controllers;

namespace PasswordManager.ViewModels
{
    public class DeleteViewModel : BaseViewModel
    {
        private ObservableCollection<PasswordRecord> passwords;
        public ObservableCollection<PasswordRecord> Passwords { get => passwords; set { passwords = value; OnPropertyChanged(); } }

        private PasswordRecord selectedPassword;
        public PasswordRecord SelectedPassword { get => selectedPassword; set { selectedPassword = value; OnPropertyChanged(); } }

        public ICommand DeletePassword { get; set; }

        public DeleteViewModel()
        {
            SetupCommands();
            SetupControls();


        }

        private void SetupControls()
        {
            var repo = DI.Provider.GetService<IAppRepository>();
            Passwords = new ObservableCollection<PasswordRecord>(repo.GetPasswords());
        }

        private void SetupCommands()
        {
            DeletePassword = new RelayCommand(async () => await DI.Provider.GetService<DeletePageController>().DeletePassword());
        }
    }
}