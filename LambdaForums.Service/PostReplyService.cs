using LambdaForums.Data;
using LamdaForums.Data;
using LamdaForums.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaForums.Service
{
    class PostReplyService : IPostReply
    {
        private readonly ApplicationDbContext _context; 
        public PostReplyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Create(PostReply postReply)
        {
            _context.PostReplies.Add(postReply);
            return _context.SaveChangesAsync();
        }

        public Task Delete(int Id)
        {
            PostReply reply = GetById(Id);
            _context.Remove(reply);
            return _context.SaveChangesAsync();
        }

        public IEnumerable<PostReply> GetAll()
        {
            return _context.PostReplies
                .Include(post => post.Post)
                .Include(user => user.User);
        }

        public PostReply GetById(int Id)
        {
            return _context.PostReplies
                .FirstOrDefault(reply => reply.Id == Id);
        }

        public Task UpdateContent(int Id, string newContent)
        {
            string reply = GetById(Id).Content = newContent;

            _context.Update(reply);

            return _context.SaveChangesAsync();
        }
    }
}
