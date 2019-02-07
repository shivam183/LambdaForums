using LambdaForums.Models.Forum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambdaForums.Models.Post
{
    public class ForumTopicModel
    {
        public ForumListingModel Forum { get; set; } 
        public IEnumerable<PostListingModel> PostLists { get; set; }
    }
}
