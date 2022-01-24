using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Pages.AppForPatient
{
    internal class PatientMedicalRecordPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4202/patient/medicalrecords";
        public PatientMedicalRecordPage(IWebDriver driver)
        {
            this.driver = driver;
        }

    }
}
