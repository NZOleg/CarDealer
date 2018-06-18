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
    class MyCarsViewModel : ViewModelBase, IMyCarsViewModel
    {
        private IEventAggregator _eventAggregator;
        private IPersonRepository _personRepository;


        public ObservableCollection<SaleListItemViewModel> Cars { get; set; }

        public MyCarsViewModel(IPersonRepository personRepository, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _personRepository = personRepository;
            Cars = new ObservableCollection<SaleListItemViewModel>();

        }

        public async Task LoadAsync(int id)
        {
            var cars = await _personRepository.GetAllCustomerCars(id);
            foreach (var carSale in cars)
            {
                Cars.Add(new SaleListItemViewModel(carSale, _eventAggregator));
            }
            

        }
    }
}
