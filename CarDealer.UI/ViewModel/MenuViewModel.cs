using CarDealer.DataAccess;
using CarDealer.UI.Event;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarDealer.UI.ViewModel
{
    class MenuViewModel : ViewModelBase, IMenuViewModel
    {
        private IEventAggregator _eventAggregator;

        public ICommand CreateNewCarCommand { get; set; }
        public DelegateCommand<object> CreateNewCustomerCommand { get; }
        public DelegateCommand<object> CreateNewEmployeeCommand { get; }
        public DelegateCommand<object> ShowCustomerListCommand { get; }
        public DelegateCommand<object> ShowEmployeeListCommand { get; }
        public DelegateCommand<object> ShowCarListCommand { get; }
        public DelegateCommand<object> ShowSaleListCommand { get; }
        public DelegateCommand<object> LogoutCommand { get; }
        public DelegateCommand<object> ShowMyProfileCommand { get; }
        public DelegateCommand<object> ShowMyCarsCommand { get; }
        public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }
        public Person Person { get; private set; }

        public MenuViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            CreateNewCarCommand = new DelegateCommand<object>(OnCreateNewCarExecute);
            CreateNewCustomerCommand = new DelegateCommand<object>(OnCreateNewCustomerExecute);
            CreateNewEmployeeCommand = new DelegateCommand<object>(OnCreateNewEmployeeExecute);
            ShowCustomerListCommand = new DelegateCommand<object>(ShowCustomerListExecute);
            ShowEmployeeListCommand = new DelegateCommand<object>(ShowEmployeeListExecute);
            ShowCarListCommand = new DelegateCommand<object>(ShowCarListExecute);
            ShowSaleListCommand = new DelegateCommand<object>(ShowSaleListExecute);
            LogoutCommand = new DelegateCommand<object>(LogoutExecute);
            ShowMyProfileCommand = new DelegateCommand<object>(ShowMyProfileExecute);
            ShowMyCarsCommand = new DelegateCommand<object>(ShowMyCarsExecute);
        }

        private void ShowMyCarsExecute(object obj)
        {
            _eventAggregator.GetEvent<ShowMyCarsEvent>().Publish(new ShowMyCarsEventArgs
            {
                Id = Person.Id
            });
        }

        private void ShowMyProfileExecute(object obj)
        {
            _eventAggregator.GetEvent<OpenCustomerDetailViewEvent>().Publish(new OpenCustomerDetailViewEventArgs
            {
                Id = Person.Id
            });
        }

        private void ShowEmployeeListExecute(object obj)
        {
            _eventAggregator.GetEvent<OpenEmployeeListEvent>().Publish(new OpenEmployeeListEventArgs());
        }

        private void OnCreateNewCustomerExecute(object obj)
        {
            _eventAggregator.GetEvent<AddEditCustomerEvent>().Publish(new AddEditCustomerEventArgs
            {
                Id = null
            });
        }

        private void OnCreateNewEmployeeExecute(object obj)
        {
            _eventAggregator.GetEvent<AddEditEmployeeEvent>().Publish(new AddEditEmployeeEventArgs
            {
                Id = null
            });
        }

        private void ShowSaleListExecute(object obj)
        {
            _eventAggregator.GetEvent<OpenSaleListEvent>().Publish(new OpenSaleListEventArgs());
        }

        public void Load(string role, Person person)
        {
            Person = person;
            switch (role)
            {
                 case "admin": MenuItems = GetAdminMenu();
                    break;
                case "staff":
                    MenuItems = GetStaffMenu();
                    break;
                case "customer":
                default:
                    MenuItems = GetCustomerMenu();
                    break;
            }
            
        }

        private ObservableCollection<MenuItemViewModel> GetCustomerMenu()
        {
            ObservableCollection<MenuItemViewModel> customerMenuItems = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel("List of Cars", ShowCarListCommand),
                new MenuItemViewModel("My Profile", ShowMyProfileCommand),
                new MenuItemViewModel("My Cars", ShowMyCarsCommand),
                new MenuItemViewModel("Logout", LogoutCommand)

            };

            return customerMenuItems;
        }

        private ObservableCollection<MenuItemViewModel> GetStaffMenu()
        {
            ObservableCollection<MenuItemViewModel> adminMenuItems = new ObservableCollection<MenuItemViewModel>();
            ObservableCollection<MenuItemViewModel> saleMenuItems = new ObservableCollection<MenuItemViewModel>()
            {
                new MenuItemViewModel("List of Sold Cars", ShowSaleListCommand)
            };
            ObservableCollection<MenuItemViewModel> carMenuItems = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel("Add a New Car", CreateNewCarCommand),
                new MenuItemViewModel("Display All Cars", ShowCarListCommand)
            };
            ObservableCollection<MenuItemViewModel> CustomerMenuItems = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel("Add a New Customer", CreateNewCustomerCommand),
                new MenuItemViewModel("Display All Customer", ShowCustomerListCommand),
            };
            adminMenuItems.Add(new MenuItemViewModel("Cars", null, carMenuItems));
            adminMenuItems.Add(new MenuItemViewModel("Sales", null, saleMenuItems));
            adminMenuItems.Add(new MenuItemViewModel("Customers", null, CustomerMenuItems));
            adminMenuItems.Add(new MenuItemViewModel("Logout", LogoutCommand));
            return adminMenuItems;
        }

        private ObservableCollection<MenuItemViewModel> GetAdminMenu()
        {
            ObservableCollection<MenuItemViewModel> adminMenuItems = new ObservableCollection<MenuItemViewModel>();
            ObservableCollection<MenuItemViewModel> saleMenuItems = new ObservableCollection<MenuItemViewModel>()
            {
                new MenuItemViewModel("List of Sold Cars", ShowSaleListCommand)
            };
            ObservableCollection<MenuItemViewModel> carMenuItems = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel("Add a New Car", CreateNewCarCommand),
                new MenuItemViewModel("Display All Cars", ShowCarListCommand)
            };
            ObservableCollection<MenuItemViewModel> CustomerMenuItems = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel("Add a New Customer", CreateNewCustomerCommand),
                new MenuItemViewModel("Display All Customer", ShowCustomerListCommand),
            };
            ObservableCollection<MenuItemViewModel> EmployeeMenuItems = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel("Add a New Employee", CreateNewEmployeeCommand),
                new MenuItemViewModel("Display All Employees", ShowEmployeeListCommand)
            };
            adminMenuItems.Add(new MenuItemViewModel("Cars", null, carMenuItems));
            adminMenuItems.Add(new MenuItemViewModel("Sales", null, saleMenuItems));
            adminMenuItems.Add(new MenuItemViewModel("Customers", null, CustomerMenuItems));
            adminMenuItems.Add(new MenuItemViewModel("Employees", null, EmployeeMenuItems));
            adminMenuItems.Add(new MenuItemViewModel("Logout", LogoutCommand ));
            return adminMenuItems;
        }

        private void LogoutExecute(object obj)
        {
            _eventAggregator.GetEvent<AfterLogoutEvent>().Publish(new AfterLogoutEventArgs());
        }

        private void ShowCarListExecute(object obj)
        {
            _eventAggregator.GetEvent<OpenCarListEvent>().Publish(new OpenCarListEventArgs());
        }

        private void ShowCustomerListExecute(object obj)
        {
            _eventAggregator.GetEvent<OpenCustomerListEvent>().Publish(new OpenCustomerListEventArgs());
        }

        private void OnCreateNewCarExecute(object obj)
        {
            _eventAggregator.GetEvent<AddEditCarEvent>().Publish(new AddEditCarEventArgs
            {
                Id = null
            });
        }
    }
}
