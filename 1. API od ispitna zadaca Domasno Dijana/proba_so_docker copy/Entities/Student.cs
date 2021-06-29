using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace proba_so_docker.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StartYear { get; set; }
        public bool IsPHD { get; set; }

        [ForeignKey("FacultyId")]
        public virtual Faculty Faculty { get; set; }
        public int FacultyId { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects{ get; set; }
    }
}
