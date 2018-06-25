using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
using CarDealer.UI.Event;
using CarDealer.UI.Helpers;
using CarDealer.UI.View.Services;
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
    class CheckoutViewModel : ViewModelBase, ICheckoutViewModel
    {
        public IMessageDialogService MessageDialogService { get; }

        private IEventAggregator _eventAggregator;
        private ICarRepository _carRepository;
        private IPersonRepository _personRepository;

        private Visibility _invalidPriceVisibility;

        public Visibility InvalidPriceVisibility
        {
            get { return _invalidPriceVisibility; }
            set {
                _invalidPriceVisibility = value;
                OnPropertyChanged();
            }
        }


        public DelegateCommand BuyCarCommand { get; }

        private IndividualCar _car;

        public IndividualCar Car
        {
            get { return _car; }
            set {_car = value;}
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
            set {
                _date = value;
                OnPropertyChanged();
            }
        }



        private Customer _customer;

        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }



        public CheckoutViewModel(IMessageDialogService messageDialogService, ICarRepository carRepository, IPersonRepository personRepository, IEventAggregator eventAggregator)
        {
            MessageDialogService = messageDialogService;
            _eventAggregator = eventAggregator;
            _carRepository = carRepository;
            _personRepository = personRepository;
            BuyCarCommand = new DelegateCommand(OnBuyCarExecute);
            Date = DateTime.Now;
            InvalidPriceVisibility = Visibility.Hidden;
        }

        private async void OnBuyCarExecute()
        {
            if (Car.AskingPrice*0.8 >= Price)
            {
                InvalidPriceVisibility = Visibility.Visible;
                return;
            }
            var result = await MessageDialogService.ShowOkCancelDialogAsync($"Do you really want to buy {Car.CarModel.Manufacturer} {Car.CarModel.Model} {Car.ManufactureYear}?",
              "Confirmation");
            if (result == MessageDialogResult.Cancel)
            {
                _eventAggregator.GetEvent<OpenCarListEvent>().Publish(new OpenCarListEventArgs());
                return;
            }
            //injecting data from another repository is not allowed when save changes is reqired
            //additional function is created in person repository
            CarSale cars_Sold = new CarSale
            {
                SalePrice = Price,
                Date = Date
            };
            await _personRepository.AddNewSaleAsync(Car.Id, Customer.Id, cars_Sold);
            await _carRepository.CarIsSoldAsync(Car.Id);
            _eventAggregator.GetEvent<OpenCarListEvent>().Publish(new OpenCarListEventArgs());
        }

        public async Task LoadAsync(int carId, int customerId)
        {
            Car =  await _carRepository.GetByIdAsync(carId);
            Customer = await _personRepository.GetCustomerByIdAsync(customerId);
        }

    }
}
