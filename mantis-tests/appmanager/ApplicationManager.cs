﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        public RegistrationHelper Registration { get; set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            ProjectManagement = new ProjectManagementHelper(this);
            LoginHelper = new LoginHelper(this);
            Management = new ManagementMenuHelper(this);
            API = new APIHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-2.25.7/login_page.php";
                app.Value = newInstance;                
            }
            return app.Value;
        }

        public IWebDriver Driver { get { return driver; } }

        public FtpHelper Ftp { get; set; }
        public ProjectManagementHelper ProjectManagement { get; set; }
        public LoginHelper LoginHelper { get; set; }
        public ManagementMenuHelper Management { get; set;}
        public APIHelper API { get; set; }
    }
}
