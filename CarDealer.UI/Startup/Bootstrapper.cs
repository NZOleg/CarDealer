using Autofac;
using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
using CarDealer.UI.ViewModel;
using Prism.Events;

namespace CarDealer.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<PersonRepository>().As<IPersonRepository>();
            builder.RegisterType<CarRepository>().As<ICarRepository>();
            builder.RegisterType<LoginViewModel>().As<ILoginViewModel>();
            builder.RegisterType<MenuViewModel>().As<IMenuViewModel>();
            builder.RegisterType<AddEditCarViewModel>().As<IAddEditCarViewModel>();
            builder.RegisterType<AddEditCustomerViewModel>().As<IAddEditCustomerViewModel>();
            builder.RegisterType<CarDetailViewModel>().As<ICarDetailViewModel>();
            builder.RegisterType<CustomerDetailViewModel>().As<ICustomerDetailViewModel>();
            builder.RegisterType<CarListViewModel>().As<ICarListViewModel>();
            builder.RegisterType<CustomerListViewModel>().As<ICustomerListViewModel>();
            builder.RegisterType<CarDealerDbContext>().AsSelf();
            return builder.Build();
        }
    }
}
