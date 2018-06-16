using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
using CarDealer.UI.Wrapper;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CarDealer.UI.ViewModel
{
    class AddEditEmployeeViewModel : ViewModelBase, IAddEditEmployeeViewModel
    {
        private IPersonRepository _personRepository;
        private EmployeeWrapper _employee;

        public EmployeeWrapper Employee
        {
            get { return _employee; }
            set
            {

                _employee = value;
                OnPropertyChanged();
            }
        }
        private bool _hasChanges;
        public bool HasChanges
        {
            get { return _hasChanges; }
            set
            {
                if (_hasChanges != value)
                {
                    _hasChanges = value;
                    OnPropertyChanged();
                    ((DelegateCommand<PasswordBox>)SaveCommand).RaiseCanExecuteChanged();
                }
            }
        }

        private IEventAggregator _eventAggregator;

        public DelegateCommand<PasswordBox> SaveCommand { get; }
        public DelegateCommand DeleteCommand { get; }

        public AddEditEmployeeViewModel(IPersonRepository personRepository, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            SaveCommand = new DelegateCommand<PasswordBox>(OnSaveCommandExecute);
            DeleteCommand = new DelegateCommand(OnDeleteCommandExecute);
            _personRepository = personRepository;
        }

        private async void OnDeleteCommandExecute()
        {
            _personRepository.RemoveEmployee(Employee.Model);
            await _personRepository.SaveAsync();
        }

        private async void OnSaveCommandExecute(PasswordBox password)
        {
            Employee.Person.Password = password.Password;
            await _personRepository.SaveAsync();

        }

        public async Task LoadAsync(int? id)
        {
            Employee employee;
            if (id == null)
            {
                employee = createNewEmployee();
            }
            else
            {
                employee = await _personRepository.GetEmployeeByIdAsync((int)id);
            }
            InitializeEmployee(employee);
        }

        private void InitializeEmployee(Employee employee)
        {
            Employee = new EmployeeWrapper(employee);
            Employee.PropertyChanged += (s, e) =>
            {
                if (!HasChanges)
                {
                    HasChanges = _personRepository.HasChanges();
                }
                if (e.PropertyName == nameof(Employee.HasErrors))
                {
                    ((DelegateCommand<PasswordBox>)SaveCommand).RaiseCanExecuteChanged();
                }
            };
            ((DelegateCommand<PasswordBox>)SaveCommand).RaiseCanExecuteChanged();
        }

        private Employee createNewEmployee()
        {
            Employee employee = new Employee
            {
                Person = new Person()
            };
            _personRepository.AddEmployee(employee);
            return employee;
        }
    }
}
