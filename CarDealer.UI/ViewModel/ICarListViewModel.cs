using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.ViewModel
{
    public interface ICarListViewModel
    {
        Task LoadAsync();
    }
}
