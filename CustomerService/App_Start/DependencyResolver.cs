using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using CustomerService.Data;
using CustomerService.Interfaces;
using CustomerService.Repositories;

namespace CustomerService.App_Start
{
    public class DependencyResolver
    {
        private static IContainer container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().SingleInstance();
            builder.RegisterType<DataProvider>().As<IDataProvider>().SingleInstance();

            container = builder.Build();

            return container;
        }
    }
}