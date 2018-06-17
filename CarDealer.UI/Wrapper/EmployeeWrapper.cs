using CarDealer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.Wrapper
{
    class EmployeeWrapper : ModelWrapper<Employee>
    {
        public EmployeeWrapper(Employee model) : base(model)
        {

        }
        public string OfficeAddress
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string PhoneExtensionNumber
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string Role
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public Person Person
        {
            get { return GetValue<Person>(); }
            set { SetValue(value); }
        }
    }
}
