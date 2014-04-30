using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funny.DB;
using Funny.Models;

namespace Funny.Services {
    public class StoryViewer {
        public List<Story> ShowAllStories(){
            var result = new List<Story>();
            using (var session = new Session()){
                result = session.Stories
                    .OrderByDescending(s => s.Rating)
                    .ToList();
            }
            return result;
        }
    }
}
