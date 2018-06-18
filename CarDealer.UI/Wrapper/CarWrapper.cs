using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.Wrapper
{
    class CarWrapper : ModelWrapper<IndividualCar>
    {
        public bool ModelHasChanged { get; set; }
        public bool FeaturesHasChanged { get; set; }
        public CarWrapper(IndividualCar model) : base(model)
        {
            ModelHasChanged = false;
            FeaturesHasChanged = false;

        }



        public int Id
        {
            get { return GetValue<int>(); }
        }
        public string Colour
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string ImageUri
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public int? CurrentMileage
        {
            get { return GetValue<int?>(); }
            set { SetValue(value); }
        }
        public DateTime DateImported
        {
            get { return GetValue<DateTime>(); }
            set {
                if (value > DateTime.Today) {
                    SetValue(DateTime.Today);
                } SetValue(value);
            }
        }

        public int? ManufactureYear
        {
            get { return GetValue<int?>(); }
            set { SetValue(value); }
        }

        public int? AskingPrice
        {
            get { return GetValue<int?>(); }
            set { SetValue(value); }
        }

        

        
        public string Transmission
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string Status
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string BodyType
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        

        public CarModel CarModel
        {
            get { return GetValue<CarModel>(); }
            set { SetValue(value);
                OnPropertyChanged();
                ModelHasChanged = true;
            }
        }

        public CarSale CarSale
        {
            get { return GetValue<CarSale>(); }
            set { SetValue(value); }
        }

        public Collection<CarFeature> CarFeatures
        {
            get { return GetValue<Collection<CarFeature>>(); }
            set {
                SetValue(value);
                OnPropertyChanged();
                FeaturesHasChanged = true;
            }
        }

    }
}
