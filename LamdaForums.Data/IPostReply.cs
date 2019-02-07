using LamdaForums.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LamdaForums.Data
{
    public interface IPostReply
    {
        PostReply GetById(int Id);
        IEnumerable<PostReply> GetAll();
        Task Create(PostReply postReply);
        Task Delete(int Id);
        Task UpdateContent(int Id, string newReply);
        
    }
}
