using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Samples
{
    public class BasicDataManagementModel : PageModel
    {
        // BindProperty is an annotation that handles two-way data transfer
        // two-way? means output to form for display AND input from form for processing
        [BindProperty]
        public int Num { get; set; }
        [BindProperty]
        public string MassText { get; set; }
        [BindProperty]
        public int FavouriteCourse { get; set; }

        public string Feedback { get; set; }
        public void OnGet()
        {
            if (Num == 0)
            {
                Feedback = "executing the OnGet method for the Get request";
            }
            else
            {
                Feedback = $"You entered the value {Num} display by OnGet";
            }
        }

        public void OnPost()
        {
            if (Num == 0)
            {
                Feedback = "executing the OnPost method for a value of zero";
            }
            else
            {
                Feedback = $"You entered the value {Num} (display by OnPost)" +
                $" your mass text is {MassText} and I like the {FavouriteCourse} course.";
            }
        }
    }
}
