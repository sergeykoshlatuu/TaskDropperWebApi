using ItemWebApi.Interfaces;
using ItemWebApi.Models;
using ItemWebApi.Repositorys;
using ItemWebApi.Resolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace ItemWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<ITaskItemRepository<TaskItem>, TaskItemEFRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPeopleRepositiry<Person>, PeopleRepository>(new HierarchicalLifetimeManager());

            //container.RegisterType<ITaskItemRepository<TaskItem>, TaskDapperRepository>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
