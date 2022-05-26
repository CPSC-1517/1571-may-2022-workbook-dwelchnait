using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview.Data
{
    public class Person
    {
        //example of a composite class
        //a composite class uses other classes/structs in its definition
        //a conposite class is reconized with the phrase "has a" class
        //this class of Person "has a" resident address
        //this class has a List<T> where <T> represents a datatype and in this
        //  class <T> is a collection of Employment instances

        //review video on inheritence and composite

        //each instance of this class will represent an individual
        //this class will define the following characteristics of a person
        //   First Name, Last Name, the current resident address, List of employment positions

        private string _FirstName;
        private string _LastName;

        public string FirstName
        {
            get { return _FirstName; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First name is required");
                }
                //else { _FirstName = value; }
                _FirstName = value;
            }
        }
        public string LastName
        {
            get { return _LastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Last name is required");
                }
                _LastName = value;
            }
        }

        //composition actually uses the other struct/class as a property/field within
        //  the defintion of the class being specified (created)
        //in this exampel Address is a field (data member)

        //this field is NOT a property
        //the data type is a developer defined datatype (struct)

        public ResidentAddress Address;

        public List<Employment> EmploymentPositions { get; private set; }

        public Person()
        {
            //the system will automatically assign default system values to
            //   our datamembers accordingly to there datatype
            //strings -> null
            //objects -> null
            //
            // firstname and lastname has validation voiding a null value
            FirstName = "Unknown";
            LastName = "Unknown";
            //if one tried to reference an instance's data and the instance is
            //   null THEN one would get a exception: null excepiton
            //even though you have no instances to store, you will at least have
            //  someplace to put the data ONCE it is supplied
            EmploymentPositions = new List<Employment>();
        }
    }
}
