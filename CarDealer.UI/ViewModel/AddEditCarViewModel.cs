using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
using CarDealer.UI.Event;
using CarDealer.UI.Helpers;
using CarDealer.UI.Wrapper;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarDealer.UI.ViewModel
{
    class AddEditCarViewModel : ViewModelBase, IAddEditCarViewModel
    {

        private Visibility _deleteVisibility;

        public Visibility DeleteVisibility
        {
            get { return _deleteVisibility; }
            set {
                _deleteVisibility = value;
                OnPropertyChanged();
            }
        }

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
            SaveCommand = new DelegateCommand(OnSaveCommandExecute, OnSaveCanExecute);
            DeleteCommand = new DelegateCommand(OnDeleteCommandExecute);
            _carRepository = carRepository;
            CarFeatures = new ObservableCollection<CarFeatureModelView>();
            DeleteVisibility = Visibility.Visible;
        }


        private async void OnDeleteCommandExecute()
        {
            _carRepository.Remove(Car.Model);
            await _carRepository.SaveAsync();

            _eventAggregator.GetEvent<OpenCarListEvent>().Publish(new OpenCarListEventArgs());
        }

        private async void OnSaveCommandExecute()
        {
            CarModel carModel = await _carRepository.CreateOrAssignCarModelAsync(Car.Model.CarModel);
            Car.Model.CarModel = carModel;
            Car.CarFeatures = await GetSelectedFeatures();
            await _carRepository.SaveAsync();
            _eventAggregator.GetEvent<OpenCarListEvent>().Publish(new OpenCarListEventArgs());

        }

        private async Task<Collection<CarFeature>> GetSelectedFeatures()
        {
            Collection<CarFeature> carFeatures = await _carRepository.GetAllCarFeatures();
            foreach (CarFeature carFeature in carFeatures)
            {
                if (carFeature.IndividualCars.Any(ic => ic.Id == Car.Id))
                {
                    carFeature.IndividualCars.Remove(Car.Model);
                    Car.Model.CarFeatures.Remove(carFeature);
                    await _carRepository.SaveAsync();
                }
                
            }

            Collection<CarFeature> newCarFeatures = new Collection<CarFeature>();
            foreach (CarFeatureModelView carFeature in CarFeatures)
            {
                if (carFeature.IsChecked == true)
                {
                    newCarFeatures.Add(carFeature.CarFeature);
                }
                
            }
            return newCarFeatures;
        }

        public async Task LoadAsync(int? id)
        {
            IndividualCar car;
            if (id == null)
            {
                DeleteVisibility = Visibility.Hidden;
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
            Collection<CarFeature> carFeatures = await _carRepository.GetAllCarFeatures();
            Collection<CarFeature> currentFeatures = Car.CarFeatures;
            Collection<int> currentFeaturesId = new Collection<int>();
            foreach (CarFeature carfeature in currentFeatures)
            {
                currentFeaturesId.Add(carfeature.Id);
            }


            foreach (CarFeature carFeature in carFeatures)
            {
                if (currentFeaturesId.Contains(carFeature.Id)){

                    CarFeatures.Add(new CarFeatureModelView(carFeature) { IsChecked = true });
                }
                else
                {
                    CarFeatures.Add(new CarFeatureModelView(carFeature) { IsChecked = false });
                }
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
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

            };
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }

        private IndividualCar CreateNewCar()
        {
            var car = new IndividualCar {
                CarModel = new CarModel(),
                CarSale = null,
                CarFeatures = new Collection<CarFeature>(),
                DateImported = DateTime.Now,
                Status = Constants.CAR_AVAILABLE
            };
            _carRepository.Add(car);
            return car;
        }
        private bool OnSaveCanExecute()
        {
            //if car is not loaded return false
            if(Car == null)
            {
                return false;
            }
            bool allFieldsAreUsed = true;
            foreach (PropertyInfo prop in Car.GetType().GetProperties())
            {
                
                Type type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                switch (Type.GetTypeCode(type))
                {
                    case TypeCode.Int32:
                    case TypeCode.Decimal:
                        if ((prop.GetValue(Car, null) == null || (int)prop.GetValue(Car) == 0) && prop.Name != "Id" )
                        {
                            allFieldsAreUsed = false;
                        }
                        break;
                    case TypeCode.String:
                        if (prop.GetValue(Car, null) == null || (string)prop.GetValue(Car) == "")
                        {
                            allFieldsAreUsed = false;
                        }
                        break;
                }
            }
            return Car != null
              && !Car.HasErrors
              && allFieldsAreUsed
              && HasChanges;
        }
    }
}
