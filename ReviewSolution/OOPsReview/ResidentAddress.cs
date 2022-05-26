using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview.Data
{
    //struct is a value variable
    //class is a reference variable
    public struct ResidentAddress
    {
        //data members
        public int Number;
        public string Address1;
        public string Address2;
        private string _Unit;
        private string _City;
        public string ProvinceState;

        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public ResidentAddress(int Number, string Address1, string Address2,
                                string Unit, string City, string ProvinceState)
        {
            //concern: parameter name is exactly the same as the struct/class field/property
            //
            //solution: use the keyword this. on your instance item
            //
            //athe keyword this references to the instance that you are currently
            //      accessing in your program
            
            this.Number = Number;
            this.Address1 = Address1;
            this.Address2 = Address2;
            this.ProvinceState = ProvinceState;

            //for a property, one MUST use a fully implemented property
            //  with the data member, and assign the incoming value
            //  to the data member instead of the property (as can be done in a class)

            _Unit = Unit; 
            _City = City;
        }

        public override string ToString()
        {
            return $"{Number},{Address1},{Address2},{Unit},{City},{ProvinceState}";
        }
    }
}
