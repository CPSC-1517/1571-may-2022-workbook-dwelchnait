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

    //we need to point this entity definition to the sql table that it represents.
    //to do this we use an annotation.
    //annotations are place IMMEDIATELY before the item in the definition it
    //  refers to.
    [Table("BuildVersion")]
    public class BuildVersion
    {
        //in sql nvarchar(),varchar,nchar,char is declared as a string in your
        //  Entity definition!!!!!!!!!
        //sql bit is a bool in C#

        //names of class properties DO NOT need to match the attribute names
        //  on your sql table (entity)
        //HOWEVER, IF you use different names then ORDER is IMPORTANT in this
        //  entity class. It MUST match the order in the sql table.
        //If your property names match then the order within this entity class
        //  is not important. However, it is much easier to match your sql table
        //  to your entity if you maintain the same order for data.

        //annotation to indicate the primary key / property relationship
        //3 syntax forms for the pkey annotation

        // IDENTITY() pkey in sql
        // a) [Key] 

        // Your sql pkey is NOT a IDENTITY() pkey in sql
        // b) [Key]
        //    [DatabaseGeneratedOption(DataseGeneratedOption.None]

        // Your sql pkey is a compound pkey in sql
        // You will need to add the annotation in front of each part of the 
        //      compound key attribute / property to form the correct pkey structure
        // c) [Key]
        //    [Column(Order=n)]

        // https://www.entityframeworktutorial.net/code-first/key-dataannotations-attribute-in-code-first.aspx
        
        //If you have a foreign and your attribute / property names are the same
        //  the system will already known about the fkey relationship; therefore
        //  you DO NOT use the annotation [ForeignKey]

        [Key]
        public int Id { get; set; }
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; }
        public DateTime ReleaseDate { get; set; }

        // you can create a property within your entity that is NOT a data
        //     attribute in your sql table.
        // if you do, use the [NotMapped} annotation

        //Example
        // assume you two separate properties FirstName and Lastname
        // you wish to create a string of FullName
        // you do not wish to force the program to consistently concatenate
        //   the properties in their code
        // you wish to make it easier for the programer by doing the
        //   concatenation for them
        //
        // create a read-only property (just a get) and return the concatenation
        // the program can then use your read-only property
        //
        // The system realizes that this is NOT a database field.

        //[NotMapped]
        //public string FullName { get {return LastName + ", " + Firstname;}}

    }
}
