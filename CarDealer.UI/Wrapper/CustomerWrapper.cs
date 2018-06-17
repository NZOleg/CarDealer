using CarDealer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.Wrapper
{
    class CustomerWrapper : ModelWrapper<Customer>
    {
        public CustomerWrapper(Customer model) : base(model)
        {
        }
        public string LicenceNumber
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public int Age
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }
        public DateTime LicenseExpiryDate
        {
            get { return GetValue<DateTime>(); }
            set { SetValue(value); }
        }

        public ICollection<CarSale> CarsSold
        {
            get { return GetValue<ICollection<CarSale>>(); }
            set { SetValue(value); }
        }
        public Person Person
        {
            get { return GetValue<Person>(); }
            set { SetValue(value); }
        }
    }
}
