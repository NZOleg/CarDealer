using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
using CarDealer.UI.Wrapper;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.ViewModel
{
    class AddEditCarViewModel : ViewModelBase, IAddEditCarViewModel
    {


        private ICarRepository _carRepository;
        private CarWrapper _car;

        private ObservableCollection<CarFeatureModelView> _carFeatures;

        public ObservableCollection<CarFeatureModelView> CarFeatures
        {
            get { return _carFeatures; }
            set { _carFeatures = value; }
        }


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
            CarFeatures = new ObservableCollection<CarFeatureModelView>();
        }

        private async void OnDeleteCommandExecute()
        {
            _carRepository.Remove(Car.Model);
            await _carRepository.SaveAsync();
        }

        private async void OnSaveCommandExecute()
        {
            CarModel carModel = await _carRepository.CreateOrAssignCarModelAsync(Car.Model.CarModel);
            Car.Model.CarModel = carModel;
            Car.CarFeatures = getSelectedFeatures();
            await _carRepository.SaveAsync();
                
        }

        private List<CarFeature> getSelectedFeatures()
        {
            List<CarFeature> carFeatures = new List<CarFeature>();
            foreach (CarFeatureModelView carFeature in CarFeatures)
            {
                if (carFeature.IsChecked)
                {
                    carFeatures.Add(carFeature.CarFeature);
                }
                
            }
            return carFeatures;
        }

        public async Task LoadAsync(int? id)
        {
            IndividualCar car;
            if (id == null)
            {
                car = CreateNewCar();
            }
            else
            {
                car = await _carRepository.GetByIdAsync((int)id);
            }
            InitializeCar(car);

            await LoadCarFeaturesAsync();
        }

        private async Task LoadCarFeaturesAsync()
        {
            List<CarFeature> carFeatures = await _carRepository.getAllCarFeatures();
            foreach(CarFeature carFeature in carFeatures)
            {
                CarFeatures.Add(new CarFeatureModelView(carFeature) { IsChecked=true });
            }
        }

        private void InitializeCar(IndividualCar car)
        {
            Car = new CarWrapper(car);
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

        private IndividualCar CreateNewCar()
        {
            var car = new IndividualCar {
                CarModel = new CarModel(),
                Cars_Sold = null,
                CarFeatures = new Collection<CarFeature>()
            };
            _carRepository.Add(car);
            return car;
        }
    }
}
