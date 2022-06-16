using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string MyName { get; set; }

        public void OnGet()
        {
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
        }
    }
}