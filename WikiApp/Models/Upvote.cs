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

		[ForeignKey("SubtitleFile")]
		public int subtitleFileID { get; set; }
		public virtual SubtitleFile SubtitleFile { get; set; }
		
		public int applicationUserID { get; set; }
	}
}