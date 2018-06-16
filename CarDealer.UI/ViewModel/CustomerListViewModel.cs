using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.ViewModel
{
    
    class CustomerListViewModel : ViewModelBase, ICustomerListViewModel
    {
        public ObservableCollection<CustomerListItemViewModel> Customers { get; set; }

        private IEventAggregator _eventAggregator;
        private IPersonRepository _peopleRepository;

        public CustomerListViewModel(IPersonRepository peopleRepository, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _peopleRepository = peopleRepository;
            Customers = new ObservableCollection<CustomerListItemViewModel>();
        }

        public async Task LoadAsync()
        {
            Collection<Customer> customers = await _peopleRepository.GetAllCustomersAsync();
            foreach (Customer customer in customers)
            {
                Customers.Add(new CustomerListItemViewModel(customer, _eventAggregator));
            }
        }
    }
}
