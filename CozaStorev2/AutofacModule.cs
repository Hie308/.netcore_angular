using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
namespace CozaStorev2
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method. All of this starts
            // with the services.AddAutofac() that happens in Program and registers Autofac
            // as the service provider.
            var dataAccess = System.Reflection.Assembly.GetExecutingAssembly();
            //builder.RegisterType<CustomerContext>()
            //    .As<CustomerContext>()
            //    .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes()
                .Where(t => t.Name.EndsWith("Context"))
                .InstancePerLifetimeScope();
        }
    }
}
