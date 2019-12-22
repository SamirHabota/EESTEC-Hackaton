using System;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Data
{
    public static class DbInitializer
    {

        public static async Task<bool> InitializeDB(this VisyLrnContext context, UserManager<Account> userManager)
        {
            if (context.Organization.Any())
                return false;

            #region Organizations
            var organization1 = new Organization
            {
                Location = "Mostar",
                Name = "Fakultet informacijskih tehnologija"
            };
            var organization2 = new Organization
            {
                Location = "Sarajevo",
                Name = "Elektrotehnicki Fakultet"
            };

            context.Organization.AddRange(organization1, organization2);
            context.SaveChanges();
            #endregion

            #region Accounts

            var account1 = new Account
            {
                FirstName = "Adnan",
                LastName = "Čutura",
                UserName = "adnan.cutura",
                Email = "adnan.cutura@gmail.com",
                Organization = organization1,
                Year = 1,
                VisyPoints = 30,
                AvatarLink = "ado.jpg"
            };
            var account2 = new Account
            {
                FirstName = "Adi",
                LastName = "Šoše",
                UserName = "adi.sose",
                Email = "adi.sose@gmail.com",
                Organization = organization1,
                Year = 1,
                VisyPoints = 30,
                AvatarLink = "adi.jpg"
            };
            var account3 = new Account
            {
                FirstName = "Samir",
                LastName = "Habota",
                UserName = "samir.habota",
                Email = "samir.habota@email.com",
                Organization = organization2,
                Year = 3,
                VisyPoints = 30,
                AvatarLink = "samir.jpg"
            };

            await userManager.CreateAsync(account1, "1");
            await userManager.CreateAsync(account2, "1");
            await userManager.CreateAsync(account3, "1");

            #endregion


            #region Subject

            var subject1 = new Subject
            {
                Account = account1,
                Ects = 7,
                Name = "Programming II",
                Professor = "doc. dr. Denis Music",
                Organization = organization1,
                SemesterNumber = 2,
                Description = "Lorem ipsum dolor sit amet, conse ctetur adip isicing elit. At cupiditate excepturi labore. "
            };

            var subject2 = new Subject
            {
                Account = account1,
                Ects = 7,
                Name = "Programming I",
                Professor = "doc. dr. Elmir Babovic",
                Organization = organization1,
                SemesterNumber = 1,
                Description = "Lorem ipsum dolor sit amet, conse ctetur adip isicing elit. At cupiditate excepturi labore. "
            };

            var subject3 = new Subject
            {
                Account = account1,
                Ects = 7,
                Name = "Eng. Math",
                Professor = "doc. dr. Nina Bijedic",
                Organization = organization1,
                SemesterNumber = 1,
                Description = "Lorem ipsum dolor sit amet, conse ctetur adip isicing elit. At cupiditate excepturi labore. "
            };

            context.Subject.AddRange(subject1,
                                     subject2,
                                     subject3);
            context.SaveChanges();
            #endregion

            #region Lectures

            var lecture1 = new Lecture
            {
                Name = "Introduction",
                Number = 1,
                Subject = subject1
            };

            var lecture2 = new Lecture
            {
                Name = "Pointers",
                Number = 2,
                Subject = subject1
            };

            var lecture3 = new Lecture
            {
                Name = "Recursion",
                Number = 3,
                Subject = subject1
            };

            var lecture4 = new Lecture
            {
                Name = "Classes",
                Number = 1,
                Subject = subject2
            };

            var lecture5 = new Lecture
            {
                Name = "Inheritence",
                Number = 2,
                Subject = subject2
            };

            var lecture6 = new Lecture
            {
                Name = "Exceptions",
                Number = 3,
                Subject = subject2
            };

            var lecture7 = new Lecture
            {
                Name = "Advanced",
                Number = 4,
                Subject = subject2
            };

            context.Lecture.AddRange(lecture1,
                                     lecture2,
                                     lecture3,
                                     lecture4,
                                     lecture5,
                                     lecture6,
                                     lecture7);
            context.SaveChanges();

            #endregion

            #region Cards
            var card1 = new Card
            {
                Lecture = lecture2,
                Question = "What is a pointer",
                Answer = "A variable which value is a memory adress",
                Priority = Priority.High,
                OriginalAuthor = account1,
                LastShwon=DateTime.MinValue
            };

            var card2 = new Card
            {
                Lecture = lecture2,
                Question = "How to dealocate heap memory",
                Answer = "Using the keyword delete",
                Priority = Priority.High,
                OriginalAuthor = account1,
                LastShwon = DateTime.MinValue
            };

            var card3 = new Card
            {
                Lecture = lecture2,
                Question = "What does the operator 'new' return",
                Answer = "Newly created memory address location or nullpttr",
                Priority = Priority.High,
                OriginalAuthor = account1,
                LastShwon = DateTime.MinValue
            };

            var card4 = new Card
            {
                Lecture = lecture2,
                Question = "Can a memory location have two pointers pointing to it",
                Answer = "Yes",
                Priority = Priority.High,
                OriginalAuthor = account1,
                LastShwon = DateTime.MinValue
            };

            var card5 = new Card
            {
                Lecture = lecture2,
                Question = "What is differentiation",
                Answer = "Dereferencing is the act of referring to where the pointer points, instead of the memory address.",
                Priority = Priority.High,
                OriginalAuthor = account1,
                LastShwon = DateTime.MinValue
            };

            var card6 = new Card
            {
                Lecture = lecture2,
                Question = "What is the operator used in differentiation",
                Answer = "The & operator",
                Priority = Priority.High,
                OriginalAuthor = account1,
                LastShwon = DateTime.MinValue
            };

            context.Card.AddRange(card1,
                                  card2,
                                  card3,
                                  card4,
                                  card5,
                                  card6);
            context.SaveChanges();

            #endregion

            #region 
            var question1 = new Question
            {
                Text = "Question 1",
                Lecture = lecture2,
                OriginalAuthor = account1
            };

            var question2 = new Question
            {
                Text = "Question 2",
                Lecture = lecture2,
                OriginalAuthor = account1
            };

            var question3 = new Question
            {
                Text = "Question 3",
                Lecture = lecture2,
                OriginalAuthor = account1
            };

            var question4 = new Question
            {
                Text = "Question 4",
                Lecture = lecture2,
                OriginalAuthor = account1
            };

            var question5 = new Question
            {
                Text = "Question 5",
                Lecture = lecture2,
                OriginalAuthor = account1
            };

            context.Question.AddRange(question1,
                                      question2,
                                      question3,
                                      question4,
                                      question5);
            context.SaveChanges();
            #endregion

            #region 
            var answer1 = new Answer
            {
                Text = "Answer 1 [W]",
                IsCorrect = false,
                Question = question1
            };
            var answer2 = new Answer
            {
                Text = "Answer 2 [W]",
                IsCorrect = false,
                Question = question1
            };
            var answer3 = new Answer
            {
                Text = "Answer 3 [C]",
                IsCorrect = true,
                Question = question1
            };

            var answer4 = new Answer
            {
                Text = "Answer 1 [C]",
                IsCorrect = true,
                Question = question2
            };
            var answer5 = new Answer
            {
                Text = "Answer 2 [W]",
                IsCorrect = false,
                Question = question2
            };
            var answer6 = new Answer
            {
                Text = "Answer 3 [C]",
                IsCorrect = true,
                Question = question2
            };

            var answer7 = new Answer
            {
                Text = "Yes [W]",
                IsCorrect = false,
                Question = question3
            };
            var answer8 = new Answer
            {
                Text = "No [C]",
                IsCorrect = true,
                Question = question3
            };

            var answer9 = new Answer
            {
                Text = "Answer 1 [W]",
                IsCorrect = false,
                Question = question4
            };
            var answer10 = new Answer
            {
                Text = "Answer 2 [W]",
                IsCorrect = false,
                Question = question4
            };
            var answer11 = new Answer
            {
                Text = "Answer 3 [C]",
                IsCorrect = true,
                Question = question4
            };
            var answer12 = new Answer
            {
                Text = "Answer 4 [W]",
                IsCorrect = false,
                Question = question4
            };
            var answer13 = new Answer
            {
                Text = "Answer 5 [C]",
                IsCorrect = true,
                Question = question4
            };

            var answer14 = new Answer
            {
                Text = "Yes [C]",
                IsCorrect = true,
                Question = question5
            };
            var answer15 = new Answer
            {
                Text = "Yes [W]",
                IsCorrect = false,
                Question = question5
            };

            context.Answer.AddRange(answer1,
                                    answer2,
                                    answer3,
                                    answer4,
                                    answer5,
                                    answer6,
                                    answer7,
                                    answer8,
                                    answer9,
                                    answer10,
                                    answer11,
                                    answer12,
                                    answer13,
                                    answer14,
                                    answer15);

            context.SaveChanges();
            #endregion

            #region DocumentTypes
            var doctype1 = new DocumetType
            {
                Type = DocType.Book
            };

            var doctype2 = new DocumetType
            {
                Type = DocType.Script
            };

            var doctype3 = new DocumetType
            {
                Type = DocType.Note
            };

            context.DocumetType.AddRange(doctype1,
                                         doctype2,
                                         doctype3);
            context.SaveChanges();
            #endregion

            #region Groups
            var group1 = new Group
            {
                Name = "Fitovci 1. Godina",
                Creator = account1
            };

            context.Group.AddRange(group1);
            context.SaveChanges();
            #endregion

            #region Posts
            var post1 = new Post
            {
                Account = account2,
                Text = "Do we have a lecture tommorow?",
                DateCreated = DateTime.Now.AddDays(-1),
                Group = group1
            };
            var post2 = new Post
            {
                Account = account1,
                Text = "Should we study pointers for tommorow?",
                DateCreated = DateTime.Now.AddHours(-11),
                Group = group1
            };

            context.Post.AddRange(post1,
                                  post2);
            context.SaveChanges();
            #endregion

            #region AccountGroup
            var accountGroup1 = new AccountGroup
            {
                Account = account1,
                Group = group1
            };
            var accountGroup2 = new AccountGroup
            {
                Account = account2,
                Group = group1
            };

            context.AccountGroup.AddRange(accountGroup1, accountGroup2);
            context.SaveChanges();
            #endregion

            #region Comments
            var comment1 = new Comment
            {
                Account = account1,
                Post = post1,
                Text = "Yeah, sure",
                DateCreated = DateTime.Now.AddDays(-1).AddHours(1).AddMinutes(22)
            };

            var comment2 = new Comment
            {
                Account = account2,
                Post = post1,
                Text = "Thanks",
                DateCreated = DateTime.Now.AddDays(-1).AddHours(1).AddMinutes(44)
            };

            var comment3 = new Comment
            {
                Account = account1,
                Post = post1,
                Text = "I've spoken with the teacher and they've said we don't have to",
                DateCreated = DateTime.Now.AddHours(-10)
            };

            context.Comment.AddRange(comment1,
                                comment2,
                                comment3);
            context.SaveChanges();
            #endregion
            return true;
        }
    }
}