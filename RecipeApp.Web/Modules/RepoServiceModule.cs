using Autofac;
using Microsoft.Build.Framework;
using RecipeApp.Core.Repositories.Base;
using RecipeApp.Core.Services.Base;
using RecipeApp.Core.Services.Interfaces;
using RecipeApp.Dal.DbContexts;
using RecipeApp.Dal.Repositories.Base;
using RecipeApp.InMemoryCache;
using RecipeApp.Service.Services.Base;
using RecipeApp.Service.Services.Objects;
using System.Reflection;
using Module = Autofac.Module;

namespace RecipeApp.Web.Modules
{
    public class RepoServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<,>)).As(typeof(IService<,>)).InstancePerLifetimeScope();
            var apiAssembly = Assembly.GetExecutingAssembly();
            var repositoryAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(RecipeServicewithNoCaching));

            builder.RegisterType<RecipeServiceWithCaching>().As<IRecipeService>();
            //builder.RegisterType<RecipeServicewithNoCaching>().As<IRecipeService>();

            builder.RegisterAssemblyTypes(apiAssembly, serviceAssembly, repositoryAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, serviceAssembly, repositoryAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
