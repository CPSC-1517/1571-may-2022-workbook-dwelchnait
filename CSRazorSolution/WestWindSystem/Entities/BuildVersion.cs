using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWindSystem.Entities
{
    public class BuildVersion
    {
        //in sql nvarchar(),varchar,nchar,char is declared as a string in your
        //  Entity definition!!!!!!!!!
        //sql bit is a bool in C#
        public int Id { get; set; }
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}
