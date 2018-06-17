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
using System.Windows;

namespace CarDealer.UI.ViewModel
{
    class CarDetailViewModel : ViewModelBase, ICarDetailViewModel
    {
        private Visibility _editVisibility;

        public Visibility EditVisibility
        {
            get { return _editVisibility; }
            set {
                _editVisibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility _buyVisibility;

        public Visibility BuyVisibility
        {
            get { return _buyVisibility; }
            set {
                _buyVisibility = value;
                OnPropertyChanged();
            }
        }



        private IndividualCar _car;

        public Customer Customer { get; private set; }

        public IndividualCar Car
        {
            get { return _car; }
            set {
                _car = value;
                OnPropertyChanged();
            }
        }

        private IEventAggregator _eventAggregator;
        private ICarRepository _carRepository;
        private IPersonRepository _personRepository;

        public DelegateCommand EditCarViewCommand { get; private set; }
        public DelegateCommand BuyCarCommand { get; private set; }

        public CarDetailViewModel(ICarRepository carRepository, IPersonRepository personRepository, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _carRepository = carRepository;
            _personRepository = personRepository;
            EditCarViewCommand = new DelegateCommand(EditCarViewExecute);
            BuyCarCommand = new DelegateCommand(BuyCarExecute);
        }

        private void BuyCarExecute()
        {
            _eventAggregator.GetEvent<OpenCheckoutEvent>().Publish(new OpenCheckoutEventArgs
            {
                Id = Car.Id
            });
        }

        private void EditCarViewExecute()
        {
            _eventAggregator.GetEvent<AddEditCarEvent>().Publish(new AddEditCarEventArgs
            {
                Id = Car.Id
            });
        }

        public async Task LoadAsync(int id, Person person)
        {
            string role = await _personRepository.GetPersonRole(person.Id);
            if (role == "customer")
            {
                Customer = await _personRepository.GetCustomerByIdAsync(person.Id);
            }
            Car = await _carRepository.GetByIdAsync(id);
            SetLayoutForCurrentUser(role);
        }

        private void SetLayoutForCurrentUser(string role)
        {
            switch (role)
            {
                case "admin":
                case "staff":
                    EditVisibility = Visibility.Visible;
                    BuyVisibility = Visibility.Hidden;
                    break;
                case "customer":
                default:
                    EditVisibility = Visibility.Hidden;
                    BuyVisibility = Visibility.Visible;
                    break;
            }
        }
    }
}
