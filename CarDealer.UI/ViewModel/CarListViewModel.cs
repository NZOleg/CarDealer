using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
using CarDealer.UI.Event;
using CarDealer.UI.Wrapper;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.ViewModel
{
    class CarListViewModel : ViewModelBase, ICarListViewModel
    {
        private IEventAggregator _eventAggregator;
        private ICarRepository _carRepository;


        public ObservableCollection<CarListItemViewModel> Cars { get; set; }
        public CarFiltersViewModel CarFiltersViewModel { get; set; }

        public CarListViewModel(ICarRepository carRepository, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _carRepository = carRepository;
            Cars = new ObservableCollection<CarListItemViewModel>();
            CarFiltersViewModel = new CarFiltersViewModel(_eventAggregator);
            _eventAggregator.GetEvent<FilterHasChangedEvent>()
                 .Subscribe(FilterHasChanged);
        }

        private async void FilterHasChanged(FilterHasChangedEventArgs obj)
        {
            var cars = await _carRepository.ApplyFilterAsync(CarFiltersViewModel);
            Cars.Clear();
            foreach (var car in cars)
            {
                Cars.Add(new CarListItemViewModel(car, _eventAggregator));

            }
        }

        public async Task LoadAsync()
        {
            var cars = await _carRepository.ApplyFilterAsync(CarFiltersViewModel);
            foreach(var car in cars)
            {
                Cars.Add(new CarListItemViewModel(car, _eventAggregator));

            }
            
        }
    }
}
