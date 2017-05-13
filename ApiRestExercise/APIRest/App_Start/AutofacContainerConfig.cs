using Autofac;
using Autofac.Integration.WebApi;
using CrossCutting.Exceptions;
using Data;
using Data.Repository;
using DomainCore.Logic.UserLogic;
using DomainCore.Repository;
using DomainLogic.Logic.UserLogic;
using ApplicationServices.ManagementUser;
using System.Reflection;
using System.Web.Http;

namespace APIRest
{
    public static class AutofacContainerConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            var assemblies = new Assembly[]
            {
                typeof(AddUserService).Assembly,
                typeof(UserRepository).Assembly,
                typeof(AddUserLogic).Assembly,
                typeof(IUserLogic).Assembly,
                typeof(IUnitOfWork).Assembly,
                typeof(DataFactory).Assembly,
                typeof(BusinessException).Assembly,

            };
            builder.RegisterAssemblyTypes(assemblies)
              .AsImplementedInterfaces()
              .InstancePerRequest();

            //register web api controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);



        }
    }

}