using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.ViewModel
{
    class SaleListViewModel : ViewModelBase, ISaleListViewModel
    {
        private IEventAggregator _eventAggregator;
        private ICarRepository _carRepository;

        public ObservableCollection<SaleListItemViewModel> Sales { get; set; }



        public SaleListViewModel(ICarRepository carRepository, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _carRepository = carRepository;
            Sales = new ObservableCollection<SaleListItemViewModel>();
        }
        public async Task LoadAsync()
        {
            Collection<Cars_Sold> sales= await _carRepository.GetAllSalesAsync();
            foreach(Cars_Sold sale in sales)
            {
                Sales.Add(new SaleListItemViewModel(sale, _eventAggregator));
            }
        }
    }
}
