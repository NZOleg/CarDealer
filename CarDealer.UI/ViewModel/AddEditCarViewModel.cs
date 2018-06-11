using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
using CarDealer.UI.Wrapper;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.ViewModel
{
    class AddEditCarViewModel : ViewModelBase, IAddEditCarViewModel
    {
        private ICarRepository _carRepository;
        private CarWrapper _car;

        public CarWrapper Car
        {
            get { return _car; }
            set {
                _car = value;
                OnPropertyChanged();
            }
        }
        private bool _hasChanges;
        public bool HasChanges
        {
            get { return _hasChanges; }
            set
            {
                if (_hasChanges != value)
                {
                    _hasChanges = value;
                    OnPropertyChanged();
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            }
        }

        private IEventAggregator _eventAggregator;

        public DelegateCommand SaveCommand { get;  }
        public DelegateCommand DeleteCommand { get; }

        public AddEditCarViewModel(ICarRepository carRepository, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            SaveCommand = new DelegateCommand(OnSaveCommandExecute);
            DeleteCommand = new DelegateCommand(OnDeleteCommandExecute);
            _carRepository = carRepository;
        }

        private async void OnDeleteCommandExecute()
        {
            _carRepository.Remove(Car.Model);
            await _carRepository.SaveAsync();
        }

        private async void OnSaveCommandExecute()
        {
            Car.CarModel = await _carRepository.SaveCarModelAsync(Car.CarModel);
            _carRepository.Add(Car.Model);
            await _carRepository.SaveAsync();
                
        }

        public async Task LoadAsync(int? id)
        {
            int carId;
            if (id == null)
            {
                Car = new CarWrapper(new IndividualCar {
                    CarModel = new CarModel(),
                    CarFeatures = null,
                    Cars_Sold = null
                });
            }
            else
            {
                //converting int? into int
                carId = (int) id;
                IndividualCar car = await _carRepository.GetByIdAsync(carId);
                Car = new CarWrapper(car);
            }

            Car.PropertyChanged += (s, e) =>
            {
                if (!HasChanges)
                {
                    HasChanges = _carRepository.HasChanges();
                }
                if (e.PropertyName == nameof(Car.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            };
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }
    }
}
