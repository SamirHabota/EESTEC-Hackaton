using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Viewmodels.CardVM;

namespace Web.Controllers
{
    public class CardController : Controller
    {

        private readonly VisyLrnContext _context;
        public CardController(VisyLrnContext context)
        {
            _context = context;
        }

        public IActionResult SelectLectures()
        {
            var List = _context.Subject.Include(i => i.Lecture).Where(w => w.Account.NormalizedUserName == HttpContext.User.Identity.Name.ToUpper()).ToList();
            var Model = new Viewmodels.Quiz.SelectLecturesVM
            {
                Subjects = new List<Viewmodels.Quiz.SelectLecturesVM.Subject>()
            };
            foreach (var item in List)
            {
                Model.Subjects.Add(new Viewmodels.Quiz.SelectLecturesVM.Subject
                {
                    Name = item.Name,
                    Id = item.Id,
                    Lectures = item.Lecture.Select(s => new Viewmodels.Quiz.SelectLecturesVM.Lecture
                    {
                        Name = s.Name,
                        Id = s.Id
                    }).ToList()
                });
            }

            return View(Model);
        }

        public IActionResult Index(int[] lectures)
        {

            List<Lecture> list = new List<Lecture>();

            foreach (var lectureId in lectures)
            {
                var lec = _context.Lecture.Include(l => l.Subject).Single(l => l.Id == lectureId);
                list.Add(lec);
            }

            var noDups = list.GroupBy(x => x.SubjectId).Select(x => x.First()).ToList();

            var returnModel = new LecturesVM()
            {
                Lectures = list,
                NoDups = noDups
            };

            return View(returnModel);
        }

        public IActionResult ShowNextCard(int[] lectures, int currentCardId, int priority)
        {

            if (currentCardId != 0)
            {
                _context.Card.Find(currentCardId).LastShwon = DateTime.Now;
                Priority finalPriority = Priority.Low;
                switch (priority)
                {
                    case 0:
                        finalPriority = Priority.Low;
                        break;
                    case 1:
                        finalPriority = Priority.Medium;
                        break;
                    case 2:
                        finalPriority = Priority.High;
                        break;
                };
                _context.Card.Find(currentCardId).Priority = finalPriority;
                _context.SaveChanges();
            }

            List<Card> allCards = new List<Card>();
            foreach (var lectureId in lectures)
            {
                foreach (var card in _context.Card.ToList())
                {
                    if (card.LectureId == lectureId) allCards.Add(card);
                }
            }

            allCards = allCards.OrderByDescending(c => c.Priority).ThenBy(c => c.LastShwon).ToList();
            var theCard = _context.Card.Include(c => c.Lecture).Single(c => c.Id == allCards[0].Id);



            //napravi sta ako je prazno
            var returnModel = new QuestionAnswerVM()
            {
                Answer = allCards[0].Answer,
                Question = allCards[0].Question,
                CardId = allCards[0].Id,
                Lecture = theCard.Lecture.Name
            };


            return PartialView(returnModel);
        }
    }
}