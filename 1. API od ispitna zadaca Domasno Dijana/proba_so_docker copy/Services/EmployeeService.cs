using System;
using System.Collections.Generic;
using System.Linq;
using proba_so_docker.Data;
using proba_so_docker.Models;
using proba_so_docker.Services.Interfaces;

namespace proba_so_docker.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IApplicationDbContext db;

        public EmployeeService(IApplicationDbContext db)
        {
            this.db = db;
        }


        public Employee Create(Employee emp)
        {
            var addedEmp = db.Employees.Add(emp);
            db.SaveChanges();
            return addedEmp.Entity;
        }

        public bool Delete(int id)
        {
                var employee = db.Employees.FirstOrDefault(x => x.id == id);
                db.Employees.Remove(employee);
                var changesCount = db.SaveChanges();
                return changesCount == 1;
        }

        public List<Employee> Get()
        {
            return db.Employees.ToList();
        }

        public Employee Get(int id)
        {
            return db.Employees.FirstOrDefault(a => a.id == id);
        }

        public Employee Update(Employee emp)
        {
            var updatedEmp = db.Employees.Update(emp);
            db.SaveChanges();
            return updatedEmp.Entity;
        }

        //public string CountPoId(int id)
        //{
        //    var modules = db.ArticleType.Include(f => f.Articles)
        //         .Where(e => e.Id == id)
        //         //.//Select(a => a.Articles.Id)
        //         .ToList();


        //    var q = from x in modules
        //            group x by x into g
        //            let count = g.Count()
        //            orderby count descending
        //            select (g.Key + " (" + count + ")").ToString();

        //    return String.Join(", ", q);
        //}

        //public static string Count(List<Article> articles)
        //{
        //    var conferenceArticles = 0;
        //    var journalArticles = 0;
        //    foreach (var article in articles)
        //    {
        //        if (article.Type.Value.ToLower() == "conference")
        //        {
        //            conferenceArticles++;
        //        }
        //        if (article.Type.Value.ToLower() == "journal")
        //        {
        //            journalArticles++;
        //        }
        //    }

        //    return $"Conference Articles: {conferenceArticles}, Journal Articles {journalArticles}"; // ova preku model return-ot 

        //}

    }

}
