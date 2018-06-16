using CarDealer.DataAccess;
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
    class CustomerListItemViewModel : ViewModelBase
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

        public DelegateCommand OpenCustomerDetailViewCommand { get; private set; }

        public string DisplayName
        {
            get { return Customer.Person.Username; }
        }


        public CustomerListItemViewModel(Customer customer, IEventAggregator eventAggregator)
        {
            Customer = customer;
            _eventAggregator = eventAggregator;
            OpenCustomerDetailViewCommand = new DelegateCommand(OpenCustomerDetailViewExecute);

        }

        private void OpenCustomerDetailViewExecute()
        {
            _eventAggregator.GetEvent<OpenCustomerDetailViewEvent>().Publish(new OpenCustomerDetailViewEventArgs
            {
                Id = Customer.CustomerID
            });
        }
    }
}
