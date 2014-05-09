﻿using System;
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
        

    }
}