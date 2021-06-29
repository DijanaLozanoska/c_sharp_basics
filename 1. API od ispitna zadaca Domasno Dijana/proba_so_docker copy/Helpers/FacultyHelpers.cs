using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proba_so_docker.Helpers
{
    // Za Doma!
    // Da se kreira GET i POST metodi vo FacultyController 
    // I da se povika funkcijata Rang za GET i POST metodite
    // Metodot vo kontrolerot treba da go vrati Imeto na studentot I rangot na studentot
    // Da se vrati vakov model { "Name":"Marko", "Type":"Student" "Rang": 10}
    // Da se vrati vakov model { "Name":"Petar", "Type":"PHDStudent" "Rang": 16.4}
    // Videte kako e napraven Print metodot vo FacultyController


    // Dijana Domasna 
    // Da se dodade Student Marko So kalkulus, Matematika i Fizika 
    // 1 povik za Add student  --- HttpPost Add Student
    // 1 povik za Add subject ---- 3 povici za Add Subject
    // ili nov kontroler koj ke prifaka Lista od subjecti i tie da se dodadat kako edno vo student
    // add subject mapiranjeto vo student subject tabelata 


    public class FacultyHelpers
    {
        public Faculty CreateFaulty(string name)
        { 
            // 3 povici  add subject
            var subjects = new List<Subject>() {
                new Subject("Kalkulus",10 ) ,
                new Subject("Matematika",10 ) ,
                new Subject("Fizika",10 )
            };

            // 1 povik za kreiranje student http post add student
            var student = new Student("Marko", 1234, 2010);

            // mapiranje vo student subject tabela
            foreach (var subject in subjects)
            {
                try
                {
                    student.AddSubject(subject);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            var phdStudent = new PHDStudent("Petar", 123456, 2003);

            var phdSubjects = new List<Subject>() {
                new Subject("Kalkulus",10) ,
                new Subject("Matematika",9) ,
                new Subject("Fizika",10),
                new Subject("Kalkulus",8) ,
                new Subject("Matematika",10)
            };

            var articles = new List<Article>()
            {
                new Article(){Title="Article 1", Type = ArticleType.Conference, PublishYear=2008},
                new Article(){Title="Article 2",Type = ArticleType.Journal, PublishYear=2008},
                new Article(){Title="Article 3",Type = ArticleType.Journal, PublishYear=2005}
            };

            foreach (var subject in phdSubjects)
            {
                try
                {
                    phdStudent.AddSubject(subject);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (var article in articles)
            {
                try
                {
                    phdStudent.AddArticle(article);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            var faculty = new Faculty() { Name = name, Students = new List<Student>() { student, phdStudent } };
            return faculty;
        }
    }

    public enum ArticleType
    {
        Conference,
        Journal
    }

    public class Article
    {
        public string Title { get; set; }
        public ArticleType Type { get; set; }
        public int PublishYear { get; set; }
    }

    public class Subject
    {
        public string Name { get; set; }
        public int Grade { get; set; }

        public Subject()
        {

        }

        public Subject(string name, int grade)
        {
            Name = name;
            Grade = grade;
        }
    }

    public class Student
    {
        public string Name;
        public int Index;
        public int StartYear;
        public List<Subject> Subjects = new List<Subject>();
        public Student()
        {

        }

        public Student(string name, int index, int startYear)
        {
            Name = name;
            Index = index;
            StartYear = startYear;
        }

        public void AddSubject(Subject s)
        {
            if (s.Grade > 10)
            {
                throw new InvalidGradeException(s);
            }
            Subjects.Add(s);
        }

        public virtual double Rang()
        {
            var rang = 0.0;

            foreach (var subject in Subjects)
            {
                rang += subject.Grade;
            }

            return rang / Subjects.Count;
        }

        public string Print()
        {
            return $"{Index} {Name} {StartYear} {Rang()}";
        }
    }

    public class PHDStudent : Student
    {
        public List<Article> Articles { get; private set; } = new List<Article>();

        public PHDStudent(string name, int index, int startYear)
            : base(name, index, startYear)
        {

        }

        public void AddArticle(Article a)
        {
            if (StartYear > a.PublishYear)
            {
                throw new InvalidPublishDateException(a);
            }
            Articles.Add(a);
        }

        public override double Rang()
        {
            var rang = base.Rang();
            foreach (var article in Articles)
            {
                if (article.Type == ArticleType.Conference)
                {
                    rang += 1;
                }
                if (article.Type == ArticleType.Journal)
                {
                    rang += 3;
                }
            }
            return rang;
        }

        public static string Count(List<Article> articles)
        {
            var conferenceArticles = 0;
            var journalArticles = 0;
            foreach (var article in articles)
            {
                if (article.Type == ArticleType.Conference)
                {
                    conferenceArticles++;
                }
                if (article.Type == ArticleType.Journal)
                {
                    journalArticles++;
                }
            }

            return $"Conference Articles: {conferenceArticles}, Journal Articles {journalArticles}";
        }
    }

    public class Faculty
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }

        public string Print()
        {
            var phdStudents = 0;
            var students = 0;
            foreach (var student in Students)
            {
                student.Print();
                if (student is PHDStudent) phdStudents++;
                else students++;
            }
            return $"PHD Student count = {phdStudents} Regular students = {students}";
        }
    }

    public class InvalidGradeException : Exception
    {
        public InvalidGradeException(Subject subject)
        : base($"Cannot add subject {subject.Name} {subject.Grade}")
        {

        }
    }

    public class InvalidPublishDateException : Exception
    {
        public InvalidPublishDateException(Article article)
        : base($"Cannot add article {article.Title} {article.PublishYear}")
        {

        }
    }
}
