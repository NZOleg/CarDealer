using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.ViewModel
{
    class EmployeeListViewModel : ViewModelBase, IEmployeeListViewModel
    {
        public ObservableCollection<EmployeeListItemViewModel> Employees { get; set; }

        private IEventAggregator _eventAggregator;
        private IPersonRepository _peopleRepository;

        public EmployeeListViewModel(IPersonRepository peopleRepository, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _peopleRepository = peopleRepository;
            Employees = new ObservableCollection<EmployeeListItemViewModel>();
        }

        public async Task LoadAsync()
        {
            Collection<Employee> employees = await _peopleRepository.GetAllEmployeesAsync();
            foreach (Employee employee in employees)
            {
                Employees.Add(new EmployeeListItemViewModel(employee, _eventAggregator));
            }
        }
    }
}
