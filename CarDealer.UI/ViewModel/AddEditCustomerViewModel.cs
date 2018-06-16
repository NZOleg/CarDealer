using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
using CarDealer.UI.Event;
using CarDealer.UI.Wrapper;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
        private bool _hasChanges;
        public bool HasChanges
        {
            get { return _hasChanges; }
            set
            {
                if (_hasChanges != value)
                {
                    _hasChanges = value;
                    OnPropertyChanged();
                    ((DelegateCommand<PasswordBox>)SaveCommand).RaiseCanExecuteChanged();
                }
            }
        }

        private IEventAggregator _eventAggregator;

        public DelegateCommand<PasswordBox> SaveCommand { get; }
        public DelegateCommand DeleteCommand { get; }

        public AddEditCustomerViewModel(IPersonRepository personRepository, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            SaveCommand = new DelegateCommand<PasswordBox>(OnSaveCommandExecute);
            DeleteCommand = new DelegateCommand(OnDeleteCommandExecute);
            _personRepository = personRepository;
        }

        private async void OnDeleteCommandExecute()
        {
            _personRepository.RemoveCustomer(Customer.Model);
            await _personRepository.SaveAsync();
        }

        private async void OnSaveCommandExecute( PasswordBox password)
        {
            Customer.Person.Password = password.Password;
            await _personRepository.SaveAsync();
            
            _eventAggregator.GetEvent<OpenMainPageEvent>().Publish(new OpenMainPageEventArgs());

        }

        public async Task LoadAsync(int? id)
        {
            Customer customer;
            if(id == null)
            {
                customer = createNewCustomer();
            }
            else
            {
                customer = await _personRepository.GetCustomerByIdAsync( (int) id);
            }
            InitializeCustomer(customer);
        }

        private void InitializeCustomer(Customer customer)
        {
            Customer = new CustomerWrapper(customer);
            Customer.PropertyChanged += (s, e) =>
            {
                if (!HasChanges)
                {
                    HasChanges = _personRepository.HasChanges();
                }
                if (e.PropertyName == nameof(Customer.HasErrors))
                {
                    ((DelegateCommand<PasswordBox>)SaveCommand).RaiseCanExecuteChanged();
                }
            };
            ((DelegateCommand<PasswordBox>)SaveCommand).RaiseCanExecuteChanged();
        }

        private Customer createNewCustomer()
        {
            Customer customer = new Customer
            {
                Person = new Person(),
                Cars_Sold = new Collection<Cars_Sold>()
            };
            _personRepository.AddCustomer(customer);
            return customer;
        }
    }

}
