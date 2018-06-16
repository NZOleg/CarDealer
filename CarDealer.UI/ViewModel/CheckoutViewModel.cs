using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.ViewModel
{
    class CheckoutViewModel : ViewModelBase, ICheckoutViewModel
    {
        private IEventAggregator _eventAggregator;
        private ICarRepository _carRepository;
        private IPersonRepository _personRepository;

        public DelegateCommand BuyCarCommand { get; }

        private IndividualCar _car;

        public IndividualCar Car
        {
            get { return _car; }
            set {
                _car = value;
                OnPropertyChanged();
            }
        }

        private int _price;

        public int Price
        {
            get { return _price; }
            set {
                _price = value;
                OnPropertyChanged();
            }
        }

        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }



        private Customer _customer;

        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }



        public CheckoutViewModel(ICarRepository carRepository, IPersonRepository personRepository, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _carRepository = carRepository;
            _personRepository = personRepository;
            BuyCarCommand = new DelegateCommand(OnBuyCarExecute);
        }

        private async void OnBuyCarExecute()
        {
            //Add showbox TODO

            //injecting data from another repository is not allowed when save changes is reqired
            //additional function is created in person repository
            Cars_Sold cars_Sold = new Cars_Sold
            {
                Sale_Price = Price,
                Date_Sold = Date
            };
            await _personRepository.AddNewSaleAsync(Car.CarID, Customer.CustomerID, cars_Sold);
        }

        public async Task LoadAsync(int carId, int customerId)
        {
            Car =  await _carRepository.GetByIdAsync(carId);
            Customer = await _personRepository.GetCustomerByIdAsync(customerId);
        }

    }
}
