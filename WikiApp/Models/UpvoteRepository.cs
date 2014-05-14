using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WikiApp.DAL;

namespace WikiApp.Models
{
	public class UpvoteRepository
	{
		SubtitleContext m_db = new SubtitleContext();
		public IEnumerable<Upvote> GetAllUpvotes()
		{
			var result = (from u in m_db.Upvotes
						  orderby u.ID ascending
						  select u);
			return result;
		}

		/// Add a subtitle to database ///
		public void AddUpvote(Upvote u)
		{
			m_db.Upvotes.Add(u);
			//m_db.SaveChanges();
			Save();
		}

		public void RemoveUpvote(Upvote u)
		{
			m_db.Upvotes.Remove(u);
			Save();
		}

		/// Save changes to database ///
		public void Save()
		{
			m_db.SaveChanges();
		}
	}
}