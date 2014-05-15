using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WikiApp.Models;
using System.Collections.Generic;
namespace WikiAppTests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void TestIndexWithMoreThan10Translations()
        {
            List<SubtitleFile> subtitles = new List<SubtitleFile>();
            for (int i = 0; i < 15; i++)
            {
                subtitles.Add(new SubtitleFile
                {
                    ID = i,
                    name = "Subtitle" + i.ToString(),
                    category = "Category" + i.ToString(),
                    path = "path" + i.ToString(),
                    upvote = i
                });
            }

            
        }
    }
}
