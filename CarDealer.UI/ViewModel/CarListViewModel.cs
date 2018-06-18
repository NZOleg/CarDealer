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
        private bool _isFilterWorking { get; set; }
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
            _isFilterWorking = false;
        }

        private async void FilterHasChanged(FilterHasChangedEventArgs obj)
        {
            //Since filter is used after any field got changed, we need to make sure 
            //that we are not running more than one process at the time
            if (_isFilterWorking == false)
            {
                _isFilterWorking = true;
                var cars = await _carRepository.ApplyFilterAsync(CarFiltersViewModel);
                Cars.Clear();
                foreach (var car in cars)
                {
                    Cars.Add(new CarListItemViewModel(car, _eventAggregator));

                }
                _isFilterWorking = false;
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
