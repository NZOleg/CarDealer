using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
using CarDealer.UI.Wrapper;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        public DelegateCommand SaveImage { get; }

        public AddEditCarViewModel(ICarRepository carRepository, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            SaveCommand = new DelegateCommand(OnSaveCommandExecute);
            DeleteCommand = new DelegateCommand(OnDeleteCommandExecute);
            SaveImage = new DelegateCommand(OnSaveImageExecute);
            _carRepository = carRepository;
            CarFeatures = new ObservableCollection<CarFeatureModelView>();
        }

        private void OnSaveImageExecute()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            openFileDialog.Title = "Select a Car Image";
            openFileDialog.ShowDialog(); 
            if (openFileDialog.CheckFileExists && openFileDialog.CheckPathExists)
            {
                File.Copy(openFileDialog.FileName, Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\images\\" + openFileDialog.SafeFileName);
            }
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
            Car.CarFeatures = await GetSelectedFeatures();
            await _carRepository.SaveAsync();
                
        }

        private async Task<Collection<CarFeature>> GetSelectedFeatures()
        {
            Collection<CarFeature> carFeatures = await _carRepository.GetAllCarFeatures();
            foreach (CarFeature carFeature in carFeatures)
            {
                if (carFeature.IndividualCars.Any(ic => ic.CarID == Car.CarID))
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
                currentFeaturesId.Add(carfeature.FeatureID);
            }


            foreach (CarFeature carFeature in carFeatures)
            {
                if (currentFeaturesId.Contains(carFeature.FeatureID)){

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
                CarFeatures = new Collection<CarFeature>(),
                Date_Imported = DateTime.Now
            };
            _carRepository.Add(car);
            return car;
        }
    }
}
