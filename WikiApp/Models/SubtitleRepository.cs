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

       /* public IEnumerable<SubtitleFile> GetAllSubtitles()
        {
            var resault = (from s in m_db.SubtitleFiles
                           orderby s.subtitleID descending
                           select s);
            return resault;
          
        }
        */

    }
}