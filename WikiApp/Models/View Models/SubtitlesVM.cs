using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WikiApp.Models.View_Models
{
    //This model is to keep information about all the subtitles so that we can orginize them in to alphabetical order,
    // as well as show all the files in one place.
    public class SubtitlesVM
    {
        //This function keeps track of all the Newest Movies
        public IEnumerable<SubtitleFile> NewestMovies { get; set; }

        //This function keeps track of all the most upvoted movies
        public IEnumerable<SubtitleFile> PopularMovies { get; set; }

        //This function keeps track of all the Newest TV shows
        public IEnumerable<SubtitleFile> NewestTV { get; set; }

        //This function keeps track of all the most upvoted TV show
        public IEnumerable<SubtitleFile> PopularTV { get; set; }

        //This function keeps track of all the files
        public IEnumerable<SubtitleFile> allFiles { get; set; }

        //This function keeps track of all the files that are sorted in to alphabetical order 
		public IEnumerable<IGrouping<char, SubtitleFile>> stuff;

       
       
       


    }
}