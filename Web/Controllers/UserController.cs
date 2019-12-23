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
                _context.Account.Include(a => a.Organization).FirstOrDefault(a => a.UserName.ToUpper() == HttpContext.User.Identity.Name.ToUpper()) :
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
         
            model.Documents = _context.Document.Where(c => c.LectureId == id).Select(d => new DocumentVM
            {
                Id = d.Id,
                Title = d.Title,
                Description = d.Description,
                DocType = d.Extension,
                DocPath = d.DocumentPath,

            }).ToList();
           
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


            var hexColors = new List<string>
            {
                "#735cb0",
                "#00a4ef",
                "#6ab43e",
                "#e89d41",
                "#fd4084",
                "#e73841",
                "#b11852",
                "#602683",
                "#188984",
                "#ed7020",
            };

            var card = new Card()
            {
                Question = model.Question,
                Answer = model.Answer,
                LectureId = model.Id,
                OriginalAuthorId = _context.Account.First().Id,
                LastShwon = DateTime.MinValue,
                Priority = Priority.High,
                Color = hexColors.Distinct().OrderBy(x => System.Guid.NewGuid().ToString()).First()
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

        _context.Add(steal);

        var lectures = subject.Lecture.ToList();

        foreach(var lecture in lectures){

            var newLecture = new Lecture{
                Number = lecture.Number,
                Name = lecture.Name,
                Subject = steal
            };

            _context.Lecture.Add(newLecture);

            var Cards = _context.Card.Where(w=>w.LectureId == lecture.Id).ToList();
            var Questions = _context.Question.Where(w=>w.LectureId == lecture.Id).ToList();
            var Documents = _context.Document.Where(w=>w.LectureId == lecture.Id).ToList();

            foreach (var card in Cards)
                _context.Card.Add(new Card{
                    Answer = card.Answer,
                    Color = card.Color,
                    LastShwon = DateTime.MinValue,
                    Priority = Priority.High,
                    Lecture = newLecture,
                    OriginalAuthorId = card.OriginalAuthorId,
                    Question = card.Question
                });

            foreach (var Question in Questions){
                var newQuestion = new Question{
                    Text = Question.Text,
                    Lecture = newLecture,
                    OriginalAuthorId = Question.OriginalAuthorId,
                };
                _context.Question.Add(newQuestion);

                var Answers = _context.Answer.Where(w=>w.QuestionId == Question.Id).ToList();
                foreach (var Answer in Answers)
                    _context.Answer.Add(new Answer{
                        IsCorrect = Answer.IsCorrect,
                        Question = newQuestion,
                        Text = Answer.Text
                    });
            }

             foreach(var Document in Documents)
                _context.Document.Add(new Document
                {Description = Document.Description,
                DocumentPath = Document.DocumentPath,
                Lecture = newLecture,
                Extension = Document.Extension,
                TypeId = 1,
                OriginalAuthor = Document.OriginalAuthor});   

        }

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

        var fileNameExtension = await new FileUpload().DocumentFolder(model.File);

        var doc = new Document
        {
            Title = model.Title,
            Description = model.Description,
            DocumentPath = fileNameExtension.First().Key,
            Extension = fileNameExtension.First().Value,
            LectureId = model.Id,
            OriginalAuthor = _context.Account.First(a => a.UserName == HttpContext.User.Identity.Name.ToUpper()).UserName,
            TypeId = 1
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