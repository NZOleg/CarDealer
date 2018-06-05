using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.ViewModel
{
    public class MainViewModel
    {
        private IPersonRepository _personRepository;
        private ILoginViewModel _loginViewModel;

        public ILoginViewModel LoginViewModel
        {
            get { return _loginViewModel; }
            set { _loginViewModel = value; }
        }


        public ObservableCollection<Person> people { get; }

        public MainViewModel(IPersonRepository personRepository, ILoginViewModel loginViewModel)
        {
            _personRepository = personRepository;
            LoginViewModel = loginViewModel;
            people = new ObservableCollection<Person>();
        }
        public async Task LoadAsync()
        {
           var lookup =  await _personRepository.GetAllAsync();
            people.Clear();
            foreach (var item in lookup)
            {
                people.Add(new Person());
            }
        }
    }

}
