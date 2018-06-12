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
        public DelegateCommand<object> ShowCustomerListCommand { get; }
        public DelegateCommand<object> ShowCarListCommand { get; }
        public DelegateCommand<object> LogoutCommand { get; }
        public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }

        public MenuViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            CreateNewCarCommand = new DelegateCommand<object>(OnCreateNewCarExecute);
            ShowCustomerListCommand = new DelegateCommand<object>(ShowCustomerListExecute);
            ShowCarListCommand = new DelegateCommand<object>(ShowCarListExecute);
            LogoutCommand = new DelegateCommand<object>(LogoutExecute);
        }
        public void Load(string role)
        {
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
                new MenuItemViewModel("My Profile", ShowCarListCommand),
                new MenuItemViewModel("My Cars", ShowCarListCommand),
                new MenuItemViewModel("Logout", LogoutCommand)

            };

            return customerMenuItems;
        }

        private ObservableCollection<MenuItemViewModel> GetStaffMenu()
        {
            throw new NotImplementedException();
        }

        private ObservableCollection<MenuItemViewModel> GetAdminMenu()
        {
            ObservableCollection<MenuItemViewModel> adminMenuItems = new ObservableCollection<MenuItemViewModel>();
            ObservableCollection<MenuItemViewModel> saleMenuItems = new ObservableCollection<MenuItemViewModel>()
            {
                new MenuItemViewModel("List of Sold Cars"),
                new MenuItemViewModel("Statistics"),
            };
            ObservableCollection<MenuItemViewModel> carMenuItems = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel("Add a New Car", CreateNewCarCommand),
                new MenuItemViewModel("Display All Cars", ShowCarListCommand),
                new MenuItemViewModel("Car Models")
            };
            ObservableCollection<MenuItemViewModel> CustomerMenuItems = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel("Add a New Customer", CreateNewCarCommand),
                new MenuItemViewModel("Display All Customer", ShowCarListCommand),
            };
            ObservableCollection<MenuItemViewModel> EmployeeMenuItems = new ObservableCollection<MenuItemViewModel>
            {
                new MenuItemViewModel("Add a New Employee", CreateNewCarCommand),
                new MenuItemViewModel("Display All Employees", ShowCarListCommand)
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
