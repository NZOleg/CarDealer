using CarDealer.UI.Event;
using CarDealer.UI.Helpers;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.ViewModel
{
    public class CarFiltersViewModel : ViewModelBase
    {
        public CarFiltersViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            SortByPopularity = SortBySalesEnum.MostPopular;
        }

        private int? _numberOfCars;

        public int? NumberOfCars
        {
            get { return _numberOfCars; }
            set {
                _numberOfCars = value;
                OnPropertyChanged();
                _eventAggregator.GetEvent<FilterHasChangedEvent>().Publish(new FilterHasChangedEventArgs());
            }
        }


        private string _manufacturer;

        public string Manufacturer
        {
            get { return _manufacturer; }
            set
            {
                _manufacturer = value;
                OnPropertyChanged();
                _eventAggregator.GetEvent<FilterHasChangedEvent>().Publish(new FilterHasChangedEventArgs());
            }
        }

        private SortBySalesEnum _sortByPopularity;

        public SortBySalesEnum SortByPopularity
        {
            get { return _sortByPopularity; }
            set {
                _sortByPopularity = value;
                OnPropertyChanged();
                _eventAggregator.GetEvent<FilterHasChangedEvent>().Publish(new FilterHasChangedEventArgs());
            }
        }


        private string _model;

        public string Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged();
                _eventAggregator.GetEvent<FilterHasChangedEvent>().Publish(new FilterHasChangedEventArgs());
            }
        }
        private string _bodyType;

        public string BodyType
        {
            get { return _bodyType; }
            set { _bodyType = value;
                OnPropertyChanged();
                _eventAggregator.GetEvent<FilterHasChangedEvent>().Publish(new FilterHasChangedEventArgs());
            }
        }
        private int? _engineSizeMin;

        public int? EngineSizeMin
        {
            get { return _engineSizeMin; }
            set {
                _engineSizeMin = value;
                OnPropertyChanged();
                _eventAggregator.GetEvent<FilterHasChangedEvent>().Publish(new FilterHasChangedEventArgs());
            }
        }
        private int? _engineSizeMax;

        public int? EngineSizeMax
        {
            get { return _engineSizeMax; }
            set {
                _engineSizeMax = value;
                OnPropertyChanged();
                _eventAggregator.GetEvent<FilterHasChangedEvent>().Publish(new FilterHasChangedEventArgs());
            }
        }
        private int? _manufactureYearMin;

        public int? ManufactureYearMin
        {
            get { return _manufactureYearMin; }
            set {
                _manufactureYearMin = value;
                OnPropertyChanged();
                _eventAggregator.GetEvent<FilterHasChangedEvent>().Publish(new FilterHasChangedEventArgs());
            }
        }
        private int? _manufactureYearMax;

        public int? ManufactureYearMax
        {
            get { return _manufactureYearMax; }
            set {
                _manufactureYearMax = value;
                OnPropertyChanged();
                _eventAggregator.GetEvent<FilterHasChangedEvent>().Publish(new FilterHasChangedEventArgs());
            }
        }
        private string _transmission;

        public string Transmission
        {
            get { return _transmission; }
            set {
                _transmission = value;
                OnPropertyChanged();
                _eventAggregator.GetEvent<FilterHasChangedEvent>().Publish(new FilterHasChangedEventArgs());
            }
        }
        private int? _mileageMin;

        public int? MileageMin
        {
            get { return _mileageMin; }
            set {
                _mileageMin = value;
                OnPropertyChanged();
                _eventAggregator.GetEvent<FilterHasChangedEvent>().Publish(new FilterHasChangedEventArgs());
            }
        }

        private int? _mileageMax;

        public int? MileageMax
        {
            get { return _mileageMax; }
            set {
                _mileageMax = value;
                OnPropertyChanged();
                _eventAggregator.GetEvent<FilterHasChangedEvent>().Publish(new FilterHasChangedEventArgs());
            }
        }

        private string _colour;

        public string Colour
        {
            get { return _colour; }
            set {
                _colour = value;
                OnPropertyChanged();
                _eventAggregator.GetEvent<FilterHasChangedEvent>().Publish(new FilterHasChangedEventArgs());
            }
        }
        private int? _askingPriceMin;

        public int? AskingPriceMin
        {
            get { return _askingPriceMin; }
            set {
                _askingPriceMin = value;
                OnPropertyChanged();
                _eventAggregator.GetEvent<FilterHasChangedEvent>().Publish(new FilterHasChangedEventArgs());
            }
        }

        private int? _askingPriceMax;
        private IEventAggregator _eventAggregator;

        public int? AskingPriceMax
        {
            get { return _askingPriceMax; }
            set {
                _askingPriceMax = value;
                OnPropertyChanged();
                _eventAggregator.GetEvent<FilterHasChangedEvent>().Publish(new FilterHasChangedEventArgs());
            }
        }



    }
}
