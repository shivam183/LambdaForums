using LambdaForums.Models.Forum;
using LamdaForums.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LambdaForums.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;
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
                Created=forum.Created,
                ImageUrl=forum.ImageUrl

            });

            var model = new ForumIndexModel
            {
                ForumLists = forums
            };
            return View(model);
        }
    }
}