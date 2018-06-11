using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
using System;
using System.Collections.Generic;
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



        public int CarID
        {
            get { return GetValue<int>(); }
        }
        public string Colour
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public int Current_Mileage
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }
        public DateTime Date_Imported
        {
            get { return GetValue<DateTime>(); }
            set { SetValue(value); }
        }

        public int Manufacture_Year
        {
            get { return GetValue<int>(); }
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
        public string Body_Type
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public int Model_ID
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }
        public CarModel CarModel
        {
            get { return GetValue<CarModel>(); }
            set { SetValue(value);
                OnPropertyChanged();
            }
        }

        public Cars_Sold Cars_Sold
        {
            get { return GetValue<Cars_Sold>(); }
            set { SetValue(value); }
        }

        public List<CarFeature> CarFeatures
        {
            get { return GetValue<List<CarFeature>>(); }
            set { SetValue(value); }
        }
    }
}
