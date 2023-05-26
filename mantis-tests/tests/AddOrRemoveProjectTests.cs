using mantis_tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace mantis_tests
{
    [TestFixture]
    public class AddOrRemoveProjectTests : TestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            ProjectData project = new ProjectData()
            {
                Name = app.ProjectManagement.GenerateUniqueName(),
            };

            app.LoginHelper.Login();

            app.Management.GoToProjectsPage();

            List<ProjectData> projectListOld = app.ProjectManagement.GetAll();

            app.ProjectManagement.Create(project);

            List<ProjectData> projectListNew = app.ProjectManagement.GetAll();

            projectListOld.Add(project);

            projectListOld.Sort();
            projectListNew.Sort();

            Assert.AreEqual(projectListOld, projectListNew);
        }

        [Test]
        public void ProjectCreationTest2()
        {
            ProjectData project = new ProjectData()
            {
                Name = app.ProjectManagement.GenerateUniqueName(),
            };

            app.LoginHelper.Login();

            app.Management.GoToProjectsPage();

            List<ProjectData> projectListOld = app.API.GetAll();

            app.API.CreateProject(project);

            List<ProjectData> projectListNew = app.API.GetAll();


            projectListOld.Add(project);

            projectListOld.Sort();
            projectListNew.Sort();

            Assert.AreEqual(projectListOld, projectListNew);
        }

        [Test]
        public void ProjectRemovalTest()
        {
            app.LoginHelper.Login();

            app.Management.GoToProjectsPage();

            if (app.ProjectManagement.GetAll().Count == 0)
            {
                ProjectData project = new ProjectData()
                {
                    Name = app.ProjectManagement.GenerateUniqueName(),
                };

                app.ProjectManagement.Create(project);
            }

            List<ProjectData> projectListOld = app.ProjectManagement.GetAll();

            app.ProjectManagement.Remove(0);

            List<ProjectData> projectListNew = app.ProjectManagement.GetAll();

            projectListOld.RemoveAt(0);

            projectListOld.Sort();
            projectListNew.Sort();

            Assert.AreEqual(projectListOld, projectListNew);
        }

        [Test]
        public void ProjectRemovalTest2()
        {
            app.LoginHelper.Login();

            app.Management.GoToProjectsPage();

            if (app.API.GetAll().Count == 0)
            {
                ProjectData project = new ProjectData()
                {
                    Name = app.ProjectManagement.GenerateUniqueName(),
                };

                //app.ProjectManagement.Create(project);
                app.API.CreateProject(project);
            }

            List<ProjectData> projectListOld = app.API.GetAll();

            app.ProjectManagement.Remove(0);

            List<ProjectData> projectListNew = app.API.GetAll();

            projectListOld.RemoveAt(0);

            projectListOld.Sort();
            projectListNew.Sort();

            Assert.AreEqual(projectListOld, projectListNew);
        }
    }
}
