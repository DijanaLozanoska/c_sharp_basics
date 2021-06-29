using System;
using System.Collections.Generic;
using proba_so_docker.Entities;

namespace proba_so_docker.Models
{
    public class SelectSubjectsByFacultyResponse
    {
        public List<Faculty> Faculties { get; set; }

        public List<Student>  Students{ get; set; }

 
    }
}
