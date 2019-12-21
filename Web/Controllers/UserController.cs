using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            //account = string.IsNullOrEmpty(username) ? 
            //    _context.Account.Include(a => a.Organization).FirstOrDefault(a => a.UserName == HttpContext.User.Identity.Name.ToUpper()) : 
            //    _context.Account.Include(a => a.Organization).FirstOrDefault(a => a.NormalizedUserName == username.ToUpper());

            account = string.IsNullOrEmpty(username) ?
                _context.Account.Include(a => a.Organization).FirstOrDefault() :
                _context.Account.Include(a => a.Organization).FirstOrDefault(a => a.NormalizedUserName == username.ToUpper());
            //account = _context.Account.Include(a=>a.Organization).FirstOrDefault();

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
                          _context.Account.Include(a => a.Organization).FirstOrDefault();

            model.Name = subject?.Name;

            model.User = new UserDataVM
            {
                FirstName = account.FirstName,
                LastName = account.LastName,
                AvatarLink = account.AvatarLink,
                Organization = $"{account.Organization.Name}, {account.Organization.Location}",
                ReputationPoints = account.VisyPoints ?? 0
            };

            model.Cards = _context.Card.Where(c => c.Lecture.SubjectId == id).Select(c => new CardVM
            {
                Id = c.Id,
                Answer = c.Answer,
                Question = c.Question,
                Author = c.OriginalAuthor.UserName
            }).ToList();

            model.Documents = _context.Document.Where(c => c.Lecture.SubjectId == id).Select(d => new DocumentVM
            {
                Id = d.Id,
                Title = d.Title,
                Description = d.Description,
            }).ToList();

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

        [Route("InitDB")]
        public async Task<bool> InitDb()
        {
            return await _context.InitializeDB(_userManager);
        }
    }
}