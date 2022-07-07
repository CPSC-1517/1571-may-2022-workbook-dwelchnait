using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.EntityFrameworkCore;
using WestWindSystem.Entities;

#endregion

namespace WestWindSystem.DAL
{
    //let the access type for this class as internal
    //"internal" access to this class is ONLY possible from
    //      within this class library project
    //Why, it adds a layer of security to the web application

    //DbContext is the entityframework software that talks to the database
    //we inherit the required class

    //Add the NuGet Package: Microsoft.EntityFrameworkCore.SqlServer
    // required for DbContext
    internal class WestWindContext : DbContext
    {
        //the constructor will pass the context connection to the DbContext parent
        //  for use in setting up the database connection
        public WestWindContext(DbContextOptions<WestWindContext> options) : base(options)
        {

        }

        //setup properties in this class that can be referenced by others 
        //  code within your class library
        //the properties represent a collection of instances of the entity
        //  retrieved from or sent to the database
        //one property per entity in Entities
        public DbSet<BuildVersion> BuildVersions { get; set; } 

    }
}
