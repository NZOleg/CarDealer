﻿using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
using CarDealer.UI.Event;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CarDealer.UI.ViewModel
{
    public class LoginViewModel: ViewModelBase, ILoginViewModel
    {
        private IEventAggregator _eventAggregator;
        private IPersonRepository _personRepository;

        public ICommand LoginUserCommand { get; set; }
        public ICommand CreateAccountCommand { get; set; }
        public string UserName { get; set; }

        private Visibility _invalidLoginVisibility;

        public Visibility InvalidLoginVisibility
        {
            get { return _invalidLoginVisibility; }
            set
            {
                _invalidLoginVisibility = value;
                OnPropertyChanged();
            }
        }

        public LoginViewModel(IPersonRepository personRepository, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _personRepository = personRepository;
            LoginUserCommand = new DelegateCommand<PasswordBox>(OnLoginExecute);
            CreateAccountCommand = new DelegateCommand<Object>(OnCreateAccountExecute);
            InvalidLoginVisibility = Visibility.Hidden;
        }

        private void OnCreateAccountExecute(object obj)
        {
            _eventAggregator.GetEvent<AddEditCustomerEvent>().Publish(new AddEditCustomerEventArgs
            {
                Id = null
            });
        }

        private async void OnLoginExecute(PasswordBox password)
        {
            Person person = await _personRepository.GetByUsernameAndPasswordAsync(UserName, password.Password);
            if (person == null)
            {
                InvalidLoginVisibility = Visibility.Visible;
                return;
            }
            string role = await _personRepository.GetPersonRole(person.Id);
            _eventAggregator.GetEvent<AfterLoginSuccessedEvent>().Publish(new AfterLoginSuccessedEventArgs {
                Role = role,
                Person = person
            });
        }
    }
}
