using LamdaForums.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LamdaForums.Data
{
    public interface IPost
    {
        Post GetById(int Id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFilteredPosts(string searchQuery);
        Task Create(Post post);
        Task Delete(int Id);
        Task UpdatePostTitle(int Id, string newTitle);
        Task UpdatePostContent(int Id, string newContent);
        Task AddReply(PostReply reply);
        IEnumerable<Post> GetPostsByForum(int id);
    }
}
