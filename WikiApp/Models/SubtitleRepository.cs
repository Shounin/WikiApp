﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WikiApp.DAL;

namespace WikiApp.Models
{
    public class SubtitleRepository
    {
        SubtitleContext m_db = new SubtitleContext();

        private static SubtitleRepository instance;

        public static SubtitleRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SubtitleRepository();
                }
                return instance;
            }
        }

        /// Returns all Subtitles in database ///
        public IEnumerable<SubtitleFile> GetAllSubtitles()
        {
            var result = (from s in m_db.SubtitleFiles
                           orderby s.ID descending
                           select s);
            return result;
        }

        /// Returns all comments in the database ///
        public IEnumerable<SubtitleComment> GetAllComments()
        {
            var result = (from s in m_db.SubtitleComments
                          orderby s.ID descending
                          select s);
            return result;
        }

        /// Add a subtitle to database ///
        public void AddSubtitle(SubtitleFile s)
        {
            m_db.SubtitleFiles.Add(s);
            //m_db.SaveChanges();
            Save();
        }

        public void AddComment(SubtitleComment c)
        {
            int newID = 1;
            if (m_db.SubtitleComments.Count() > 0)
            {
                newID = m_db.SubtitleComments.Max(x => x.ID) + 1;
            }
            c.ID = newID;
            c.commentDate = DateTime.Now;
            m_db.SubtitleComments.Add(c);
            Save();
        }
		// Functions for Upvotes.
		public IEnumerable<Upvote> GetAllUpvotes()
		{
			var result = (from u in m_db.Upvotes
						  orderby u.ID ascending
						  select u);
			return result;
		}

		// Add an upvote to database
		public void AddUpvote(Upvote u)
		{
			m_db.Upvotes.Add(u);
			Save();
		}

		// Remove upvote from database.
		public void RemoveUpvote(Upvote u)
		{
			m_db.Upvotes.Remove(u);
			Save();
		}

		// Returns an Upvote with the given SubtitleFileID
		public Upvote GetUpvoteByID(int subTitleFileID)
		{
			var result = (from u in m_db.Upvotes
						  where u.SubtitleFileID == subTitleFileID
						  select u).SingleOrDefault();
			return result;
		}

		// Returns a SubtitleFile with the given SubtitleFileID
		public SubtitleFile GetSubtitleByID(int subTitleFileID)
		{
			var result = (from s in m_db.SubtitleFiles
						  where s.ID == subTitleFileID
						  select s).SingleOrDefault();
			return result;
		}

        /// Save changes to database ///
        public void Save()
        {
            m_db.SaveChanges();
        }
    }
}