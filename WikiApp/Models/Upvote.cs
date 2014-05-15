using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WikiApp.Models
{
	public class Upvote
	{
		public int ID { get; set; }

		public int SubtitleFileID { get; set; }
		public virtual SubtitleFile SubtitleFile { get; set; }
		
		public string applicationUserID { get; set; }
	}
}