using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstore_api_10_07_2021.Data;
using bookstore_api_10_07_2021.Models;

namespace bookstore_api_10_07_2021.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.books.Any() && context.categories.Any())
                {
                    return;   // DB has been seeded
                }
                //else if (!context.categories.Any())
                if (!context.categories.Any())
                {
                    context.AddRange(
                        new Category
                        {
                            CategoryName = "Drama",
                            Description = "Drama is a mode of fictional representation through dialogue and performance. " +
                            "It is one of the literary genres, which is an imitation of some action. Drama is also a type of " +
                            "a play written for theater, television, radio, and film."
                        },
                        new Category
                        {
                            CategoryName = "Crime",
                            Description = "Crime films, in the broadest sense, is a film genre inspired by and analogous to the " +
                            "crime fiction literary genre. Films of this genre generally involve various aspects of crime and its detection."
                        },
                        new Category
                        {
                            CategoryName = "Science fiction",
                            Description = "Science fiction (or sci-fi) is a film genre that uses speculative, fictional science-based " +
                            "depictions of phenomena that are not fully accepted by mainstream science, such as extraterrestrial lifeforms, " +
                            "alien worlds, extrasensory perception and time travel, along with futuristic elements such as spacecraft, robots, " +
                            "cyborgs, interstellar travel or other technologies. Science fiction films have often been used to focus on political" +
                            " or social issues, and to explore philosophical issues like the human condition."
                        }
                    );
                    context.SaveChanges();
                }
                //else if (!context.books.Any())
                if (!context.books.Any())
                {
                    context.AddRange(
                        new Book
                        {
                            Title = "Test",
                            Author = "Test Author",
                            CategoryName = "Drama",
                            CategoryID = 1,
                            Description = "Industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer " +
                            "took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the " +
                            "leap into electronic typesetting, remaining essentially unchanged.",
                            //IssueDate = DateTime.Today,
                            ImageUrl = "./Images/book1.jpg"
                        },
                        new Book
                        {
                            Title = "In Cold Blood",
                            Author = "Truman Capote",
                            CategoryName = "Crime",
                            CategoryID = 2,
                            Description = "In Cold Blood is a non-fiction novel[1] by American author Truman Capote, first published in 1966. It details the 1959 murders of four members of the Herbert Clutter family in the small farming community of Holcomb, Kansas." +
                            "Capote learned of the quadruple murder before the killers were captured," +
                            "and he traveled to Kansas to write about the crime.He was accompanied by his childhood friend and fellow author Harper Lee," +
                            "and they interviewed residents and investigators assigned to the case and took thousands of pages of notes.Killers Richard Hickock and Perry Smith were arrested six weeks after the murders and later executed by the state of Kansas.Capote ultimately spent six years working on the book.",
                            //IssueDate = new DateTime(1994, 5, 6),
                            ImageUrl = "images//test//test1234"
                        },
                        new Book
                        {
                            Title = "The Devil in the White City: Murder, Magic, and Madness at the Fair That Changed America",
                            Author = "Erik Larson",
                            CategoryName = "Crime",
                            CategoryID = 2,
                            Description = "Author Erik Larson imbues the incredible events surrounding the 1893 Chicago World's Fair with such drama that readers may find " +
                            "themselves checking the book's categorization to be sure that 'The Devil in the White City' is not, in fact, a highly imaginative novel. Larson " +
                            "tells the stories of two men: Daniel H. Burnham, the architect responsible for the fair's construction",
                            //IssueDate = new DateTime(2003, 2, 11),
                            ImageUrl = "images//test//test1234"
                        },
                        new Book
                        {
                            Title = "Hamlet ( Folger Library Shakespeare)",
                            Author = "William Shakespeare",
                            CategoryName = "Drama",
                            CategoryID = 1,
                            Description = "Hamlet is Shakespeare's most popular, and most puzzling, play. It follows the form of a 'revenge tragedy'," +
                            " in which the hero, Hamlet, seeks vengeance against his father's murderer, his uncle Claudius, now the king of Denmark. Much of its fascination, " +
                            "however, lies in its uncertainties. Among them: What is the Ghost--Hamlet's father demanding justice, a tempting demon, an angelic messenger? " +
                            "Does Hamlet go mad, or merely pretend to? Once he is sure that Claudius is a murderer, why does he not act? Was his mother, Gertrude, unfaithful to her " +
                            "husband or complicit in his murder?",
                            //IssueDate = new DateTime(1992, 7, 1),
                            ImageUrl = "images//test//test1234"
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}




