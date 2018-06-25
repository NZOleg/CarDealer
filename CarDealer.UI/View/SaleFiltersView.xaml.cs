using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarDealer.UI.View
{
    /// <summary>
    /// Interaction logic for SaleFiltersView.xaml
    /// </summary>
    public partial class SaleFiltersView : UserControl
    {
        public SaleFiltersView()
        {
            InitializeComponent();
        }

        private void _calendar_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
        {
            _calendar.DisplayMode = CalendarMode.Year;
        }

        private void _calendar_OnLoaded(object sender, RoutedEventArgs e)
        {
            _calendar.DisplayMode = CalendarMode.Year;
        }
    }
}
