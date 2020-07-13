using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
#pragma warning restore CS0618 // Type or member is obsolete
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//table[1]/tbody[1]")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }

        internal void Listings()
        {

            GlobalDefinitions.waitClickableElement(GlobalDefinitions.driver, "XPath", "//section[@class = 'nav-secondary']/div/a[3]");
            manageListingsLink.Click();
            GlobalDefinitions.TurnOnWait();
            for(int i = 1; i<=10; i++)
            {
                var titletext = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[ " + i + "]/td[3]"));
                //Console.WriteLine(all.Text);
                GlobalDefinitions.ExcelLib.PopulateInCollection(@"C:\marsframework\MarsFramework\ExcelData\TestDataManageListings.xlsx", "ManageListings");
                if (titletext.Text == (GlobalDefinitions.ExcelLib.ReadData(2, "Title")))
                    //(GlobalDefinitions.ExcelLib.ReadData(2, "Title")))
                {
                    IWebElement deleteSkill = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[8]/div/button[3]"));
                    deleteSkill.Click();

                    //Select no from the two options
                    //IWebElement noOption = GlobalDefinitions.driver.FindElement(By.CssSelector("button.ui.negative.button"));
                    //noOption.Click();

                    //Select yes from the two options
                    IWebElement yesOption = GlobalDefinitions.driver.FindElement(By.CssSelector("button.ui.icon.positive.right.labeled.button"));
                    yesOption.Click();
                    Console.WriteLine("Record deleted");
                    return;
                }
            }
            
            }

        internal void editManageListings()
        {
            GlobalDefinitions.waitClickableElement(GlobalDefinitions.driver, "XPath", "//section[@class = 'nav-secondary']/div/a[3]");
            manageListingsLink.Click();
            GlobalDefinitions.TurnOnWait();
            for (int i = 1; i <= 10; i++)
            {
                var titletext = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[ " + i + "]/td[3]"));
                //Console.WriteLine(all.Text);
                GlobalDefinitions.ExcelLib.PopulateInCollection(@"C:\marsframework\MarsFramework\ExcelData\TestDataManageListings.xlsx", "ManageListings");
                if (titletext.Text == (GlobalDefinitions.ExcelLib.ReadData(2, "Title")))
                //(GlobalDefinitions.ExcelLib.ReadData(2, "Title")))
                {
                    //Click on Edit
                    IWebElement editSkill = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id= 'listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[8]/div/button[2]"));
                    editSkill.Click();
                    Console.WriteLine("Record deleted");
                    return;
                }
            }

            
                    
                
            }
        internal void validatedeleteskill()
        {
            GlobalDefinitions.TurnOnWait();
            var deletemsg = GlobalDefinitions.driver.FindElement(By.CssSelector("div.ns-box-inner")).Text;
            Console.WriteLine(deletemsg);
            Assert.AreEqual(deletemsg, "Selenium has been deleted");
        }
        internal void ValidateEdit()
        {
            //String Vaddskill = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[3])[1]")).Text;
            //Assert.AreEqual((GlobalDefinitions.ExcelLib.ReadData(2, "Title")), Vaddskill);
            GlobalDefinitions.TurnOnWait();
            for (int i = 1; i <= 10; i++)
            {
                var titletext = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[ " + i + "]/td[3]"));
                //Console.WriteLine(all.Text);
                GlobalDefinitions.ExcelLib.PopulateInCollection(@"C:\marsframework\MarsFramework\ExcelData\TestDataManageListings.xlsx", "ManageListings");
                if (titletext.Text == (GlobalDefinitions.ExcelLib.ReadData(2, "Title")))

                {
                    Console.WriteLine("Record edited");
                    return;
                }
            }
        }
    }


        
    }

