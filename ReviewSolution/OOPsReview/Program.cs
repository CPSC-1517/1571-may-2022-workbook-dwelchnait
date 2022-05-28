// See https://aka.ms/new-console-template for more information
//this class is by default in the namespace of the project: OOPsReview

//an instance class needs to be created using the new command and the class constructor
//one needs to declare a variable of class datatype: ex Employment

//using the "using statement" means that one does NOT need to fully qualify on EACH
//   usage of the class
using OOPsReview.Data;

// fully qualified reference to Employment
// consists of the namespace.classname
//OOPsReview.Data.Employment myEmp = new OOPsReview.Data.Employment("Level 5 Programer", SupervisoryLevel.Supervisor, 15.9); //default contructor

Employment myEmp = new Employment("Level 5 Programer", SupervisoryLevel.Supervisor,15.9); //default contructor
Console.WriteLine(myEmp.ToString()); //use the instance name to reference items within your class
Console.WriteLine($"{myEmp.Title},{myEmp.Level},{myEmp.Years}");


myEmp.SetEmploymentResponsibilityLevel(SupervisoryLevel.DepartmentHead);

Console.WriteLine(myEmp.ToString());

//testing (simulate a Unit test)
//Arrange (setup of your test data)
Employment Job = null;

//passing a reference variable to a method
//a class is a reference data store
//this passes the actual memory address of the data store to the method
//ANY changes done to the data store within the method WILL BE reflected
//  in the data store WHEN you return from the method

CreateJob(ref Job);
Console.WriteLine(Job.ToString());
//passing value arguments to a method AND receiving a value result back from
//  the method
//struct is a value data store
ResidentAddress Address = CreateAddress();
Console.WriteLine(Address.ToString());

//Act (execution of the test you wish to perform)
//test that we can create a Person (composite instance)
Person me = null; //a variable capable of holding a Person instance
me = CreatePerson(Job, Address);

//Access (check your results)
Console.WriteLine($"{me.FirstName} {me.LastName} lives at {me.Address.ToString()}" +
    $" having a job count of {me.NumberOfPositions}");

void CreateJob(ref Employment job)
{
    //since the class MAY throw exceptions, you should have user friendly error handling
    try
    {
        job = new Employment(); //default constructor; new command takes a constructor as it's reference
        //BECAUSE my properties have public set (mutators), I can "set" the value of the
        //  proporty directly from the driver program
        job.Title = "Boss";
        job.Level = SupervisoryLevel.Owner;
        job.Years = 25.5;

        //OR

        //use the greedy constructor
        //job = new Employment("Boss", SupervisoryLevel.Owner, 25.5);



    }
    catch (ArgumentNullException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);

    }
}

ResidentAddress CreateAddress()
{
    //greedy constructor
    ResidentAddress address = new ResidentAddress(10706, "106 st", "",
                                                            "", "Edmonton", "AB");
    return address;
}

Person CreatePerson(Employment job, ResidentAddress address)
{
    Person me = new Person("Don", "Welch", address, null);
    me.AddEmployment(job);
    return me;
}