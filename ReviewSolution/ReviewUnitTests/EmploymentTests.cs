using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPsReview.Data;

namespace ReviewUnitTests
{
    [TestClass]
    public class EmploymentTests
    {

        [TestMethod]
        public void CreatingEmployment_GoodDefault_EmploymentMade()
        {

            //Arrange
            string expectedTitle = "Unknown";
            SupervisoryLevel expectedLevel = SupervisoryLevel.TeamMember;
            double expectedYears = 0;
            //Act
            Employment employment = new Employment();
            //Assess
            Assert.AreEqual(expectedTitle, employment.Title, "Default employment title values not as expected:" +
                $"{expectedTitle} vs {employment.Title}");
            Assert.AreEqual(expectedLevel, employment.Level, "Default employment level values not as expected:" +
                $"{expectedLevel} vs {employment.Level}");
            Assert.AreEqual(expectedYears, employment.Years, "Default employment Years values not as expected:" +
                $"{expectedYears} vs {employment.Years}");


        }


        [TestMethod]
        [DataRow("Unit Test Designer", SupervisoryLevel.TeamLeader, 5.5)]
        public void CreatingEmployment_GoodGreedy_EmploymentMade(string title, SupervisoryLevel level, double years)
        {
            //Arrange
            string expectedTitle = "Unit Test Designer";
            SupervisoryLevel expectedLevel = SupervisoryLevel.TeamLeader;
            double expectedYears = 5.5;
            //Act
            Employment employment = new Employment(title, level, years);
            //Assess
            Assert.AreEqual(expectedTitle, employment.Title, "Greedy employment title values not as expected:" +
                $"{expectedTitle} vs {employment.Title}");
            Assert.AreEqual(expectedLevel, employment.Level, "Greedy employment level values not as expected:" +
                $"{expectedLevel} vs {employment.Level}");
            Assert.AreEqual(expectedYears, employment.Years, "Greedy employment Years values not as expected:" +
                $"{expectedYears} vs {employment.Years}");
        }


        //identify the method as a test
        //use DataRow to set up the data for a test (primary data type fields)
        //if you are using an object instance in your testing, it must be setup in the Arrange
        //each DataRow will be run as a separate test (execution of the mehtod)

        [TestMethod]
        [DataRow(" ", SupervisoryLevel.TeamLeader, 5.5)]        //tests for bad title
        [DataRow("Unit Test Designer", SupervisoryLevel.TeamLeader, -5.5)]     //tests for negative years

        public void Employment_BadGreedy_EmploymentNotMade(string title, SupervisoryLevel level, double years)
        {
            try
            {
                //Arrange

                //Act
                Employment employment = new Employment(title, level, years);
                //Assess
                Assert.Fail("Exception was expected and failed to be thrown");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("required"));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsTrue(ex.Message.Length > 0, "Exception contained no message");
            }
            catch (Exception ex)
            {
                // Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");

                Assert.IsFalse(ex.Message.Contains("Assert.Fail"));
                Assert.IsTrue(ex.Message.Length > 0, "Exception contained no message.");
            }
        }

        [TestMethod]
        [DataRow("Unit Test Designer", SupervisoryLevel.Owner, 25.2)]
        public void Employment_ToStringDisplay_GoodDisplay(string title, SupervisoryLevel level, double years)
        {
            try
            {
                //Arrange
                Employment employment = new Employment(title, level, years);

                //Act
                string displayofToString = employment.ToString();

                //Assess
                Assert.AreEqual(displayofToString, "Unit Test Designer,Owner,25.2", $"ToString {employment.ToString()} not as expected.");


            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }
        }
    }
}