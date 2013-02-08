using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using ZbaBotApi.Controllers;
using ZbaBotApi.Models.Repositories;

namespace ZbaBotApi
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : HttpApplication
    {
        static void ConfigureApi(HttpConfiguration config)
        {
            var unity = new UnityContainer();

            unity.RegisterType<AccountsController>();
            unity.RegisterType<IAccountRepository, AccountRepository>(
                new HierarchicalLifetimeManager());
            
            unity.RegisterType<DocumentationController>();
            unity.RegisterType<IDocumentationRepository, DocumentationRepository>(
                new HierarchicalLifetimeManager());

            config.DependencyResolver = new IoCContainer(unity);
        }

        static void ConfigureDocumentation(HttpConfiguration config)
        {
            config.Services.Replace(typeof (IDocumentationProvider),
                                    new XmlCommentDocumentationProvider(
                                        HttpContext.Current.Server.MapPath("~/App_Data/ZbaBotApi.xml")));
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ConfigureApi(GlobalConfiguration.Configuration);
            ConfigureDocumentation(GlobalConfiguration.Configuration);
        }
    }
}