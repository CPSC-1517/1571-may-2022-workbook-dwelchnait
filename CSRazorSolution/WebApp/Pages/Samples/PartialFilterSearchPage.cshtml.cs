using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using WestWindSystem.BLL;       //this is where the services were coded
using WestWindSystem.Entities;  //this is where the entity definition is coded
using WebApp.Helpers;
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

        #region Paginator
        //my desired page size
        private const int PAGE_SIZE = 5;
        //be able to hold an instance of the Paginator
        public Paginator Pager { get; set; }

        #endregion

        public void OnGet(int? currentPage)
        {
            PopulateLists();

            //the paginator will call this OnGet() method
            //the requested page enters the method via currentPage

            PopulateTable(currentPage);

        }

        public void PopulateTable(int? currentPage)
        {
            if (!string.IsNullOrWhiteSpace(searcharg))
            {
                //setting up for using the Paginator only needs to be done if
                //  a query is executing

                //determine the current page number
                int pagenumber = currentPage.HasValue ? currentPage.Value : 1;
                //setup the current state of the paginator (sizing)
                PageState current = new(pagenumber, PAGE_SIZE);
                //temporary local integer to hold the results of the query's total collection size
                //  this will be need by the Paginator during the paginator's execution
                int totalcount;

                //we need to pass paging data into our query so that efficiencies in the
                //  system will ONLY return the amount of records to actually be display
                //  on the browser page.

                TerritoryInfo = _territoryServices.GetByPartialDescription(searcharg,
                                    pagenumber, PAGE_SIZE, out totalcount);

                //create the needed Pagnator instance
                Pager = new Paginator(totalcount, current);
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
            else
            {
                //this needs to be commented out ONCE you have installed paging in the
                //      RedirecToPage version of this example.

                //TerritoryInfo = _territoryServices.GetByPartialDescription(searcharg);
                PopulateTable(1);
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
