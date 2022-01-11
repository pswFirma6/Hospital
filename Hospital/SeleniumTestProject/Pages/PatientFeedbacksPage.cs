﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Pages
{
    internal class PatientFeedbacksPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4201/home/patient-feedbacks";

        private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("/html/body/app-root/app-home-page-layout/div/div[2]/app-patient-feedbacks/div/div[2]/table"));
        private IWebElement Approve;
        private IWebElement Reject;


        public int FeedbackCount()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(x => x.FindElement(By.XPath("/html/body/app-root/app-home-page-layout/div/div[2]/app-patient-feedbacks/div/div[2]")));
            return Rows.Count();
        }
        public PatientFeedbacksPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ClickApproveButton(int redniBroj)
        {
            Approve = driver.FindElement(By.XPath("/html/body/app-root/app-home-page-layout/div/div[2]/app-patient-feedbacks/div/div[2]/table/tbody/tr[" + redniBroj + "]/div/div/td[1]/button"));
            Approve.Click();
        }

        public void ApproveButonDisplayed(int redniBroj)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 50));
            wait.Until(x => x.FindElement(By.XPath("/html/body/app-root/app-home-page-layout/div/div[2]/app-patient-feedbacks/div/div[2]/table/tbody/tr[" + redniBroj + "]/div/div/td[1]/button")));
        }

        public void WithDrawClickable(int redniBroj)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 50));
            wait.Until(x => x.FindElement(By.XPath("/html/body/app-root/app-home-page-layout/div/div[2]/app-patient-feedbacks/div/div[2]/table/tbody/tr[" + redniBroj + "]/div/td/button")));
        }

        public void IsFeedbackApproved(int redniBroj)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 50));
            IWebElement State = driver.FindElement(By.XPath("/html/body/app-root/app-home-page-layout/div/div[2]/app-patient-feedbacks/div/div[2]/table/tbody/tr[" + redniBroj + "]/td[4]"));
            wait.Until(x => x.FindElement(By.XPath("/html/body/app-root/app-home-page-layout/div/div[2]/app-patient-feedbacks/div/div[2]/table/tbody/tr[" + redniBroj + "]/td[4]")));

            //Console.WriteLine(State.Text);
            //if (State.Text == "approved")
            //{
            //    return true;
           //}
            //return false;
        }

        public void ClickRejectButton(int redniBroj)
        {
            Reject = driver.FindElement(By.XPath("/html/body/app-root/app-home-page-layout/div/div[2]/app-patient-feedbacks/div/div[2]/table/tbody/tr[" + redniBroj + "]/div/div/td[2]/button"));
            Reject.Click();
        }
    }
}