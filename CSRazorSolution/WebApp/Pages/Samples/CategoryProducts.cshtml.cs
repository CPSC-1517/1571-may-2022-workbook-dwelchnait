using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using WestWindSystem.BLL;       //this is where the services were coded
using WestWindSystem.Entities;  //this is where the entity definition is coded
using WebApp.Helpers;
#endregion


namespace WebApp.Pages.Samples
{
    public class CategoryProductsModel : PageModel
    {
        #region Private service fields & class constructor
        private readonly CategoryServices _categoryServices;
        private readonly ProductServices _productServices;
        private readonly SupplierServices _supplierServices;


        public CategoryProductsModel(CategoryServices categoryservices,
                                        ProductServices productservices,
                                        SupplierServices supplierServices)
        {
            _categoryServices = categoryservices;
            _productServices = productservices;
            _supplierServices=supplierServices;
        }
        #endregion
        // this property is being used as the routing paramenter
        // the SupportsGet = true indicates that the parameter
        //   supports the OnGet issued by the RedirectToPage()
        [BindProperty(SupportsGet = true)]
        public int? categoryid { get; set; }

        public List<Category> CategoryList { get; set; }

        public List<Supplier> SupplierList { get; set; }
        public List<Product> ProductList { get; set; }

        /// <summary>
        /// why Feedback needs to be carried to the web page which will call
        ///     the OnGet (second trip to server) to obtain the data to display
        ///     on the browser.
        /// </summary>
        [TempData]
        public string Feedback { get; set; }

        public void OnGet()
        {
            if (categoryid.HasValue)
                if (categoryid.Value > 0)
                    ProductList = _productServices.Product_GetByCategory(categoryid.Value);
            PopulateLists();
        }

        public void PopulateLists()
        {
            CategoryList = _categoryServices.Category_List();
            SupplierList = _supplierServices.Supplier_List();

        }

        public IActionResult OnPostSearch()
        {
            if (categoryid == 0)
            {
                Feedback = "Select a category to view the products for maintenance";
            }
            return RedirectToPage(new { categoryid = categoryid });
        }

        public IActionResult OnPostClear()
        {
            Feedback = "";
            categoryid = 0;
            ModelState.Clear();
            return RedirectToPage(new { categoryid = categoryid });
        }

        public IActionResult OnPostNew()
        {
           
            return RedirectToPage("/Samples/CRUDProduct");
        }

    }
}
