using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WikiApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WikiApp.Models
{
    public class SubtitleFile
    {
        // Needs to implement upvote method
        public int ID { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public DateTime dateAdded { get; set; }
        public string path { get; set; }
        //public char key { get; set; }

        public State state { get; set; }


        [Column(TypeName = "TEXT")]
        public string SubtitleText { get; set; }    //VarChar

        public virtual ICollection<SubtitleComment> SubtitleComments { get; set; }

		public virtual ICollection<Upvote> Upvotes { get; set; }


        public SubtitleFile()
        {
            dateAdded = DateTime.Now;
            
        }
        
		public int upvote { get; set; }

    }
}

