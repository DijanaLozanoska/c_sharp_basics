using BSCodeModels_Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSCodeAPI.Services.Interface
{
    public interface IProjectService
    {
        List<Project> Get();
        Project Get(Guid id);
        bool Add(Project project);
        Project Update(Project project);
        bool Delete (Guid id);

    }
}
