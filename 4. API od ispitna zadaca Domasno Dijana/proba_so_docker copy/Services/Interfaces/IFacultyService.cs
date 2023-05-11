using proba_so_docker.Entities;
using proba_so_docker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proba_so_docker.Services.Interfaces
{
    public interface IFacultyService
    {
        List<Faculty> Get();
        Faculty Get(int id);
        Faculty Add(Faculty fmr);
        Faculty Update(Faculty faculty);
        Faculty SafeUpdate(int id, Faculty newFaculty);
        bool Delete(int id);

        FacultyOrderByResponse OrderByFacultyNameAsc(List<Faculty> faculties);
        FacultyOrderByResponse OrderByFacultyNameDesc(List<Faculty> faculties);

    }
}
