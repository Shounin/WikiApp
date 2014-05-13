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
        public int upvote { get; set; }
        public string path { get; set; }
        public State state { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string file { get; set; }    //VarChar

        public SubtitleFile()
        {
            dateAdded = DateTime.Now;
        }
    }
}

