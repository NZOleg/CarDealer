using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
using CarDealer.UI.Wrapper;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.ViewModel
{
    class AddEditCustomerViewModel : ViewModelBase, IAddEditCustomerViewModel
    {
        private IPersonRepository _personRepository;
        private CustomerWrapper _customer;

        public CustomerWrapper Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                OnPropertyChanged();
            }
        }

        private IEventAggregator _eventAggregator;

        public DelegateCommand SaveCommand { get; }
        public DelegateCommand DeleteCommand { get; }

        public AddEditCustomerViewModel(IPersonRepository personRepository, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            SaveCommand = new DelegateCommand(OnSaveCommandExecute);
            DeleteCommand = new DelegateCommand(OnDeleteCommandExecute);
            _personRepository = personRepository;
        }

        private async void OnDeleteCommandExecute()
        {
            _personRepository.Remove(Customer.Model);
            await _personRepository.SaveAsync();
        }

        private async void OnSaveCommandExecute()
        {
            _personRepository.AddCustomer(Customer.Model);
            await _personRepository.SaveAsync();

        }

        public async Task LoadAsync(int? id)
        {
            int customerId;
            if (id == null)
            {
                Customer = new CustomerWrapper(new Person
                {
                    Employee = null,
                    Customer = new Customer()
                });
            }
            else
            {
                //converting int? into int
                customerId = (int)id;
                Person person = await _personRepository.GetByIdAsync(customerId);
                Customer = new CustomerWrapper(person);
            }
        }
    }
}
