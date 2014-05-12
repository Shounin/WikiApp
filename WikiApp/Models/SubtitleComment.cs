using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WikiApp.Models;
using System.ComponentModel.DataAnnotations;

namespace WikiApp.Models
{
    public class SubtitleComment
    {
        public int ID;
        public DateTime dateAdded { get; set; }
        public int username;
    }
}