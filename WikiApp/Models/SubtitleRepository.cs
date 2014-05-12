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

        public IEnumerable<SubtitleFile> GetAllSubtitles()
        {
            var result = (from s in m_db.SubtitleFiles
                           orderby s.ID descending
                           select s);
            return result;
        }

        public IEnumerable<SubtitleComment> GetAllComments()
        {
            var result = (from s in m_db.SubtitleComments
                          orderby s.ID descending
                          select s);
            return result;
        }

        public void AddSubtitle(SubtitleFile s)
        {
            m_db.SubtitleFiles.Add(s);
            //m_db.SaveChanges();
            Save();
        }

        public void Save()
        {
            m_db.SaveChanges();
        }
    }
}