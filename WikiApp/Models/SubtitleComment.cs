﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WikiApp.Models;
using System.ComponentModel.DataAnnotations;

namespace WikiApp.Models
{
    public class SubtitleComment
    {
        public int ID { get; set; }
        public DateTime commentDate { get; set; }
        public string username { get; set; }
        public string commentText { get; set; }
    }
}