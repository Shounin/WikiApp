﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WikiApp.Models;
using System.ComponentModel.DataAnnotations;

namespace WikiApp.Models
{
    public class SubtitleFile
    {
        // Needs to implement upvote method
        public int subtitleID { get; set; }
        public string name { get; set; }
        public string category { get; set; }
    }
}
