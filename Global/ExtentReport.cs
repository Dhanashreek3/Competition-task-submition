using MarsFramework.Config;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RazorEngine.Compilation.ImpromptuInterface;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Global
    {
        [TestFixture]
        public static class ExtentReport
        {
        public static ExtentTest test;
        public static ExtentReports extent;

        //paths for the reports

        public static string ReportPath = MarsResource.ReportPath;
            public static string ReportXmlPath = MarsResource.ReportXMLPath;
        private static char bin;

        //OneTimeSetup
        public static void InitializeReport()
            {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            
            var reportPath = MarsResource.ReportPath + "MyownReport.html";
            //Boolean value for replacing exisisting report
            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);

            //Add QA system info to html report

            extent.AddSystemInfo("Host Name", "SkillSwap")

                .AddSystemInfo("Environment", "YourQAEnvironment")

                .AddSystemInfo("Username", "Dhanashree");
                        
            //Adding config.xml file
            //Get the config.xml file from http://extentreports.com
            extent.LoadConfig(ReportXmlPath);
            }

            //TearDown
            public static void AfterTest()
            {
               
                    //StackTrace details for failed Testcases

                    var status = TestContext.CurrentContext.Result.Outcome.Status;

                    var stackTrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
                    var errorMessage = TestContext.CurrentContext.Result.Message;

                    if (status == TestStatus.Failed)
                    {

                       // String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, MarsResource.ScreenShotPath);//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                    
                        test.Log(LogStatus.Fail, status + errorMessage);

                        //test.Log(LogStatus.Fail, status + "Image example: " + img);

                    }

                    else if (status == TestStatus.Passed)
                    {

                        //String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, MarsResource.ScreenShotPath);//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");

                        test.Log(LogStatus.Pass, "Test Passed");
                    }

                    else if (status == TestStatus.Skipped)
                    {

                        //String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, MarsResource.ScreenShotPath);//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");

                        test.Log(LogStatus.Skip, "Test Skipped");
                    }
                    //End test report

                    extent.EndTest(test);
                    //driver.Quit();


                
                
            }

            //OneTimeTearDown
            public static void EndReport()
            {

                //End Report

                extent.Flush();

                extent.Close();
            }
        }
    }


