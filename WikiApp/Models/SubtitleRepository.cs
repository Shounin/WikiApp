using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WikiApp.DAL;

namespace WikiApp.Models
{
    public class SubtitleRepository
    {
        SubtitleContext m_db = new SubtitleContext();

        private static SubtitleRepository instance;

        public static SubtitleRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SubtitleRepository();
                }
                return instance;
            }
        }

        /// Returns all Subtitles in database ///
        public IEnumerable<SubtitleFile> GetAllSubtitles()
        {
            var result = (from s in m_db.SubtitleFiles
                           orderby s.ID descending
                           select s);
            return result;
        }

        /// Returns all comments in the database ///
        public IEnumerable<SubtitleComment> GetAllComments()
        {
            var result = (from s in m_db.SubtitleComments
                          orderby s.ID descending
                          select s);
            return result;
        }

        /// Add a subtitle to database ///
        public void AddSubtitle(SubtitleFile s)
        {
            m_db.SubtitleFiles.Add(s);
            //m_db.SaveChanges();
            Save();
        }

        public void AddComment(SubtitleComment c)
        {
            int newID = 1;
            if (m_db.SubtitleComments.Count() > 0)
            {
                newID = m_db.SubtitleComments.Max(x => x.ID) + 1;
            }
            c.ID = newID;
            c.commentDate = DateTime.Now;
            m_db.SubtitleComments.Add(c);
            Save();
        }


        /// Save changes to database ///
        public void Save()
        {
            m_db.SaveChanges();
        }
    }
}