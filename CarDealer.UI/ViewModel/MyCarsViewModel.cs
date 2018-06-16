using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.ViewModel
{
    class MyCarsViewModel : ViewModelBase, IMyCarsViewModel
    {
        private IPersonRepository _personRepository;


        public ObservableCollection<Cars_Sold> Cars { get; set; }

        public MyCarsViewModel(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            Cars = new ObservableCollection<Cars_Sold>();
        }

        public async Task LoadAsync(int id)
        {
            var cars = await _personRepository.GetAllCustomerCars(id);
            Cars = new ObservableCollection<Cars_Sold>(cars);

        }
    }
}
