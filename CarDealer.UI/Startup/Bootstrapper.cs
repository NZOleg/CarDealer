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
            builder.RegisterType<AddEditEmployeeViewModel>().As<IAddEditEmployeeViewModel>();
            builder.RegisterType<CarDetailViewModel>().As<ICarDetailViewModel>();
            builder.RegisterType<EmployeeDetailViewModel>().As<IEmployeeDetailViewModel>();
            builder.RegisterType<SaleDetailViewModel>().As<ISaleDetailViewModel>();
            builder.RegisterType<CustomerDetailViewModel>().As<ICustomerDetailViewModel>();
            builder.RegisterType<CarListViewModel>().As<ICarListViewModel>();
            builder.RegisterType<EmployeeListViewModel>().As<IEmployeeListViewModel>();
            builder.RegisterType<CustomerListViewModel>().As<ICustomerListViewModel>();
            builder.RegisterType<CheckoutViewModel>().As<ICheckoutViewModel>();
            builder.RegisterType<SaleListViewModel>().As<ISaleListViewModel>();
            builder.RegisterType<MyCarsViewModel>().As<IMyCarsViewModel>();
            builder.RegisterType<CarDealerDbContext>().AsSelf();
            return builder.Build();
        }
    }
}
