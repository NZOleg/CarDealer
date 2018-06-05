using Autofac;
using CarDealer.DataAccess;
using CarDealer.UI.Data.Repositories;
using CarDealer.UI.ViewModel;

namespace CarDealer.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<PersonRepository>().As<IPersonRepository>();
            builder.RegisterType<LoginViewModel>().As<ILoginViewModel>();
            builder.RegisterType<CarDealerDbContext>().AsSelf();
            return builder.Build();
        }
    }
}
