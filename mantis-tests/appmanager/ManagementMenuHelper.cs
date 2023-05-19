using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager) { }

        internal void GoToProjectsPage()
        {
            driver.FindElement(By.XPath("//span[.=' Управление ']")).Click();
            driver.FindElement(By.XPath("//a[.='Управление проектами']")).Click();
        }
    }
}
