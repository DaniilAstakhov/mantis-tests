using mantis_tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public List<ProjectData> GetAll()
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible("administrator", "root");
            List<ProjectData> projectsList = new List<ProjectData>();
            for (int i = 0; i < projects.Length; i++)
            {
                ProjectData project = new ProjectData();
                project.Name = projects.ElementAt(i).name;
                projectsList.Add(project);
            }            
            return projectsList;
        }

        public void CreateProject(ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData mProject = new Mantis.ProjectData();
            mProject.name = project.Name;
            client.mc_project_add("administrator", "root", mProject);
        }
    }
}
