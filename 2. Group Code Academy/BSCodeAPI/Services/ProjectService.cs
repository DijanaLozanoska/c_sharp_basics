using BSCodeAPI.Data;
using BSCodeAPI.Services.Interface;
using BSCodeModels_Lib;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSCodeAPI.Services
{
    public class ProjectService : IProjectService
    {
        private BSCodeDbContext bSCodeDb;

        public ProjectService(BSCodeDbContext bSCodeDb)
        {
            this.bSCodeDb = bSCodeDb ?? throw new ArgumentNullException(nameof(bSCodeDb));
        }

        public bool Add(Project project)
        {
            bSCodeDb.Projects.Add(project);
            int res = bSCodeDb.SaveChanges();
            return res > 0;
        }

        public bool Delete(Guid id)
        {
            Project proj = bSCodeDb.Projects.FirstOrDefault(x => x.ID == id);
            bSCodeDb.Projects.Remove(proj);
            int res = bSCodeDb.SaveChanges();
            return res > 0;
        }

        public List<Project> Get()
        {
            return bSCodeDb.Projects.ToList();
        }

        public Project Get(Guid id)
        {
            return bSCodeDb.Projects.FirstOrDefault(p => p.ID == id);
        }

        public Project Update(Project project)
        {
            EntityEntry<Project> test = bSCodeDb.Projects.Update(project);
            bSCodeDb.SaveChanges();
            return test.Entity;
        }
    }
}
