using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.Helpers
{
    public enum SortBySalesEnum
    {
        [Description("Least Popular")]
        LeastPopular = 0,
        [Description("Most Popular")]
        MostPopular = 1
    }

    public enum SaleFilters
    {
        MonthFilter = 0,
        RangeFilter = 1
    }
}
