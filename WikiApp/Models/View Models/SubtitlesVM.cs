﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WikiApp.Models.View_Models
{
    public class SubtitlesVM
    {
        
        public IEnumerable<SubtitleFile> NewestMovies { get; set; }

        public IEnumerable<SubtitleFile> PopularMovies { get; set; }
     
        public IEnumerable<SubtitleFile> NewestTV { get; set; }
        public IEnumerable<SubtitleFile> PopularTV { get; set; }
        public IEnumerable<SubtitleFile> allFiles { get; set; }
 
		public IEnumerable<IGrouping<char, SubtitleFile>> stuff;

       
       
       


    }
}