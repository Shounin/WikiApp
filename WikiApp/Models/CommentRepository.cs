using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WikiApp.DAL;


namespace WikiApp.Models
{
    public class CommentRepository
    {
        private static CommentRepository instance;

        public static CommentRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommentRepository();
                }
                return instance;
            }
        }

        private List<SubtitleComment> comments = null;

        private CommentRepository()
        {
            this.comments = new List<SubtitleComment>();
            SubtitleComment comment1 = new SubtitleComment { commentText = "Great video", commentDate = new DateTime(2014, 3, 1, 12, 30, 00), username = "Herdis" };
            this.comments.Add(comment1);
        }

        public IEnumerable<SubtitleComment> GetComments()
        {
            var result = (from c in comments
                          orderby c.commentDate ascending
                          select c);

            return result;
        }

        public void AddComment(SubtitleComment c)
        {
            int newID = 1;
            if (comments.Count() > 0)
            {
                newID = comments.Max(x => x.ID) + 1;
            }
            c.ID = newID;
            c.commentDate = DateTime.Now;
            comments.Add(c);
        }

    }
}