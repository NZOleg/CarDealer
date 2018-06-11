using CarDealer.DataAccess;
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
        public string UserName { get; set; }

        public LoginViewModel(IPersonRepository personRepository, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _personRepository = personRepository;
            LoginUserCommand = new DelegateCommand<PasswordBox>(OnLoginExecute);
        }

        private async void OnLoginExecute(PasswordBox password)
        {
            Person person = await _personRepository.GetByUsernameAndPasswordAsync(UserName, password.Password);
            if (person == null)
            {
                return;
            }
            string role = await _personRepository.GetPersonRole(person.PersonID);
            _eventAggregator.GetEvent<AfterLoginSuccessedEvent>().Publish(new AfterLoginSuccessedEventArgs {
                Id = person.PersonID,
                Role = role
            });
        }
    }
}
