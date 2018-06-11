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
        private ObservableCollection<CustomerListItemViewModel> _people;

        public ObservableCollection<CustomerListItemViewModel> People
        {
            get { return _people; }
            set {
                _people = value;
                OnPropertyChanged();
            }
        }

        private IEventAggregator _eventAggregator;
        private IPersonRepository _peopleRepository;

        public CustomerListViewModel(IPersonRepository peopleRepository, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _peopleRepository = peopleRepository;
            People = new ObservableCollection<CustomerListItemViewModel>();
        }

        public async Task LoadAsync()
        {
            var people = await _peopleRepository.GetAllCustomersAsync();
            foreach (var person in people)
            {
                People.Add(new CustomerListItemViewModel(person, _eventAggregator));
            }
        }
    }
}
