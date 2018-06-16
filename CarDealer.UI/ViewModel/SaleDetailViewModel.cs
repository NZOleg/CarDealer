using CarDealer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.ViewModel
{
    class SaleDetailViewModel : ViewModelBase, ISaleDetailViewModel
    {
        private Cars_Sold _sale;

        public Cars_Sold Sale
        {
            get { return _sale; }
            set {
                _sale = value;
                OnPropertyChanged();
            }
        }

        public SaleDetailViewModel()
        {
        }

        public void Load(Cars_Sold sale)
        {
            Sale = sale;
        }
    }
}
