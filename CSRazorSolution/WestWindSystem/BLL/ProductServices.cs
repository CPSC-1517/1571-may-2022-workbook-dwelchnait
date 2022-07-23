using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion


namespace WestWindSystem.BLL
{
    public class ProductServices
    {
        #region setup the context connection variable and class constructor
        //variable to hold an instance of context class
        private readonly WestWindContext _context;

        //constructor to create an instance of the registered context class
        internal ProductServices(WestWindContext regcontext)
        {
            _context = regcontext;
        }

        #endregion

        #region Service: Queries


        public List<Product> Product_GetByCategory(int categoryid)
        {
            return _context.Products
                            .Where(x => x.CategoryID == categoryid)
                            .ToList();

        }

        public Product Product_GetById(int productid)
        {
            return _context.Products
                            .Where(x => x.ProductID == productid)  //filter
                            .FirstOrDefault(); //if found return the first instance else null

        }
        #endregion

    }
}
