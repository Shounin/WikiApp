using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WikiApp.Models
{
	public class Upvote
	{
		public int ID { get; set; }

		public int SubtitleID { get; set; }
		
		public int userID { get; set; }
	}
}