using CarDealer.UI.Event;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
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

        public MenuViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            CreateNewCarCommand = new DelegateCommand<object>(OnCreateNewCarExecute);
            ShowCustomerListCommand = new DelegateCommand<object>(ShowCustomerListExecute);
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
