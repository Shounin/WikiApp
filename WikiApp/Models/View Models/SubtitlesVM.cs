using System;
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
        public char FirstLetter { get; set; }
		public IEnumerable<SubtitleFile> SearchResultList { get; set; }

        public SubtitleFile subtitleFile { get; set; }

		public string category { get; set; }

        public IEnumerable<SubtitleFile>[] alphaBetical = new IEnumerable<SubtitleFile>[26];
        public IEnumerable<SubtitleFile> A { get; set; }
        public IEnumerable<SubtitleFile> B { get; set; }
        public IEnumerable<SubtitleFile> C { get; set; }
        public IEnumerable<SubtitleFile> D { get; set; }
        public IEnumerable<SubtitleFile> E { get; set; }
        public IEnumerable<SubtitleFile> F { get; set; }
        public IEnumerable<SubtitleFile> G { get; set; }
        public IEnumerable<SubtitleFile> H { get; set; }
        public IEnumerable<SubtitleFile> I { get; set; }
        public IEnumerable<SubtitleFile> J { get; set; }
        public IEnumerable<SubtitleFile> K{ get; set; }
        public IEnumerable<SubtitleFile> L { get; set; }
        public IEnumerable<SubtitleFile> M { get; set; }
        public IEnumerable<SubtitleFile> N { get; set; }
        public IEnumerable<SubtitleFile> O { get; set; }
        public IEnumerable<SubtitleFile> P { get; set; }
        public IEnumerable<SubtitleFile> Q { get; set; }
        public IEnumerable<SubtitleFile> R { get; set; }
        public IEnumerable<SubtitleFile> S { get; set; }
        public IEnumerable<SubtitleFile> T { get; set; }
        public IEnumerable<SubtitleFile> U { get; set; }
        public IEnumerable<SubtitleFile> V { get; set; }
        public IEnumerable<SubtitleFile> W { get; set; }
        public IEnumerable<SubtitleFile> X { get; set; }
        public IEnumerable<SubtitleFile> Y { get; set; }
       
        public IEnumerable<SubtitleFile> Z { get; set; }
        public IEnumerable<SubtitleFile> Tolur { get; set; }

        //public char[] numbers = new char[4] { 'A', 'B', 'C', 'D' };

        //public IEnumerable<SubtitleFile>[] subtitle = new IEnumerable<SubtitleFile>[4];
       
    }
}