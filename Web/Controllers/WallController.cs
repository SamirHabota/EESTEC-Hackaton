using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Viewmodels.WallVM;

namespace Web.Controllers
{
    public class WallController : Controller
    {

        private readonly VisyLrnContext _context;
        public WallController(VisyLrnContext context) {
            _context = context;
        }

        public IActionResult Index() {


            var returmModel = new WallWM() {
                Groups = _context.Group.Include(g => g.Post).ThenInclude(p => p.Comment).ThenInclude(p=>p.Likes).Include(g => g.Post).ThenInclude(p => p.Comment).ThenInclude(i=>i.Dislikes).ToList(),
                Accounts = _context.Account.ToList(),
                DislikedComms = _context.Dislikes.Where(w=>w.Account.UserName.ToUpper() == User.Identity.Name.ToUpper()).Select(s=>s.Comment.Id).ToList(),
                LikedComms = _context.Likes.Where(w=>w.Account.UserName.ToUpper() == User.Identity.Name.ToUpper()).Select(s=>s.Comment.Id).ToList()
            };

            return View(returmModel);
        }


        public IActionResult Like(int commentId) {
            var accountId = _context.Account.Where(w => w.NormalizedUserName == HttpContext.User.Identity.Name.ToUpper()).FirstOrDefault().Id;
            var like = new Like() {
                AccountId = accountId,
                CommentId = commentId
            };

            if (_context.Likes.Any(w=>w.AccountId == accountId && w.CommentId == commentId))
                return RedirectToAction("Index");

            _context.Likes.Add(like);

            var dislike = _context.Dislikes.Where(d => d.AccountId == accountId && d.CommentId == commentId).FirstOrDefault();
            if (dislike != null) {
                _context.Dislikes.Remove(dislike);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");



        }

        public IActionResult Dislike(int commentId) {
            var accountId = _context.Account.Where(w => w.NormalizedUserName == HttpContext.User.Identity.Name.ToUpper()).FirstOrDefault().Id;
            var dislike = new Dislike() {
                AccountId = accountId,
                CommentId = commentId
            };

            if (_context.Dislikes.Any(w=>w.AccountId == accountId && w.CommentId == commentId))
                return RedirectToAction("Index");

            _context.Dislikes.Add(dislike);

            var like = _context.Likes.Where(d => d.AccountId == accountId && d.CommentId == commentId).FirstOrDefault();
            if (like != null) {
                _context.Likes.Remove(like);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult AddPost(int groupId, string text) {

            var accountId = _context.Account.Where(w => w.NormalizedUserName == HttpContext.User.Identity.Name.ToUpper()).FirstOrDefault().Id;

            var newPost = new Post() {
                AccountId=accountId,
                Text=text,
                GroupId=groupId,
                DateCreated=DateTime.Now
            };
            _context.Post.Add(newPost);
            _context.SaveChanges();

            return Redirect("index");
        }


        public IActionResult AddComment(int postId, string text) {

            var accountId = _context.Account.Where(w => w.NormalizedUserName == HttpContext.User.Identity.Name.ToUpper()).FirstOrDefault().Id;

            var newComment = new Comment() {
                AccountId = accountId,
                Text = text,
                PostId = postId,
                DateCreated = DateTime.Now
            };

            _context.Comment.Add(newComment);
            _context.SaveChanges();

            return Redirect("index");
        }

    }
}