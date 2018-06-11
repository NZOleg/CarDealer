using CarDealer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.Wrapper
{
    class CustomerWrapper : ModelWrapper<Person>
    {
        public CustomerWrapper(Person model) : base(model)
        {
        }
        public int PersonID
        {
            get { return GetValue<int>(); }
        }
        public string Name
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string Address
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string Telephone
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string Username
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string Licence_Number
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public int Age
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }
        public DateTime License_Expiry_Date
        {
            get { return GetValue<DateTime>(); }
            set { SetValue(value); }
        }
        public ICollection<Cars_Sold> Cars_Sold
        {
            get { return GetValue<ICollection<Cars_Sold>>(); }
            set { SetValue(value); }
        }
        public Customer Customer
        {
            get { return GetValue<Customer>(); }
            set { SetValue(value); }
        }
    }
}
