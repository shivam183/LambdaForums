using LamdaForums.Data.Models;
using System;
using System.Collections.Generic;

namespace LambdaForums.Models.Forum
{
    public class ForumListingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string ImageUrl { get; set; }
       
       
    }
}
