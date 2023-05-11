using System;
using Microsoft.EntityFrameworkCore;
using proba_so_docker.Entities;
using proba_so_docker.Models;

namespace proba_so_docker.Data
{

    public interface IApplicationDbContext
    {
        public DbSet<Employee> Employees { get; set; }
        DbSet<Faculty> Faculty { get; set; }
        DbSet<Article> Article { get; set; }
        DbSet<ArticleType> ArticleType { get; set; }
        DbSet<Subject> Subject { get; set; }
        DbSet<Student> Student { get; set; }
        DbSet<StudentSubject> StudentSubjects { get; set; }
        int SaveChanges();
    }

    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<ArticleType> ArticleType { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faculty>()
                .HasMany<Student>(faculty => faculty.Students)
                .WithOne(student => student.Faculty)
                .HasForeignKey(s => s.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Faculty>()
                .HasMany<Article>(faculty => faculty.Articles)
                .WithOne(article => article.Faculty)
                .HasForeignKey(s => s.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Faculty>()
                .HasMany<Subject>(faculty => faculty.Subjects)
                .WithOne(subject => subject.Faculty)
                .HasForeignKey(s => s.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
                .HasMany<StudentSubject>(student => student.StudentSubjects)
                .WithOne(ss => ss.Student)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
                .HasMany<Article>(student => student.Articles)
                .WithOne(subject => subject.Student)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Article>()
                .HasOne<ArticleType>(article => article.Type)
                .WithMany(articleType => articleType.Articles)
                .HasForeignKey(x => x.TypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Subject>()
                .HasMany<StudentSubject>(subject => subject.StudentSubjects)
                .WithOne(ss => ss.Subject)
                .HasForeignKey(x => x.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}