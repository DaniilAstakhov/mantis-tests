using mantis_tests.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public void Create(ProjectData project)
        {
            driver.FindElement(By.XPath("//button[.='Создать новый проект']")).Click();
            driver.FindElement(By.Name("name")).SendKeys(project.Name);
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.XPath("//button[.='Создать новый проект']")).Count > 0);
        }

        public List<ProjectData> GetAll()
        {
            List<ProjectData> projectList = new List<ProjectData>();
            int projectsCount = driver.FindElements(By.XPath("//div[2]/table/tbody/tr")).Count;
            for (int i = 1; i <= projectsCount; i++) 
            {
                ProjectData project = new ProjectData();
                project.Name = driver.FindElement(By.XPath("//div[2]/table/tbody/tr[" + i + "]/td[1]/a")).Text;
                projectList.Add(project);
            }
            return projectList;
        }

        public string GenerateUniqueName()
        {
            Random rnd = new Random();
            string uniqeProjectName = "TestProject";
            for (int i = 0; i < 6; i++)
            {
                uniqeProjectName += rnd.Next(0, 9).ToString();
            }
            return uniqeProjectName;
        }

        public void Remove(int v)
        {
            IReadOnlyCollection<IWebElement> projects = driver.FindElements(By.XPath("//div[2]/table/tbody/tr"));
            projects.ElementAt(v).FindElement(By.XPath("./td[1]/a")).Click();

            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }
    }
}
