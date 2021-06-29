using System;
using System.Collections.Generic;
using proba_so_docker.Entities;

namespace proba_so_docker.Models
{
    public class FacultyOrderByResponse
    {
        public string Name { get; set; }
        public List<Faculty> Order { get; set; }
      
    }
}
