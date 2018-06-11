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

        public DelegateCommand OpenCustomerDetailViewCommand { get; private set; }

        public string DisplayName
        {
            get { return Person.Username; }
        }


        public CustomerListItemViewModel(Person person, IEventAggregator eventAggregator)
        {
            Person = person;
            _eventAggregator = eventAggregator;
            OpenCustomerDetailViewCommand = new DelegateCommand(OpenCustomerDetailViewExecute);

        }

        private void OpenCustomerDetailViewExecute()
        {
            _eventAggregator.GetEvent<OpenCustomerDetailViewEvent>().Publish(new OpenCustomerDetailViewEventArgs
            {
                Id = Person.PersonID
            });
        }
    }
}
