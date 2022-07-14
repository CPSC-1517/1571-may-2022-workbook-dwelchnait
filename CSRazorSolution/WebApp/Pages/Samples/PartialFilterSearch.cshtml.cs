using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using WestWindSystem.BLL;       //this is where the services were coded
using WestWindSystem.Entities;  //this is where the entity definition is coded
#endregion


namespace WebApp.Pages.Samples
{
    public class PartialFilterSearchModel : PageModel
    {
        #region Private service fields & class constructor
        private readonly TerritoryServices _territoryServices;
        private readonly RegionServices _regionServices;

        public PartialFilterSearchModel(TerritoryServices territoryservices,
                                        RegionServices regionservices)
        {
            _territoryServices = territoryservices;
            _regionServices = regionservices;
        }
        #endregion

        [TempData]
        public string Feedback { get; set; }

        //this is bond to the input control via asp-for
        //this is a two way binding out and in
        //data is move out and in FOR YOU AUTOMATICALLY
        //SupportsGet = true will allow this property to be matched to
        //  a routing parameter of the same name.
        [BindProperty(SupportsGet = true)]
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
            //check to see if there is a search arg before doing the call to the service
            if(!string.IsNullOrWhiteSpace(searcharg))
            {
                TerritoryInfo = _territoryServices.GetByPartialDescription(searcharg);
            }
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
            //the receiving "searcharg" is the routing parameter
            //the sending "searcharg" is a BindProperty field
            //the RedirectToPage causes a Get requested to be placed
            //  on the stack for processing when control is reeturned
            //  to the browser
            //Since the processing of this request causes a second
            //  trip to the server for processing, data needs to be retained
            //  between the two trips; hence the use of the routing  parameter
            //This is different then Page() which DOES NOT cause a Get request
            //  to be placed on the stack.
            return RedirectToPage(new { searcharg = searcharg });
        }

        public IActionResult OnPostClear()
        {
            Feedback = "";
            searcharg = null;
            ModelState.Clear();
            return RedirectToPage(new { searcharg = (string?)null });
        }

        public IActionResult OnPostNew()
        {
            return RedirectToPage("/Samples/ReceivingPage");
        }

    }
}
