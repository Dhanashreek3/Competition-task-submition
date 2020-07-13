using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;

namespace MarsFramework.Global
{
    public class Program 
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

            [Test]
            public void addShareSkill()
            {
                ExtentReport.test = ExtentReport.extent.StartTest("addShareSkill");
                
                ShareSkill ShareSkill = new ShareSkill();
                ShareSkill.EnterShareSkill();
                ShareSkill.Validateaddmessage();
            }

            [Test]
            public void deletemanageSkill()
            {
                ExtentReport.test = ExtentReport.extent.StartTest("deletemanageSkill");
                
                ManageListings ManageListings = new ManageListings();
                ManageListings.Listings();
                ManageListings.validatedeleteskill();
            }

            [Test]
            public void editmanageSkill()
            {
                ExtentReport.test = ExtentReport.extent.StartTest("editmanageSkill");
                
                ManageListings ManageListings = new ManageListings();
                ManageListings.editManageListings();
                
                ShareSkill ShareSkill = new ShareSkill();
                ShareSkill.EditShareSkill();
                ManageListings.ValidateEdit();
            }

            
        }
    }
}