using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WikiApp.Models.View_Models
{
    public class SubtitlesVM
    {
        
        public IEnumerable<SubtitleFile> allMovies { get; set; }
        public IEnumerable<SubtitleFile> allTV { get; set; }
        public IEnumerable<SubtitleFile> allFiles { get; set; }
        public char FirstLetter { get; set; }
		public IEnumerable<SubtitleFile> SearchResultList { get; set; }

        public SubtitleFile subtitleFile { get; set; }
    }
}