using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using RaceDay.DAO.Interfaces;
using RaceDay.DAO.Logic;
using RaceDay.Providers;
using RaceDay.Providers.Interfaces;

namespace RaceDay.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<RaceDao>().As<IRaceDao>().SingleInstance();
            builder.RegisterType<RaceHorsesDao>().As<IRaceHorsesDao>().SingleInstance();
            builder.RegisterType<HorseDao>().As<IHorseDao>().SingleInstance();
            builder.RegisterType<CustomerDao>().As<ICustomerDao>().SingleInstance();
            builder.RegisterType<CustomerBetsDao>().As<ICustomerBetsDao>().SingleInstance();

            builder.RegisterType<RaceProvider>().As<IRaceProvider>().SingleInstance();
            builder.RegisterType<CustomerProvider>().As<ICustomerProvider>().SingleInstance();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
