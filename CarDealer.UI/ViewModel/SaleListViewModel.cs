using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
using CarDealer.UI.Event;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarDealer.UI.ViewModel
{
    class SaleListViewModel : ViewModelBase, ISaleListViewModel
    {
        private IEventAggregator _eventAggregator;
        private ICarRepository _carRepository;
        private bool _isFilterWorking { get; set; }

        private Visibility _noCarAlertVisibility;

        public Visibility NoCarAlertVisibility
        {
            get { return _noCarAlertVisibility; }
            set {
                _noCarAlertVisibility = value;
                OnPropertyChanged();
            }
        }

        private int _totalCars;

        public int TotalCars
        {
            get { return _totalCars; }
            set
            {
                _totalCars = value;
                OnPropertyChanged();
            }
        }

        private int _totalGrossSales;

        public int TotalGrossSales
        {
            get { return _totalGrossSales; }
            set
            {
                _totalGrossSales = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<SaleListItemViewModel> Sales { get; set; }
        public SaleFiltersViewModel SaleFiltersViewModel { get; }

        public SaleListViewModel(ICarRepository carRepository, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _carRepository = carRepository;
            Sales = new ObservableCollection<SaleListItemViewModel>();
            SaleFiltersViewModel = new SaleFiltersViewModel(_eventAggregator);
            NoCarAlertVisibility = Visibility.Hidden;
            _eventAggregator.GetEvent<SaleFilterHasChangedEvent>()
                .Subscribe(FilterHasChangedAsync);
            _isFilterWorking = false;
        }

        private async void FilterHasChangedAsync(SaleFilterHasChangedEventArgs obj)
        {
            //Since filter is used after any field got changed, we need to make sure 
            //that we are not running more than one process at the time
            if (_isFilterWorking == false)
            {
                _isFilterWorking = true;
                var sales = await _carRepository.ApplySaleFilterAsync(SaleFiltersViewModel, obj.SaleFilter);
                Sales.Clear();
                TotalGrossSales = 0;
                TotalCars = 0;
                foreach (var sale in sales)
                {
                    Sales.Add(new SaleListItemViewModel(sale, _eventAggregator));
                    TotalGrossSales += sale.SalePrice;
                    TotalCars++;
                }

                _isFilterWorking = false;

            }
        }

        public async Task LoadAsync()
        {
            Collection<CarSale> sales= await _carRepository.GetAllSalesAsync();
            TotalGrossSales = 0;
            TotalCars=0;
            foreach (CarSale sale in sales)
            {
                Sales.Add(new SaleListItemViewModel(sale, _eventAggregator));
                TotalGrossSales += sale.SalePrice;
                TotalCars++;
            }
            if (sales.Count == 0)
            {
                NoCarAlertVisibility = Visibility.Visible;
            }
        }
    }
}
