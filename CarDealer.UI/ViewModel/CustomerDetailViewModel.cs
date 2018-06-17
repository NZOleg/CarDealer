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

namespace CarDealer.UI.ViewModel
{
    class CustomerDetailViewModel : ViewModelBase, ICustomerDetailViewModel
    {
        private Customer _customer;

        public Customer Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                OnPropertyChanged();
            }
        }

        private IEventAggregator _eventAggregator;
        private IPersonRepository _personRepository;

        public DelegateCommand EditCustomerViewCommand { get; private set; }

        public CustomerDetailViewModel(IPersonRepository personRepository, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _personRepository = personRepository;
            EditCustomerViewCommand = new DelegateCommand(EditCustomerViewExecute);
        }

        private void EditCustomerViewExecute()
        {
            _eventAggregator.GetEvent<AddEditCustomerEvent>().Publish(new AddEditCustomerEventArgs
            {
                Id = Customer.Id
            });
        }

        public async Task LoadAsync(int id)
        {
            Customer = await _personRepository.GetCustomerByIdAsync(id);

        }
    }
}
