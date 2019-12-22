using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Helper;
using Web.Viewmodels;
using Web.Viewmodels.SharedVM;
using Web.Viewmodels.UserVM;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        private readonly VisyLrnContext _context;
        private readonly UserManager<Account> _userManager;
        public UserController(VisyLrnContext context, UserManager<Account> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Route("/{username?}")]
        public IActionResult Index(string username)
        {

            var model = new IndexVM();
            var account = new Account();


            account = string.IsNullOrEmpty(username) ?
                _context.Account.Include(a => a.Organization).FirstOrDefault(a => a.UserName == HttpContext.User.Identity.Name.ToUpper()) :
                _context.Account.Include(a => a.Organization).FirstOrDefault(a => a.NormalizedUserName == username.ToUpper());
            model.Organizations = _context.Organization.Select(o => new SelectListItem
            {
                Text = o.Name,
                Value = o.Id.ToString()
            }).ToList();

            model.Subjects = _context.Subject.Where(s => s.AccountId == account.Id).Select(
                s => new SubjectVM
                {
                    Id = s.Id,
                    Title = s.Name,
                    Professor = s.Professor,
                    ETCS = s.Ects ?? 0,
                    CardCount = _context.Card.Count(c => c.Lecture.SubjectId == s.Id),
                    Description = s.Description,
                    DocumentCount = _context.Document.Count(c => c.Lecture.SubjectId == s.Id),
                    LecturesCount = _context.Lecture.Count(c => c.SubjectId == s.Id)

                }).ToList();


            model.User = new UserDataVM
            {
                Username = account.UserName,
                FirstName = account.FirstName,
                LastName = account.LastName,
                AvatarLink = account.AvatarLink,
                Organization = $"{account.Organization.Name}, {account.Organization.Location}",
                ReputationPoints = account.VisyPoints ?? 0
            };

            return View(model);
        }

        public IActionResult Subject(int id)
        {
            var model = new SubjectDetailsVM();
            var subject = _context.Subject.FirstOrDefault(s => s.Id == id);

            var account = _context.Account.Include(a => a.Organization).FirstOrDefault(a => a.Id == subject.AccountId) ??
                          _context.Account.Include(a => a.Organization).FirstOrDefault(a => a.UserName == HttpContext.User.Identity.Name.ToUpper());

            model.Name = subject?.Name;
            model.Id = subject.Id;
            model.User = new UserDataVM
            {
                Username = account.UserName,
                FirstName = account.FirstName,
                LastName = account.LastName,
                AvatarLink = account.AvatarLink,
                Organization = $"{account.Organization.Name}, {account.Organization.Location}",
                ReputationPoints = account.VisyPoints ?? 0
            };


            model.Lectures = _context.Lecture.Where(l => l.SubjectId == subject.Id).Select(l => new LectureVM
            {
                Name = l.Name,
                Id = l.Id,
                CardsCount = _context.Card.Count(c => c.LectureId == l.Id),
                QuestionCount = _context.Question.Count(c => c.LectureId == l.Id),
                DocumentCount = _context.Document.Count(c => c.LectureId == l.Id),
            }).ToList();

            return View(model);
        }

        public IActionResult Lecture(int id)
        {
            var model = new LectureDetailsVM();
            var lecture = _context.Lecture.Include(l => l.Subject).FirstOrDefault(s => s.Id == id);

            var account = _context.Account.Include(a => a.Organization).FirstOrDefault(a => a.Id == lecture.Subject.AccountId) ??
                          _context.Account.Include(a => a.Organization).FirstOrDefault(a => a.UserName == HttpContext.User.Identity.Name.ToUpper());
            model.User = new UserDataVM
            {
                Username = account.UserName,
                FirstName = account.FirstName,
                LastName = account.LastName,
                AvatarLink = account.AvatarLink,
                Organization = $"{account.Organization.Name}, {account.Organization.Location}",
                ReputationPoints = account.VisyPoints ?? 0
            };


            model.Cards = _context.Card.Where(c => c.LectureId == id).Select(c => new CardVM
            {
                Id = c.Id,
                Answer = c.Answer,
                Question = c.Question,
                Author = c.OriginalAuthor.UserName,
            }).ToList();

            var dc = new DocumentVM()
            {
                Title = "Document 1",
                Description = "Lorem ipsum sit ameci.",
                DocType = "Markdown",
                WordCount = 323,
                CharCount = 1233,
                Author = "Adnan Čutura"


            };
            model.Documents = _context.Document.Where(c => c.LectureId == id).Select(d => new DocumentVM
            {
                Id = d.Id,
                Title = d.Title,
                Description = d.Description,
            }).ToList();
            model.Documents.Add(dc);

            model.LectureName = lecture.Name;
            model.Id = lecture.Id;
            model.SubjectName = lecture.Subject.Name;

            model.Questions = _context.Question.Where(q => q.LectureId == id).Select(s => new QuestionVM
            {
                Id = s.Id,
                Question = s.Text,
                Answer = string.Join(", ", s.Answer.Select(a => a.Text))
            }).ToList();

            return View(model);
        }

        public IActionResult AddCard(AddCardVM model)
        {
            var lecture = _context.Lecture.Include(l => l.Subject).FirstOrDefault(s => s.Id == model.Id);

            var card = new Card()
            {
                Question = model.Question,
                Answer = model.Answer,
                LectureId = model.Id,
                //OriginalAuthorId = _context.Account.First(a => a.UserName.ToUpper() == HttpContext.User.Identity.Name.ToUpper()).Id,
                OriginalAuthorId = _context.Account.First().Id,

            };

            _context.Add(card);
            _context.SaveChanges();

            return Redirect($"/User/Lecture?id={lecture.Id}");
        }

        public IActionResult AddQuestion(AddQuestionVM model)
        {
            var lecture = _context.Lecture.Include(l => l.Subject).FirstOrDefault(s => s.Id == model.Id);

            var ans = new List<Answer>();
            var question = new Question()
            {
                Text = model.Question,
                //Answer = model.Answer,
                LectureId = model.Id,
                //OriginalAuthorId = _context.Account.First(a => a.UserName.ToUpper() == HttpContext.User.Identity.Name.ToUpper()).Id,
                OriginalAuthorId = _context.Account.First().Id,

            };

            if (!string.IsNullOrEmpty(model.Answer))
                ans.Add(new Answer
                {
                    Text = model.Answer,
                    IsCorrect = model.IsAnswer,
                    Question = question

                });


            if (!string.IsNullOrEmpty(model.AnswerOne))
                ans.Add(new Answer
                {
                    Text = model.AnswerOne,
                    IsCorrect = model.IsAnswerOne,
                    Question = question

                });


            if (!string.IsNullOrEmpty(model.AnswerTwo))
                ans.Add(new Answer
                {
                    Text = model.AnswerTwo,
                    IsCorrect = model.IsAnswerTwo,
                    Question = question

                });

            if (!string.IsNullOrEmpty(model.AnswerThree))
                ans.Add(new Answer
                {
                    Text = model.AnswerThree,
                    IsCorrect = model.IsAnswerThree,
                    Question = question

                });


            if (!string.IsNullOrEmpty(model.AnswerFour))
                ans.Add(new Answer
                {
                    Text = model.AnswerFour,
                    IsCorrect = model.IsAnswerFour,
                    Question = question

                });
            question.Answer = ans;
            _context.Add(question);
            _context.SaveChanges();

            return Redirect($"/User/Lecture?id={lecture.Id}");
        }

        public IActionResult StealLecture(int id)
        {
            var lecture = _context.Lecture.Include(l => l.Subject).FirstOrDefault(s => s.Id == id);
            var account = _context.Account.Include(a => a.Organization).FirstOrDefault(a => a.UserName == HttpContext.User.Identity.Name.ToUpper());


            return Ok();

        }

        public IActionResult StealSubject(int id)
        {
            var subject = _context.Subject.Include(s => s.Lecture).ThenInclude(l => l.Card).FirstOrDefault(s => s.Id == id);
            var account = _context.Account.Include(a => a.Organization).FirstOrDefault(a => a.UserName == HttpContext.User.Identity.Name.ToUpper());

            var steal = new Subject
            {
                AccountId = account.Id,
                Description = subject.Description,
                Ects = subject.Ects,
                Name = subject.Name,
                Professor = subject.Professor,
                SemesterNumber = subject.SemesterNumber,
                OrganizationId = subject.OrganizationId,
                SyllabusPath = subject.SyllabusPath
            };

            var lectures = subject.Lecture.ToList();
            var originalAuthorId = "";

            bool hasCards = false;
            foreach (var lecture in lectures)
            {
                if (lecture.Card.Count != 0)
                {
                    originalAuthorId = lecture.Card.First().OriginalAuthorId;
                    hasCards = true;
                    break;
                }
                
            }
            if(!hasCards)
                return Redirect("/");

            var author = _context.Account.Single(a => a.Id == originalAuthorId);
            author.VisyPoints += 10;

            _context.Add(steal);
            _context.SaveChanges();

            return Redirect("/");
        }
        
        public IActionResult AddSubject(AddSubjectVM model)
        {

            var account = _context.Account.Include(a => a.Organization).FirstOrDefault(a => a.UserName == HttpContext.User.Identity.Name.ToUpper());

            var subject = new Subject
            {
                AccountId = account.Id,
                Description = model.Description,
                Ects = model.Ects,
                Name = model.Name,
                Professor = model.Professor,
                SyllabusPath = model.SyllabusPath,
                OrganizationId = model.OrganizationId,
                SemesterNumber = model.SemesterNumber
            };

            _context.Add(subject);
            _context.SaveChanges();

            return RedirectToAction("Index", subject.Id);
        }

        public IActionResult AddLecture(AddLectureVM model)
        {
            var lecture = new Lecture
            {
                SubjectId = model.Id,
                Name = model.Name,
                Number = model.Number
            };

            _context.Add(lecture);
            _context.SaveChanges();

            return Redirect($"/User/Subject?id={lecture.SubjectId}");
        }

        public async Task<IActionResult> AddDocument(NewDocumentVM model)
        {

            var fileNameExtension =await new FileUpload().DocumentFolder(model.File);

            var doc = new Document
            {
                Title = model.Title,
                Description = model.Description,
                DocumentPath = fileNameExtension.First().Key,
                Extension = fileNameExtension.First().Value,
                LectureId = model.Id, 
                OriginalAuthor = _context.Account.First(a => a.UserName == HttpContext.User.Identity.Name.ToUpper()).UserName
            };

            _context.Add(doc);
            _context.SaveChanges();
            return Redirect($"/User/Lecture?id={model.Id}");
        }


        [Route("InitDB")]
        public async Task<bool> InitDb()
        {
            return await _context.InitializeDB(_userManager);
        }
    }
}