using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using WestWindSystem.BLL;       //this is where the services were coded
using WestWindSystem.Entities;  //this is where the entity definition is coded
#endregion


namespace WebApp.Pages.Samples
{
    public class RegionQueryOneModel : PageModel
    {
        #region Private service fields & class constructor
        private readonly RegionServices _regionServices;

        public RegionQueryOneModel(RegionServices regionservices)
        {
            _regionServices = regionservices;
        }
        #endregion

        public string FeedbackMessage { get; set; }

        //this is bond to the input control via asp-for
        //this is a two way binding out and in
        //data is move out and in FOR YOU AUTOMATICALLY
        [BindProperty()]
        public int regionid { get; set; }

        public Region regionInfo { get; set; }

        //the List<T> has a null value as the page is created
        //you can initialize the property to an instance as the page is
        //      being created by adding = new() to your declaration
        //if you do, you will have an empty instance of List<T>
        [BindProperty]
        public List<Region> regionsList { get; set; } = new();

        [BindProperty]
        public int selectRegion { get; set; }

        public void OnGet()
        {
            //since the internet is a stateless environment, you need to 
            //  obtain any list data that is required by your controls or local
            //  logic on EVERY instance of the page being processed
            PopulateLists();

        }

        private void PopulateLists()
        {
            //this method will obtain the data for any require list to be used
            //      in populating controls or for local logic
            regionsList = _regionServices.Region_List();
        }

        

        // specific post method to use in conjunction with asp-page-handler="xxx"
        public IActionResult OnPostFetch()
        {
            if (regionid < 1)
            {
                FeedbackMessage = "Required: Region id is a non-zero positive whole number.";
            }
            

            else
            {
                RetrieveRegion(regionid);
            }
            PopulateLists();
            
            return Page();
        }

        public IActionResult OnPostSelect()
        {
            if (selectRegion < 1)
            {
                FeedbackMessage = "Required: Region id is a non-zero positive whole number.";
            }


            else
            {
                RetrieveRegion(selectRegion);
            }
            PopulateLists();

            return Page();
        }
        // specific post method to use in conjunction with asp-page-handler="xxx"
        public IActionResult OnPostClear()
        {
            FeedbackMessage = "";
            //regionid = 0;
            ModelState.Clear();
            return Page();
        }
        public void RetrieveRegion(int id)
        {
            regionInfo = _regionServices.Region_GetByID(id);
            if (regionInfo == null)
            {
                FeedbackMessage = "Region id is not valid. No such region on file";
            }
            else
            {
                FeedbackMessage = $"ID: {regionInfo.RegionID} Description: {regionInfo.RegionDescription}";
            }
        }
    }
}
