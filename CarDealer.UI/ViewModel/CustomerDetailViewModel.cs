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
        private Person _person;

        public Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
                OnPropertyChanged();
            }
        }

        private IEventAggregator _eventAggregator;
        private IPersonRepository _personRepository;

        public DelegateCommand EditCarViewCommand { get; private set; }

        public CustomerDetailViewModel(IPersonRepository personRepository, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _personRepository = personRepository;
            EditCarViewCommand = new DelegateCommand(EditCustomerViewExecute);
        }

        private void EditCustomerViewExecute()
        {
            _eventAggregator.GetEvent<AddEditCustomerEvent>().Publish(new AddEditCustomerEventArgs
            {
                Id = Person.PersonID
            });
        }

        public async Task LoadAsync(int id)
        {
            Person = await _personRepository.GetCustomerByIdAsync(id);

        }
    }
}
