using LambdaForums.Data;
using LamdaForums.Data;
using LamdaForums.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
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
            _context.AddAsync(forum);
            return _context.SaveChangesAsync();
        }

        public Task Delete(int forumId)
        {
           var task= _context.Forums
                .FirstOrDefaultAsync(forum => forum.Id == forumId);

            _context.Remove(task);

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
                .Include(forum=> forum.Posts)
                .FirstOrDefault(forum => forum.Id == id);
        }

        public Task UpdateForumDescription(int forumId, string newDescription)
        {
            string task = _context.Forums
                .FirstOrDefault(forum => forum.Id == forumId)
                .Description = newDescription;

            _context.Update(task);

            return _context.SaveChangesAsync();
        }

        public Task UpdateForumTitle(int forumId, string newTitle)
        {
            string task = _context.Forums
                .FirstOrDefault(forum => forum.Id == forumId)
                .Title = newTitle;

            _context.Update(task);

            return _context.SaveChangesAsync();
        }
    }
}
