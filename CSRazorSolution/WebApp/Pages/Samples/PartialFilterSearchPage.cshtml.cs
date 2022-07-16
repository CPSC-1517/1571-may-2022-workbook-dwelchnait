using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using WestWindSystem.BLL;       //this is where the services were coded
using WestWindSystem.Entities;  //this is where the entity definition is coded
#endregion


namespace WebApp.Pages.Samples
{
    public class PartialFilterSearchPageModel : PageModel
    {
        #region Private service fields & class constructor
        private readonly TerritoryServices _territoryServices;
        private readonly RegionServices _regionServices;

        public PartialFilterSearchPageModel(TerritoryServices territoryservices,
                                        RegionServices regionservices)
        {
            _territoryServices = territoryservices;
            _regionServices = regionservices;
        }
        #endregion

        public string Feedback { get; set; }

        [BindProperty]
        public string searcharg { get; set; }

        public List<Territory> TerritoryInfo { get; set; }

        //the List<T> has a null value as the page is created
        //you can initialize the property to an instance as the page is
        //      being created by adding = new() to your declaration
        //if you do, you will have an empty instance of List<T>
        [BindProperty]
        public List<Region> RegionList { get; set; } = new();

        public void OnGet()
        {
            PopulateLists();

        }
        public void PopulateLists()
        {
            RegionList = _regionServices.Region_List();
        }

        public IActionResult OnPostFetch()
        {
            if (string.IsNullOrWhiteSpace(searcharg))
            {
                Feedback = "Required: Search argument is empty.";
            }
            else
            {
                //this needs to be commented out ONCE you have installed paging in the
                //      RedirecToPage version of this example.

                //TerritoryInfo = _territoryServices.GetByPartialDescription(searcharg);
            }
            return Page();
        }

        public IActionResult OnPostClear()
        {
            Feedback = "";
            searcharg = null;
            ModelState.Clear();
            return Page();
        }

        public IActionResult OnPostNew()
        {
            return RedirectToPage("/Samples/ReceivingPage");
        }

    }
}
