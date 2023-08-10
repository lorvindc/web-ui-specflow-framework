using BoDi;
using WebUISpecflowFramework.ClientDrivers;
using WebUISpecflowFramework.Support;

namespace WebUISpecflowFramework
{
    /// <summary>
    /// Class for managing the tests
    /// </summary>
    [Binding]
    public class TestsManager
    {
        private static IClientDriver clientDriver = null!;
        
        /// <summary>
        /// Setup method runs once before all tests are run
        /// </summary>
        /// <param name="objContainer">Object container</param>
        [BeforeTestRun]
        public static void TestSetup(IObjectContainer objContainer)
        {
            clientDriver = TestConfiguration.TestMode switch
            {
                "Selenium" => new SeleniumClientDriver(),
                _ => throw new Exception("Invalid test mode")
            };

            clientDriver.SetUp();
            objContainer.RegisterInstanceAs(clientDriver);
        }

        [BeforeFeature("BookStoreApp")]
        public static void SetupUser()
        {
            clientDriver.RegisterTestUser();
        }

        [AfterFeature("BookStoreApp")]
        public static void CleanUpUser()
        {
            clientDriver.DeleteTestUser();
        }

        /// <summary>
        /// Teardown method runs once after all tests are run
        /// </summary>
        [AfterTestRun]
        public static void TestTearDown()
        {
            clientDriver.TearDown();
        }

        
    }
}
