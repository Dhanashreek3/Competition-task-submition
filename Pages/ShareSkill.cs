using AutoItX3Lib;
using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
#pragma warning restore CS0618 // Type or member is obsolete
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.XPath, Using = "//div[@class = 'right item']/a")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        private IWebElement ServiceTypeOptions { get; set; }

        //Select the One-off Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field'][2]")]
        private IWebElement ServiceTypeOneOf { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.XPath, Using = "//div[@class = 'fields']/div[4]/input")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement Days { get; set; }

        //Click on Monday Check box 
        [FindsBy(How = How.Name, Using = "//input[@index='1']")]
        private IWebElement Monday { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTime { get; set; }



        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

      





        internal void EnterShareSkill()
        {
            //Click on Share Skill button

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(GlobalDefinitions.driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(60);
            fluentWait.PollingInterval = TimeSpan.FromSeconds(3);
            /* Ignore the exception - NoSuchElementException that indicates that the element is not present */
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";
            GlobalDefinitions.driver.FindElement(By.XPath("//a[@href = '/Home/ServiceListing']")).Click();


            Global.GlobalDefinitions.ExcelLib.PopulateInCollection(@"C:\marsframework\MarsFramework\ExcelData\TestDataShareSkill.xlsx", "ShareSkill");
            //Enter title
            Title.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            //Enter description
            Description.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            //Select category from the dropdown
            SelectElement cd = new SelectElement(CategoryDropDown);
            cd.SelectByText(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
            //Select subcategory from the dropdown
            SelectElement scd = new SelectElement(SubCategoryDropDown);
            scd.SelectByText(Global.GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));
            //Send data in tag field and press enter 
            Tags.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);
            //Select service type radiobutton
            ServiceTypeOptions.Click();
            //Select Location type radiobutton
            LocationTypeOption.Click();
            //Select Start Date DropDown 
            StartDateDropDown.Click();
            //Enter end date
            EndDateDropDown.SendKeys("09082020");
            //Click on days
            Days.Click();
           
            //Select start time
            StartTime.Click();
            StartTimeDropDown.SendKeys("1024PM");
            //Select end time
            EndTimeDropDown.SendKeys("1126PM");
            //Select SkillTradeOption radiobutton
            SkillTradeOption.Click();
            //Send data in SkillExchange and press enter
            SkillExchange.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
            SkillExchange.SendKeys(Keys.Enter);

            //Click on Worksample and upload the image
            IWebElement worksample = Global.GlobalDefinitions.driver.FindElement(By.CssSelector("i.huge.plus.circle.icon.padding-25"));
            worksample.Click();
            Thread.Sleep(30000);
            {

                var procStartInfo = new System.Diagnostics.ProcessStartInfo(@"C:\marsframework\FileUpload1.exe");

                var proc = new System.Diagnostics.Process { StartInfo = procStartInfo };

                proc.Start();

                proc.WaitForExit(1000);
                //proc.Kill();
                
                    if (proc.HasExited)
                    {

                        //Select active radiobutton
                        ActiveOption.Click();
                        //Click on Save button
                        Save.Click();

                    }
                
            }
            
                      
            
        }
        internal void Validateaddmessage()
        {
            //String Vaddskill = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[3])[1]")).Text;
            //Assert.AreEqual((GlobalDefinitions.ExcelLib.ReadData(2, "Title")), Vaddskill);
            /*
            for (int i = 1; i <= 10; i++)
            {
                var titletext = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[ " + i + "]/td[3]"));
                //Console.WriteLine(all.Text);
                GlobalDefinitions.ExcelLib.PopulateInCollection(@"C:\marsframework\MarsFramework\ExcelData\TestDataManageListings.xlsx", "ManageListings");
                if (titletext.Text == (GlobalDefinitions.ExcelLib.ReadData(2, "Title")))

                {
                    Console.WriteLine("Assertion passed");
                    return;
                }
            }*/
            
           
            Thread.Sleep(500);
            
            //var Visiblewait = new WebDriverWait(GlobalDefinitions.driver, new TimeSpan(0, 0, 10));
            //var element = Visiblewait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.ns-box-inner")));*/
            var addmsg = GlobalDefinitions.driver.FindElement(By.CssSelector("div.ns-box-inner")).Text;

            Console.WriteLine(addmsg);
            Assert.AreEqual(addmsg, "Service Listing Added successfully");

        }

        internal void EditShareSkill()
        {
            GlobalDefinitions.waitClickableElement(GlobalDefinitions.driver, "XPath", "//div[@class = 'right item']/a");
            //Enter title
            GlobalDefinitions.ExcelLib.PopulateInCollection(@"C:\marsframework\MarsFramework\ExcelData\TestDataShareSkill.xlsx", "ShareSkill");
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            //Enter Description
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            //Select category from the dropdown
            SelectElement cd = new SelectElement(CategoryDropDown);
            cd.SelectByText(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
            //Select subcategory from the dropdown
            SelectElement scd = new SelectElement(SubCategoryDropDown);
            scd.SelectByText(Global.GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));
            //Send data in tag field and press enter 
            Tags.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);
            //Select service type radiobutton
            ServiceTypeOptions.Click();
            //Select Location type radiobutton
            LocationTypeOption.Click();
            //Select Start Date DropDown 
            StartDateDropDown.Click();
            //Enter end date
            EndDateDropDown.SendKeys("09082020");
            //Click on days
            Days.Click();
            //Select start time
            StartTime.Click();
            StartTimeDropDown.SendKeys("1024PM");
            //Select end time
            EndTimeDropDown.SendKeys("1126PM");
            //Select SkillTradeOption radiobutton
            SkillTradeOption.Click();
            //Send data in SkillExchange and press enter
            SkillExchange.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
            SkillExchange.SendKeys(Keys.Enter);
            //Select active radiobutton
            ActiveOption.Click();
            //Click on Save button
            Save.Click();
        }

    }
}
