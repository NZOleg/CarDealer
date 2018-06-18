using CarDealer.DataAccess;
using CarDealer.UI.Event;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            get { return $"{Sale.Date.ToShortDateString(),-10} {Sale.Customer.Person.Username,-10} {Sale.IndividualCar.CarModel.Manufacturer,-10} {Sale.IndividualCar.CarModel.Model,-10} {Sale.IndividualCar.ManufactureYear,-10} {Sale.Customer.Person.Telephone,-15}"; }
        }
        public string FormattedDate { get; set; }

        private IEventAggregator _eventAggregator;

        public DelegateCommand OpenSaleDetailViewCommand { get; }

        public SaleListItemViewModel(CarSale cars_Sold, IEventAggregator eventAggregator)
        {
            Sale = cars_Sold;
            _eventAggregator = eventAggregator;
            OpenSaleDetailViewCommand = new DelegateCommand(OpenSaleDetailViewExecute);
            FormattedDate = cars_Sold.Date.ToString("dddd, d MMM, yyyy");
            
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
