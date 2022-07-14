using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion


namespace WestWindSystem.Entities
{
    [Table("Territories")]
    public class Territory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string TerritoryID { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionID { get; set; }
    }
}
