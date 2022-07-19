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
    public class CategoryServices
    {
        #region setup the context connection variable and class constructor
        //variable to hold an instance of context class
        private readonly WestWindContext _context;

        //constructor to create an instance of the registered context class
        internal CategoryServices(WestWindContext regcontext)
        {
            _context = regcontext;
        }

        #endregion

        #region Service: Queries

        public List<Category> Category_List()
        {
            // _content: using the context instance
            // Categories: using the DbSet property
            // .OrderBy(x => x.entitypropertyname
            // .ToList: convert IEnumerable<T> to the desired List<T>
            return _context.Categories.OrderBy(x => x.CategoryName).ToList();
        }

        #endregion

    }
}
