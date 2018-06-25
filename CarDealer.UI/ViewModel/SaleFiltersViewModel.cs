using CarDealer.UI.Event;
using CarDealer.UI.Helpers;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.ViewModel
{
    public class SaleFiltersViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;
        private DateTime _selectedMonth;
        private DateTime? _startDate;
        private DateTime? _endDate;




        public SaleFiltersViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            SelectedMonth = DateTime.Today;
        }

        public DateTime SelectedMonth
        {
            get { return _selectedMonth; }
            set
            {
                _selectedMonth = new DateTime(value.Year,value.Month,1);
                OnPropertyChanged();
                _eventAggregator.GetEvent<SaleFilterHasChangedEvent>().Publish(new SaleFilterHasChangedEventArgs {
                    SaleFilter = SaleFilters.MonthFilter
                });
                StartDate = null;
                EndDate = null;
            }
        }

        public DateTime? StartDate
        {
            get { return _startDate; }
            set
            {
                if(value > EndDate)
                {
                    _startDate = EndDate;
                }
                else
                {
                    _startDate = value;
                }

                OnPropertyChanged();
                _eventAggregator.GetEvent<SaleFilterHasChangedEvent>().Publish(new SaleFilterHasChangedEventArgs
                {
                    SaleFilter = SaleFilters.RangeFilter
                });
            }
        }

        public DateTime? EndDate
        {
            get { return _endDate; }
            set
            {
                if (value < StartDate)
                {
                    _endDate = StartDate;
                }
                else
                {
                    _endDate = value;
                }
                OnPropertyChanged();
                _eventAggregator.GetEvent<SaleFilterHasChangedEvent>().Publish(new SaleFilterHasChangedEventArgs
                {
                    SaleFilter = SaleFilters.RangeFilter
                });
            }
        }
    }
}
