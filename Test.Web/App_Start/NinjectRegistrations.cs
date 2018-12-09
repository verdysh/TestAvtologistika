using System.Configuration;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System.Web.Mvc;
using Test.Services.Articles;
using Test.Services.Users;

namespace Test
{
    public class NinjectRegistrations: NinjectModule
    {
        public static void RegisterDependencies()
        {
            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);
            kernel.Unbind<ModelValidatorProvider>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }

        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IQc1testService>().To<Qc1testService>().WithConstructorArgument(ConfigurationManager.AppSettings["apiArticleServiceBaseUrl"]);
            Bind<IArticleService>().To<ArticleService>();
        }
    }
}