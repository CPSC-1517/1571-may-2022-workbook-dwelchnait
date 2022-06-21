using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    //this web page Model class inherits from PageModel
    public class IndexModel : PageModel
    {
        //this default page uses a system class called ILogger<T>
        //this is composition
        //this is a local field
        private readonly ILogger<IndexModel> _logger;

        //constructor
        //this constructor receive an injection of a service
        //this injection is referred to as Injection Dependency
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

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
            int value = rnd.Next(0,100); //100 is NOT include
            if (value % 2 == 0)
            {
                MyName = $"Don ({value}) welcome to the wide wild world of Razor Pages";
            }
            else
            {
                MyName = null;
            }

            //control is returned to the web server
        }
    }
}