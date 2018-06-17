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

        public CarWrapper(IndividualCar model) : base(model)
        {
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
            set { SetValue(value); }
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
            set { SetValue(value); }
        }
        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(CarModel):
                    if (string.Equals(CarModel.Model, "Oleg", StringComparison.OrdinalIgnoreCase))
                    {
                        yield return "Robots are not valid friends";
                    }
                    break;

            }
        }
    }
}
