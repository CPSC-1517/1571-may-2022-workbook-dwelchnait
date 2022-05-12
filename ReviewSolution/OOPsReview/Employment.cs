using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview.Data
{
    public class Employment
    {
        //An instance of this class will hold data about a person's
        //  employment
        //The code of this class is the definition of that data
        //The characteristics (data) of the class
        //  Title, SupervisorLevl, Years of employment within the company

        //there are 4 components of a class definition
        //  data fields (data members)
        //  property
        //  constructor
        //  behaviour (method)

        //data fields
        //  are storage areas in your class
        //  these are treated as variables
        //  these may be public, private, public readonly

        //property
        //These are access techniques to retrieve or set data in
        //  your class without directly touching the storage data field

        //A property is associated with a single instance of data
        //A property is public so it can be access by an outside user
        //  of the class
        //A property MUST have a get
        //A property MAY have a set
        //  if no set, the property is not changable by the user; readonly
        //      commonly used for calculated data of the class
        //  the set can be either public or  private
        //     public: the user can alter the contents of the data
        //     private: only code within the class can alter the contents of the data
        public  string Title
        {
            get;
            set;
        }

    }
}
