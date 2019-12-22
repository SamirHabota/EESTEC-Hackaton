﻿using System;
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
                Groups = _context.Group.Include(g => g.Post).ThenInclude(p => p.Comment).ToList(),
                Accounts = _context.Account.ToList()
            };

            return View(returmModel);
        }


        public IActionResult Like(int commentId) {
            var accountId = _context.Account.Where(w => w.NormalizedUserName == HttpContext.User.Identity.Name.ToUpper()).FirstOrDefault().Id;
            var like = new Like() {
                AccountId = accountId,
                CommentId = commentId
            };

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

            _context.Dislikes.Add(dislike);

            var like = _context.Likes.Where(d => d.AccountId == accountId && d.CommentId == commentId).FirstOrDefault();
            if (like != null) {
                _context.Likes.Remove(like);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");

        }

    }
}