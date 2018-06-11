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

        private Func<IAddEditCarViewModel> _addEditCarViewModelCreator;
        private Func<IAddEditCustomerViewModel> _addEditCustomerViewModelCreator;
        private Func<ICustomerListViewModel> _customerListViewModelCreator;
        private Func<IMenuViewModel> _menuViewModelCreator;
        private Func<ICarListViewModel> _carListViewModelCreator;
        private Func<ICarDetailViewModel> _carDetailViewModelCreator;
        private Func<ICustomerDetailViewModel> _customerDetailViewModelCreator;
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
            Func<ICustomerListViewModel> customerListViewModelCreator, Func<ICustomerDetailViewModel> customerDetailViewModelCreator,
            Func<IAddEditCustomerViewModel> addEditCustomerViewModelCreator, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _personRepository = personRepository;
            
            LoginViewModel = loginViewModel;

            _addEditCarViewModelCreator = addEditCarViewModelCreator;
            _addEditCustomerViewModelCreator = addEditCustomerViewModelCreator;
            _customerListViewModelCreator = customerListViewModelCreator;
            _menuViewModelCreator = menuViewModelCreator;
            _carListViewModelCreator = carListViewModelCreator;
            _carDetailViewModelCreator = carDetailViewModelCreator;
            _customerDetailViewModelCreator = customerDetailViewModelCreator;

            people = new ObservableCollection<Person>();
            _eventAggregator.GetEvent<AfterLoginSuccessedEvent>()
                .Subscribe(AfterLoginSuccessed);
            _eventAggregator.GetEvent<AddEditCustomerEvent>()
                .Subscribe(AddEditCustomer);
            _eventAggregator.GetEvent<AddEditCarEvent>()
                .Subscribe(AddEditCar);
            _eventAggregator.GetEvent<OpenCarDetailViewEvent>()
                .Subscribe(OpenCarDetails);
            _eventAggregator.GetEvent<OpenCustomerListEvent>()
                .Subscribe(OpenCustomerList);
            _eventAggregator.GetEvent<OpenCustomerDetailViewEvent>()
                .Subscribe(OpenCustomerDetails);

        }

        private void AddEditCustomer(AddEditCustomerEventArgs obj)
        {
            CurrentView = _addEditCustomerViewModelCreator();
            CurrentView.LoadAsync(obj.Id);
        }

        private void OpenCustomerDetails(OpenCustomerDetailViewEventArgs obj)
        {
            CurrentView = _customerDetailViewModelCreator();
            CurrentView.LoadAsync(obj.Id);
        }

        private void OpenCustomerList(OpenCustomerListEventArgs obj)
        {
            CurrentView = _customerListViewModelCreator();
            CurrentView.LoadAsync();
        }

        private void OpenCarDetails(OpenCarDetailViewEventArgs obj)
        {
            CurrentView = _carDetailViewModelCreator();
            CurrentView.LoadAsync(obj.Id);
        }

        private void AddEditCar(AddEditCarEventArgs obj)
        {
            CurrentView = _addEditCarViewModelCreator();
            CurrentView.LoadAsync(obj.Id);
        }

        private async void AfterLoginSuccessed(AfterLoginSuccessedEventArgs obj)
        {
            LoginViewModel = null;
            CurrentView = _carListViewModelCreator();
            await CurrentView.LoadAsync();
            MenuViewModel = _menuViewModelCreator();

            
        }

        public async Task LoadAsync()
        {
           var lookup =  await _personRepository.GetAllAsync();
            people.Clear();
            foreach (var item in lookup)
            {
                people.Add(new Person());
            }
        }
    }

}
