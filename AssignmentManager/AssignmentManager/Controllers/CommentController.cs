﻿using AssignmentManager.DataAccess;
using AssignmentManager.Entities;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AssignmentManager.Controllers
{
    public class CommentController : Controller
    {
        public ActionResult Index(int id)
        {
            var commentsRepository = new CommentsRepository();
            var commentsList = new List<Comment>();

            var commentsFromRepository = commentsRepository
                .GetAll(comment => comment.AssignmentId == id);

            ViewBag.AssignmentId = id;

            var assignmentRepository = new AssignmentRepository();

            ViewBag.AssignmentTitle = assignmentRepository.GetById(id).Title;

            commentsList.AddRange(commentsFromRepository);

            return View(commentsList);
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            var entity = new Comment() 
            { 
                AssignmentId = id
            };
            
            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(Comment entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;

            var commentsRepository = new CommentsRepository();
            commentsRepository.Insert(entity);

            return RedirectToAction("Index/" + entity.AssignmentId);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var commentsRepository = new CommentsRepository();
            var entity = commentsRepository.GetById(id);

            return View(entity);
        }

        [HttpPost]
        public ActionResult Update(Comment entity)
        {
            entity.UpdatedAt = DateTime.Now;

            var commentsRepository = new CommentsRepository();
            commentsRepository.Update(entity);
            
            return RedirectToAction("Index/" + entity.AssignmentId);
        }
        
        public ActionResult Delete(int id)
        {
            var commentsRepository = new CommentsRepository();
            var entity = commentsRepository.GetById(id);
            commentsRepository.Delete(entity);

            return RedirectToAction("Index/" + entity.AssignmentId);
        }
	}
}