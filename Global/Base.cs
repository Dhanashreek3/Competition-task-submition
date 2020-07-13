using MarsFramework.Config;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using RelevantCodes.ExtentReports.Model;
using System;
using System.Threading;
using static MarsFramework.Global.GlobalDefinitions;


namespace MarsFramework.Global
{
    class Base
    {
        #region To access Path from resource file

        public static int Browser = Int32.Parse(MarsResource.Browser);
        public static String ExcelPath = MarsResource.ExcelPath;
        public static string ScreenshotPath = MarsResource.ScreenShotPath;
        public static string ReportPath = MarsResource.ReportPath;
        #endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;

        #endregion


        #region setup and tear down
        [SetUp]
        public void Inititalize()
        {

            // advisasble to read this documentation before proceeding http://extentreports.relevantcodes.com/net/
            switch (Browser)
            {

                case 1:
                    GlobalDefinitions.driver = new FirefoxDriver();
                    break;
                case 2:
                    GlobalDefinitions.driver = new ChromeDriver();
                    GlobalDefinitions.driver.Manage().Window.Maximize();
                    break;


            }
            GlobalDefinitions.Wait();
            GlobalDefinitions.driver.Navigate().GoToUrl(MarsResource.Url);

            #region Initialise Reports

            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(MarsResource.ReportXMLPath);


            #endregion

            if (MarsResource.IsLogin == "true")
            {
                SignIn loginobj = new SignIn();
                loginobj.LoginSteps();
            }
            else
            {
                SignUp obj = new SignUp();
                obj.register();
            }

        }
        [OneTimeSetUp]
        public void BeforeTestFixture()
        {
            ExtentReport.InitializeReport();
        }

        [OneTimeTearDown]
        public void AfterTestFixture()
        {
           
            
            ExtentReport.EndReport();
        }
        [TearDown]
        public void TearDown()
        {
            // Screenshot
            //String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
            //test.Log(LogStatus.Info, "Image example: " + img);
            ExtentReport.AfterTest();
            
            // Close the driver :)            
            //GlobalDefinitions.driver.Close();
            //GlobalDefinitions.driver.Quit();
        }

        
        #endregion


    }
}