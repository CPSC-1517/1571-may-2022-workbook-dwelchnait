using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

#region Additional Namespaces
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WestWindSystem.DAL;
using WestWindSystem.BLL;

#endregion

namespace WestWindSystem
{
    public static class BackEndExtensions
    {
        public static void WWBackendDependencies(this IServiceCollection services,
           Action<DbContextOptionsBuilder> options )
        {
            //we will register all the services that will
            //  be used by the system (context setup)
            //  and will be provided by the system (BLL services)

            //register the context service
            //options contents the connection string information
            services.AddDbContext<WestWindContext>(options);

            //register EACH service class (BLL classes)
            //each service class will have an AddTransient<T>() method

            //use the AddTransient<T>() method where T is your BLL class name
            //AddTrainsient is called a factory
            //I read my lamda symbol => as "do the following ...."
            services.AddTransient<BuildVersionServices>((serviceProvider) =>
            {
                //get the Context class that was registed above in AddDbContext
                var context = serviceProvider.GetService<WestWindContext>();

                //create an instance of the service class (BuildVersionServices)
                //      supplying the context reference to the serivce class
                return new BuildVersionServices(context);
            });


        }
    }
}
