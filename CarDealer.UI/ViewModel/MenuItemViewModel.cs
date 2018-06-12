using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarDealer.UI.ViewModel
{
    class MenuItemViewModel : ViewModelBase
    {
        private string _header;

        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }
        public ICommand MenuItemCommand { get; set; }

        public ObservableCollection<MenuItemViewModel> SubItems { get; set; }
        
        public MenuItemViewModel(string header, ICommand command = null, ObservableCollection<MenuItemViewModel> subItems = null)
        {
            Header = header;
            MenuItemCommand = command;
            SubItems = subItems;
        }

    }
}
