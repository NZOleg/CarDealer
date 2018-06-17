using CarDealer.DataAccess;
using CarDealer.UI.Event;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.ViewModel
{
    class SaleListItemViewModel : ViewModelBase
    {
        private CarSale _sale;

        public CarSale Sale
        {
            get { return _sale; }
            set { _sale = value; }
        }

        public string DisplayName
        {
            get { return Sale.Date + " " + Sale.Customer.Person.Username + " " + Sale.IndividualCar.CarModel.Manufacturer + " " + Sale.IndividualCar.CarModel.Model; }
        }

        private IEventAggregator _eventAggregator;

        public DelegateCommand OpenSaleDetailViewCommand { get; }

        public SaleListItemViewModel(CarSale cars_Sold, IEventAggregator eventAggregator)
        {
            Sale = cars_Sold;
            _eventAggregator = eventAggregator;
            OpenSaleDetailViewCommand = new DelegateCommand(OpenSaleDetailViewExecute);
        }

        private void OpenSaleDetailViewExecute()
        {
            _eventAggregator.GetEvent<OpenSaleDetailViewEvent>().Publish(new OpenSaleDetailViewEventArgs
            {
                Sale = Sale
            });
        }
    }
}
