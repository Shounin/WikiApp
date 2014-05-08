using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WikiApp.Models;

namespace WikiApp.DAL
{
    public class SubtitleInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SubtitleContext>
    {
        protected override void Seed(SubtitleContext context)
        {
            var subtitles = new List<SubtitleFile>
            {
                new SubtitleFile{
                    name = "Armageddon",
                    category = "Action",
                    subtitleID  = 1
                },    
                new SubtitleFile{
                    name = "Gravity",
                    category = "Drama",
                    subtitleID  = 2
                },         
                new SubtitleFile{
                    name = "Hungergames",
                    category = "Drama",
                    subtitleID  = 3
                }
                
            };
            subtitles.ForEach(s => context.SubtitleFiles.Add(s));
            context.SaveChanges();
        }
    }
}