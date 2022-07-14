using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestWindSystem.BLL;

#region Additional Namespaces
using WestWindSystem.Entities;
#endregion

namespace WebApp.Pages
{
    //this web page Model class inherits from PageModel
    public class IndexModel : PageModel
    {
        //this default page uses a system class called ILogger<T>
        //this is composition
        //this is a local field
        private readonly ILogger<IndexModel> _logger;
        private readonly BuildVersionServices _buildVersionServices;


        //constructor
        //this constructor receive an injection of a service
        //this injection is referred to as Injection Dependency
        //the second parameter in the list is the injection dependency to be able
        //      to use the BuildVersionSerives we build in our class library
        public IndexModel(ILogger<IndexModel> logger, 
                            BuildVersionServices bvservices)
        {
            _logger = logger;
            _buildVersionServices = bvservices;
        }

        [BindProperty]
        public BuildVersion buildVersionInfo { get; set; }
        //this is a local property
        public string MyName { get; set; }

        //this is a class Behaviour (method)
        //this method, OnGet(), executes for any Get request
        //this method will be the first method executed when the page is first
        //  used.
        //excellent "event" to use to do any initialization to your web page display
        
        public void OnGet()
        {
            //once in the request method, you are in control of what is being
            //  processed on the web page for the current request
            // the code within this method is the work that I WISH to be done
            Random rnd = new Random();
            int value = rnd.Next(0,24); //100 is NOT include
            if (value % 2 == 0)
            {
                MyName = $"Don ({value}) welcome to the wide wild world of Razor Pages";
            }
            else
            {
                MyName = $"{value}";
            }

            //make my first call to the database using the services within
            //  BuildVersionServices of the class library
            buildVersionInfo = _buildVersionServices.GetBuildVersion();
            //control is returned to the web server
        }
    }
}