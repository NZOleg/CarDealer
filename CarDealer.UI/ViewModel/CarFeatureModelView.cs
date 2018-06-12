using CarDealer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.ViewModel
{
    class CarFeatureModelView : ViewModelBase
    {
        private bool _isChecked;

        public bool IsChecked
        {
            get { return _isChecked; }
            set {
                _isChecked = value;
                OnPropertyChanged();
            }
        }

        private CarFeature _carFeature;

        public CarFeature CarFeature
        {
            get { return _carFeature; }
            set { _carFeature = value; }
        }

        public CarFeatureModelView(CarFeature carFeature)
        {
            CarFeature = carFeature;
        }
    }
}
