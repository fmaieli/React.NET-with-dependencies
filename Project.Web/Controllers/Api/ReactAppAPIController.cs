using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Project.Web.Controllers.Api
{
    public class ReactAppAPIController : Controller
    {
        private List<CommentModel> _comments;

        public ActionResult Comments()
        {
            _comments = new List<CommentModel>
            {
                new CommentModel
                {
                    Id = 1,
                    Author = "Author 1",
                    Text = "Hello Reactjs.NET!"
                },
                new CommentModel
                {
                    Id = 2,
                    Author = "Author 2",
                    Text = "This is working?"
                },
                new CommentModel
                {
                    Id = 3,
                    Author = "Author 3",
                    Text = "This is just an example!"
                },
                new CommentModel
                {
                    Id = 4,
                    Author = "Author 3",
                    Text = "This is working!"
                }
            };

            return Json(_comments, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddComment(CommentModel comment)
        {
            Random rnd = new Random();

            // Create a fake ID for this comment
            comment.Id = rnd.Next(101);
            //_comments.Add(comment);
            return Content("Success :)");
        }

        public class CommentModel
        {
            public int Id { get; set; }
            public string Author { get; set; }
            public string Text { get; set; }
        }
    }
}