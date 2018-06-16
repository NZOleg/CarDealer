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
    class EmployeeListItemViewModel : ViewModelBase
    {
        private Employee _employee;

        public Employee Employee
        {
            get { return _employee; }
            set
            {
                _employee = value;
                OnPropertyChanged();
            }
        }

        private IEventAggregator _eventAggregator;

        public DelegateCommand OpenEmployeeDetailViewCommand { get; private set; }

        public string DisplayName
        {
            get { return Employee.Person.Username; }
        }


        public EmployeeListItemViewModel(Employee employee, IEventAggregator eventAggregator)
        {
            Employee = employee;
            _eventAggregator = eventAggregator;
            OpenEmployeeDetailViewCommand = new DelegateCommand(OpenEmployeeDetailViewExecute);

        }

        private void OpenEmployeeDetailViewExecute()
        {
            _eventAggregator.GetEvent<OpenEmployeeDetailViewEvent>().Publish(new OpenEmployeeDetailViewEventArgs
            {
                Id = Employee.EmployeeID
            });
        }
    }
}
