using System.Threading;
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
    public class QuizController : Controller
    {
        private readonly VisyLrnContext _context;
        public QuizController(VisyLrnContext context)
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

        public IActionResult Generate(List<int> Lectures)
        {

            List<Question> Questions = _context.Question.Where(w => Lectures.Contains(w.LectureId)).OrderBy(o => Guid.NewGuid()).ToList();

            var newTest = new Test
            {
                AccountId = _context.Account.Where(w => w.NormalizedUserName == User.Identity.Name.ToUpper()).FirstOrDefault().Id,
                BeginDate = DateTime.Now,
                TotalScore = 0,
                isFinished = false,
                currentOrdinalNumber = 0
            };

            _context.Test.Add(newTest);

            int brojac = 0;

            foreach (var Question in Questions)
            {
                var testQuestion = new TestQuestion
                {
                    Test = newTest,
                    Question = Question,
                    OrdinalNumber = brojac++
                };

                _context.TestQuestion.Add(testQuestion);
            }

            newTest.QuestionPoints = 100 / Questions.Count;

            _context.SaveChanges();

            return Redirect($"Start?testId={newTest.Id}");
        }

        public IActionResult Start(int testId)
        {

            var Model = new Viewmodels.Quiz.TestVM
            {
                Id = testId
            };

            return View("Quiz", Model);
        }

        public IActionResult GetNextQuestion(int testId, int[] Answers, bool isInitial)
        {

            if (!isInitial)
            {
                var Test = _context.Test.Include(i => i.TestQuestion).Where(w => w.Id == testId).FirstOrDefault();

                var thisQuestionId = _context.Test.Where(w => w.Id == testId).Select(s => s.TestQuestion.Where(r => r.OrdinalNumber == s.currentOrdinalNumber).FirstOrDefault()).FirstOrDefault().QuestionId;

                var answers = _context.Answer.Where(w => w.QuestionId == thisQuestionId && w.IsCorrect).Select(s => s.Id).ToList();
                var areCorrect = answers.All(Answers.Contains);

                if (areCorrect)
                    Test.TotalScore += Test.QuestionPoints;

                Test.currentOrdinalNumber++;

                _context.SaveChanges();

                if (Test.currentOrdinalNumber == Test.TestQuestion.Count)
                {
                    Test.isFinished = true;
                    Test.EndDate = DateTime.Now;
                    _context.SaveChanges();
                    return RedirectToAction("Result", Test.Id);
                }
            }

            var currentQuestionId = _context.Test.Where(w => w.Id == testId).Select(s => s.TestQuestion.Where(r => r.OrdinalNumber == s.currentOrdinalNumber).FirstOrDefault()).FirstOrDefault().QuestionId;

            var question = _context.Question.Include(i => i.Answer).Where(w => w.Id == currentQuestionId).FirstOrDefault();

            var Model = new Viewmodels.Quiz.QuestionVM
            {
                Text = question.Text,
                Answers = question.Answer.Select(s => new Viewmodels.Quiz.QuestionVM.Answer
                {
                    Id = s.Id,
                    Text = s.Text
                }).ToList(),
                currentQuestion = _context.Test.Where(w => w.Id == testId).Select(s => $"{s.currentOrdinalNumber + 1}/{s.TestQuestion.Count}").FirstOrDefault(),
                isMultiple = question.Answer.Count(w => w.IsCorrect) > 1
            };

            return PartialView("QuizQuestion", Model);
        }

        public IActionResult Result(int testId)
        {
            return View(_context.Test.Where(w=>w.Id == testId).FirstOrDefault().TotalScore);
        }
    }
}