using Autofac;
using Nlayer.Core.IUnitOfWork;
using Nlayer.Core.Repositories;
using Nlayer.Core.Services;
using Nlayer.Repository;
using Nlayer.Repository.Repositories;
using Nlayer.Repository.UnıtOfWork;
using Nlayer.Service.Mapping;
using Nlayer.Service.Services;
using System.Reflection;

namespace Nlayer.Web.Modules
{
    public class RepoServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>));
            builder.RegisterType<UnitOfWork>().As<IUnitOFWork>();



            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));




            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service"))
           .AsImplementedInterfaces().InstancePerLifetimeScope();




            //InstancePerLifetimeScope => Add.Scope//bir request baslayıp bitene kadar aynısıjnı kullan

            //InstancePerDependency=>transiet

        }

    }
}
