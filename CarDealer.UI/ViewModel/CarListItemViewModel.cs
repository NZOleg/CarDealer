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
    public class CarListItemViewModel : ViewModelBase, ICarListItemViewModel
    {
        private IndividualCar _car;

        public IndividualCar Car
        {
            get { return _car; }
            set {
                _car = value;
                OnPropertyChanged();
            }
        }

        private IEventAggregator _eventAggregator;

        public DelegateCommand OpenCarDetailViewCommand { get; private set; }

        public string DisplayName
        {
            //get { return Car.CarModel.Manufacturer + " " + Car.CarModel.Model + " " +  Car.ManufactureYear; }
            get { return $"{Car.CarModel.Manufacturer,20} {Car.CarModel.Model,20} {Car.ManufactureYear,20} {Car.BodyType,20} {Car.Transmission,20} {Car.CurrentMileage+"km",20} {Car.CarModel.EngineSize + "cc",20} {"$" + Car.AskingPrice, 20}"; }
        }


        public CarListItemViewModel(IndividualCar car, IEventAggregator eventAggregator)
        {
            Car = car;
            _eventAggregator = eventAggregator;
            OpenCarDetailViewCommand = new DelegateCommand(OpenCarDetailViewExecute);

        }

        private void OpenCarDetailViewExecute()
        {
            _eventAggregator.GetEvent<OpenCarDetailViewEvent>().Publish(new OpenCarDetailViewEventArgs
            {
                Id = Car.Id
            });
        }
    }
}
