using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proba_so_docker.Entities
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
