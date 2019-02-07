using LambdaForums.Data;
using LamdaForums.Data;
using LamdaForums.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambdaForums.Service
{
    class PostService : IPost
    {
        private readonly ApplicationDbContext _context;
        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddReply(PostReply reply)
        {
            throw new System.NotImplementedException();
        }

        public Task Create(Post post)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int Id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Post GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Post> GetPostsByForum(int id)
        {
            return _context.Forums.Where(forum => forum.Id == id)
                .First()
                .Posts;

        }

        public Task UpdatePostContent(int Id, string newContent)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdatePostTitle(int Id, string newTitle)
        {
            throw new System.NotImplementedException();
        }
    }
}
