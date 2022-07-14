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
    public class TerritoryServices
    {
        #region setup the context connection variable and class constructor
        //variable to hold an instance of context class
        private readonly WestWindContext _context;

        //constructor to create an instance of the registered context class
        internal TerritoryServices(WestWindContext regcontext)
        {
            _context = regcontext;
        }

        #endregion

        #region Services Queries
        public List<Territory> GetByPartialDescription(string partialdescription)
        {
            //This is a typical string filter query
            IEnumerable<Territory> info = _context.Territories
                            .Where(x => x.TerritoryDescription.Contains(partialdescription))
                            .OrderBy(x => x.TerritoryDescription);
            return info.ToList();
        }
        //query by a number
        public List<Territory> GetByRegion(int regionid)
        {
            //This is a typical numeric filter query
            IEnumerable<Territory> info = _context.Territories
                            .Where(x => x.RegionID == regionid)
                            .OrderBy(x => x.TerritoryDescription);
            return info.ToList();
        }
        #endregion
    }
}
