using proba_so_docker.Entities;
using proba_so_docker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proba_so_docker.Services.Interfaces
{
    public interface ISubjectService
    {
        List<Subject> Get();
        Subject Get(int id);
        Subject Add(Subject s);
        Subject Update(Subject s);
        bool Delete(int id);

        public List<Subject> AddRange(int facultyId, Subject s);
    }
}
