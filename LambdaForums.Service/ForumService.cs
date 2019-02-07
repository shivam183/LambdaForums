using LambdaForums.Data;
using LamdaForums.Data;
using LamdaForums.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambdaForums.Service
{
    public class ForumService : IForum
    {
        private readonly ApplicationDbContext _context;
        public ForumService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Create(Forum forum)
        {
            _context.Forums.Add(forum);
            return _context.SaveChangesAsync();
        }

        public Task Delete(int forumId)
        {
            var task = _context.Forums
                 .FirstOrDefault(forum => forum.Id == forumId);

            _context.Forums.Remove(task);

            return _context.SaveChangesAsync();

        }

        public IEnumerable<Forum> GetAll()
        {
            return _context.Forums
                .Include(forum => forum.Posts);
        }

        public IEnumerable<ApplicationUser> GetAllActiveUsers()
        {
            return _context.ApplicationUsers;
        }

        public Forum GetById(int id)
        {
            return _context.Forums
                .Where(forum => forum.Id == id)
                .Include(f => f.Posts).ThenInclude(g => g.Replies)
                .Include(f => f.Posts).ThenInclude(g => g.User)
                .FirstOrDefault();
        }

        public Task UpdateForumDescription(int forumId, string newDescription)
        {
            var task = GetById(forumId);
            task.Description = newDescription;

            _context.Forums.Update(task);

            return _context.SaveChangesAsync();
        }

        public Task UpdateForumTitle(int forumId, string newTitle)
        {
            var task = GetById(forumId);

            task.Title = newTitle;

            _context.Forums.Update(task);

            return _context.SaveChangesAsync();
        }
    }
}
