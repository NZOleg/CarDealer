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
    class EmployeeDetailViewModel: ViewModelBase, IEmployeeDetailViewModel
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
        private IPersonRepository _personRepository;

        public DelegateCommand EditEmployeeViewCommand { get; private set; }

        public EmployeeDetailViewModel(IPersonRepository personRepository, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _personRepository = personRepository;
            EditEmployeeViewCommand = new DelegateCommand(EditEmployeeViewExecute);
        }

        private void EditEmployeeViewExecute()
        {
            _eventAggregator.GetEvent<AddEditEmployeeEvent>().Publish(new AddEditEmployeeEventArgs
            {
                Id = Employee.Id
            });
        }

        public async Task LoadAsync(int id)
        {
            Employee = await _personRepository.GetEmployeeByIdAsync(id);

        }
    }
}
