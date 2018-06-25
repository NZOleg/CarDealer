using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
using CarDealer.UI.Event;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        private Person _currentUser;

        public Person CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }
        public string Role { get; set; }

        private IEventAggregator _eventAggregator;
        private IPersonRepository _personRepository;
        private ILoginViewModel _loginViewModel;

        public ILoginViewModel LoginViewModel
        {
            get { return _loginViewModel; }
            set {
                _loginViewModel = value;
                OnPropertyChanged();
            }
        }

        private Func<IMyCarsViewModel> _myCarsViewModelCreator;
        private Func<IAddEditCarViewModel> _addEditCarViewModelCreator;
        private Func<ILoginViewModel> _loginViewModelCreator;
        private Func<ICheckoutViewModel> _checkoutViewModelCreator;
        private Func<IAddEditCustomerViewModel> _addEditCustomerViewModelCreator;
        private Func<IAddEditEmployeeViewModel> _addEditEmployeeViewModelCreator;
        private Func<ICustomerListViewModel> _customerListViewModelCreator;
        private Func<IEmployeeListViewModel> _employeeListViewModelCreator;
        private Func<IMenuViewModel> _menuViewModelCreator;
        private Func<ICarListViewModel> _carListViewModelCreator;
        private Func<ICarDetailViewModel> _carDetailViewModelCreator;
        private Func<ISaleDetailViewModel> _saleDetailViewModelCreator;
        private Func<ICustomerDetailViewModel> _customerDetailViewModelCreator;
        private Func<IEmployeeDetailViewModel> _employeeDetailViewModelCreator;
        private Func<ISaleListViewModel> _saleListViewModelCreator;
        private dynamic _currentView;

        public dynamic CurrentView
        {
            get { return _currentView; }
            set {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        private IMenuViewModel _menuViewModel;

        public IMenuViewModel MenuViewModel
        {
            get { return _menuViewModel; }
            set { _menuViewModel = value;
                OnPropertyChanged();
            }
        }

        

        public ObservableCollection<Person> people { get; }

        public MainViewModel(IPersonRepository personRepository, ILoginViewModel loginViewModel,
            Func<ICarListViewModel> carListViewModelCreator, Func<IMenuViewModel> menuViewModelCreator,
            Func<IAddEditCarViewModel> addEditCarViewModelCreator, Func<ICarDetailViewModel> carDetailViewModelCreator,
            Func<ICustomerListViewModel> customerListViewModelCreator,Func<IEmployeeListViewModel> employeeListViewModelCreator, Func<ICustomerDetailViewModel> customerDetailViewModelCreator,
            Func<IAddEditCustomerViewModel> addEditCustomerViewModelCreator,Func<ILoginViewModel> loginViewModelCreator,

            Func<IAddEditEmployeeViewModel> addEditEmployeeViewModelCreator,
            Func<ICheckoutViewModel> checkoutViewModelCreator, Func<ISaleListViewModel> saleListViewModelCreator,
            Func<ISaleDetailViewModel> saleDetailViewModelCreator, Func<IEmployeeDetailViewModel> employeeDetailViewModelCreator,
            Func<IMyCarsViewModel> myCarsViewModelCreator,
            IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _personRepository = personRepository;
            
            LoginViewModel = loginViewModel;
            _myCarsViewModelCreator = myCarsViewModelCreator;
            _addEditCarViewModelCreator = addEditCarViewModelCreator;
            _loginViewModelCreator = loginViewModelCreator;
            _checkoutViewModelCreator = checkoutViewModelCreator;
            _addEditCustomerViewModelCreator = addEditCustomerViewModelCreator;
            _addEditEmployeeViewModelCreator = addEditEmployeeViewModelCreator;
            _customerListViewModelCreator = customerListViewModelCreator;
            _employeeListViewModelCreator = employeeListViewModelCreator;
            _menuViewModelCreator = menuViewModelCreator;
            _carListViewModelCreator = carListViewModelCreator;
            _carDetailViewModelCreator = carDetailViewModelCreator;
            _saleDetailViewModelCreator = saleDetailViewModelCreator;
            _customerDetailViewModelCreator = customerDetailViewModelCreator;
            _employeeDetailViewModelCreator = employeeDetailViewModelCreator;
            _saleListViewModelCreator = saleListViewModelCreator;

            people = new ObservableCollection<Person>();
            _eventAggregator.GetEvent<AfterLoginSuccessedEvent>()
                .Subscribe(AfterLoginSuccessed);
            _eventAggregator.GetEvent<AddEditCustomerEvent>()
                .Subscribe(AddEditCustomerAsync);
            _eventAggregator.GetEvent<AddEditEmployeeEvent>()
                .Subscribe(AddEditEmployeeAsync);
            _eventAggregator.GetEvent<AddEditCarEvent>()
                .Subscribe(AddEditCarAsync);
            _eventAggregator.GetEvent<OpenCarDetailViewEvent>()
                .Subscribe(OpenCarDetailsAsync);
            _eventAggregator.GetEvent<OpenCustomerListEvent>()
                .Subscribe(OpenCustomerListAsync);
            _eventAggregator.GetEvent<OpenEmployeeListEvent>()
                .Subscribe(OpenEmployeeListAsync);
            _eventAggregator.GetEvent<OpenCarListEvent>()
                .Subscribe(OpenCarListAsync);
            _eventAggregator.GetEvent<OpenCustomerDetailViewEvent>()
                .Subscribe(OpenCustomerDetailsAsync);
            _eventAggregator.GetEvent<OpenEmployeeDetailViewEvent>()
                .Subscribe(OpenEmployeeDetailsAsync);
            _eventAggregator.GetEvent<OpenSaleDetailViewEvent>()
                .Subscribe(OpenSaleDetailsAsync);
            _eventAggregator.GetEvent<AfterLogoutEvent>()
                .Subscribe(OpenLoginPage);
            _eventAggregator.GetEvent<OpenCheckoutEvent>()
                .Subscribe(OpenCheckoutPageAsync);
            _eventAggregator.GetEvent<OpenSaleListEvent>()
                .Subscribe(OpenSalePageAsync);
            _eventAggregator.GetEvent<OpenMainPageEvent>()
                .Subscribe(OpenMainPageAsync);
            _eventAggregator.GetEvent<ShowMyCarsEvent>()
                .Subscribe(OpenMyCarsAsync);

        }


        private async void OpenMyCarsAsync(ShowMyCarsEventArgs obj)
        {
            CurrentView = _myCarsViewModelCreator();
            await CurrentView.LoadAsync(CurrentUser.Id);
        }

        private async void OpenMainPageAsync(OpenMainPageEventArgs obj)
        {
            if (CurrentUser == null)
            {
                LoginViewModel = _loginViewModelCreator();
                CurrentView = null;
                MenuViewModel = null;
            }
            else
            {
                CurrentView = _carListViewModelCreator();
                await CurrentView.LoadAsync();
            }

        }

        private async void AddEditEmployeeAsync(AddEditEmployeeEventArgs obj)
        {
            CurrentView = _addEditEmployeeViewModelCreator();
            await CurrentView.LoadAsync(obj.Id);
        }

        private async void OpenEmployeeDetailsAsync(OpenEmployeeDetailViewEventArgs obj)
        {
            CurrentView = _employeeDetailViewModelCreator();
            await CurrentView.LoadAsync(obj.Id);
        }

        private void OpenSaleDetailsAsync(OpenSaleDetailViewEventArgs obj)
        {
            CurrentView = _saleDetailViewModelCreator();
            CurrentView.Load(obj.Sale);
        }

        private async void OpenSalePageAsync(OpenSaleListEventArgs obj)
        {
            CurrentView = _saleListViewModelCreator();
            await CurrentView.LoadAsync();
        }

        private async void OpenCheckoutPageAsync(OpenCheckoutEventArgs obj)
        {
            CurrentView = _checkoutViewModelCreator();
            await CurrentView.LoadAsync(obj.Id, CurrentUser.Id);
        }

        private void OpenLoginPage(AfterLogoutEventArgs obj)
        {
            CurrentView = null;
            CurrentUser = null;
            MenuViewModel = null;
            LoginViewModel = _loginViewModelCreator();

        }

        private async void AddEditCustomerAsync(AddEditCustomerEventArgs obj)
        {
            LoginViewModel = null;
            if (CurrentUser == null)
            {
                MenuViewModel = null;
            }

            CurrentView = _addEditCustomerViewModelCreator();
            await CurrentView.LoadAsync(obj.Id);
        }

        private async void OpenCustomerDetailsAsync(OpenCustomerDetailViewEventArgs obj)
        {
            CurrentView = _customerDetailViewModelCreator();
            await CurrentView.LoadAsync(obj.Id);
        }

        private async void OpenCustomerListAsync(OpenCustomerListEventArgs obj)
        {
            //if the event comes from a new customer, go to the login view
            if(CurrentUser == null)
            {
                LoginViewModel = _loginViewModelCreator();
                CurrentView = null;
                MenuViewModel = null;
            }
            else
            {
                CurrentView = _customerListViewModelCreator();
                await CurrentView.LoadAsync();
            }

        }

        private async void OpenEmployeeListAsync(OpenEmployeeListEventArgs obj)
        {
            CurrentView = _employeeListViewModelCreator();
            await CurrentView.LoadAsync();
        }

        private async void OpenCarListAsync(OpenCarListEventArgs obj)
        {
            CurrentView = _carListViewModelCreator();
            await CurrentView.LoadAsync();
        }

        private async void OpenCarDetailsAsync(OpenCarDetailViewEventArgs obj)
        {
            CurrentView = _carDetailViewModelCreator();
            await CurrentView.LoadAsync(obj.Id, CurrentUser);
        }

        private async void AddEditCarAsync(AddEditCarEventArgs obj)
        {
            CurrentView = _addEditCarViewModelCreator();
            await CurrentView.LoadAsync(obj.Id);
        }

        private async void AfterLoginSuccessed(AfterLoginSuccessedEventArgs obj)
        {
            CurrentUser = obj.Person;
            Role = obj.Role;

            LoginViewModel = null;
            CurrentView = _carListViewModelCreator();
            await CurrentView.LoadAsync();
            MenuViewModel = _menuViewModelCreator();
            MenuViewModel.Load(Role, CurrentUser);
        }



        public void Load()
        {
        }

    }

}
