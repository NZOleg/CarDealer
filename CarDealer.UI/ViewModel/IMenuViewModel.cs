using CarDealer.DataAccess;

namespace CarDealer.UI.ViewModel
{
    public interface IMenuViewModel
    {
        void Load(string role, Person person);
    }
}