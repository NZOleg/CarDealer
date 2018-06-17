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
            get { return $"{Car.CarModel.Manufacturer,-10} {Car.CarModel.Model,-10} {Car.ManufactureYear,-4} {Car.BodyType,-6} {Car.Transmission,-10} {Car.CurrentMileage, -6}km {Car.CarModel.EngineSize, -4}cc ${Car.AskingPrice, -7}"; }
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
