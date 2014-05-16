using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WikiApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WikiApp.Models
{
    public class SubtitleComment
    {
        public int ID { get; set; }
        public DateTime commentDate { get; set; }
        public string username { get; set; }
        public string commentText { get; set; }

        public int SubtitleFileID { get; set; }
        public virtual SubtitleFile SubtitleFile { get; set; }

        public SubtitleComment()
        {
            commentDate= DateTime.Now;
            
        }
    }
}