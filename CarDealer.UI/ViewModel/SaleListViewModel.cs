using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
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

        private Visibility _noCarAlertVisibility;

        public Visibility NoCarAlertVisibility
        {
            get { return _noCarAlertVisibility; }
            set {
                _noCarAlertVisibility = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<SaleListItemViewModel> Sales { get; set; }



        public SaleListViewModel(ICarRepository carRepository, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _carRepository = carRepository;
            Sales = new ObservableCollection<SaleListItemViewModel>();
            NoCarAlertVisibility = Visibility.Hidden;
        }
        public async Task LoadAsync()
        {
            Collection<CarSale> sales= await _carRepository.GetAllSalesAsync();
            foreach(CarSale sale in sales)
            {
                Sales.Add(new SaleListItemViewModel(sale, _eventAggregator));
            }
            if (sales.Count == 0)
            {
                NoCarAlertVisibility = Visibility.Visible;
            }
        }
    }
}
