using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
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
    class CarDetailViewModel : ViewModelBase, ICarDetailViewModel
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
        private ICarRepository _carRepository;

        public DelegateCommand EditCarViewCommand { get; private set; }

        public CarDetailViewModel(ICarRepository carRepository, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _carRepository = carRepository;
            EditCarViewCommand = new DelegateCommand(EditCarViewExecute);
        }

        private void EditCarViewExecute()
        {
            _eventAggregator.GetEvent<AddEditCarEvent>().Publish(new AddEditCarEventArgs
            {
                Id = Car.CarID
            });
        }

        public async Task LoadAsync(int id)
        {
            Car = await _carRepository.GetByIdAsync(id);

        }
    }
}
