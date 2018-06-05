using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
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
            //make an event
        }
    }
}
