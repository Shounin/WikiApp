using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WikiApp.Models.View_Models
{
    public class CommentVM
    {
        public  IEnumerable<SubtitleFile> allSubtitleFiles { get; set; }
        public IEnumerable<SubtitleComment> allComments { get; set; }
    }
}