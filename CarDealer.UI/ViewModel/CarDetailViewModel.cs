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

        public DelegateCommand EditCarViewCommand { get; private set; }

        public CarDetailViewModel(ICarRepository carRepository, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _carRepository = carRepository;
            EditCarViewCommand = new DelegateCommand(EditCarViewExecute);
        }

        private void EditCarViewExecute()
        {
            _eventAggregator.GetEvent<AddEditCarEvent>().Publish(new AddEditCarEventArgs
            {
                Id = Car.CarID
            });
        }

        public async Task LoadAsync(int id, string role)
        {
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
