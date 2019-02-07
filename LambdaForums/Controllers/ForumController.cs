using LambdaForums.Models.Forum;
using LambdaForums.Models.Post;
using LamdaForums.Data;
using LamdaForums.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LambdaForums.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;
        private readonly IPost _postService;
        public ForumController(IForum forumService)
        {
            _forumService = forumService;
        }

        public IActionResult Index()
        {

            var forums = _forumService.GetAll().Select(forum => new ForumListingModel
            {
                Id = forum.Id,
                Title = forum.Title,
                Description = forum.Description,
                Created = forum.Created,
                ImageUrl = forum.ImageUrl

            });

            var model = new ForumIndexModel
            {
                ForumLists = forums
            };
            return View(model);
        }

        public IActionResult Post(int Id)
        {
            var forum = _forumService.GetById(Id);

            var posts = forum.Posts;

            var postListing = posts.Select(post => new PostListingModel
            {
                Id = post.Id,
                AuthorId = post.User.Id,
                AuthorRating = post.User.Rating,
                Title = post.Title,
                Created = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Forum= BuildForumListing(post)
            });

            var model = new ForumTopicModel
            {
                Forum = BuildForumListing(forum),
                PostLists = postListing
            };
            return View(model);
        }

        private ForumListingModel BuildForumListing(Post post)
        {
            var forum = post.Forum;
            return BuildForumListing(forum);
        }
        private ForumListingModel BuildForumListing(Forum forum)
        {
            
            return new ForumListingModel
            {
                Id = forum.Id,
                ImageUrl = forum.ImageUrl,
                Description = forum.Description,
                Title = forum.Title
            };
        }
    }
}