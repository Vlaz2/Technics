using System;
using System.Threading.Tasks;
using Technics.com.Interfaces;
using Technics.com.Models;

namespace Technics.com.Repository
{
    public class CommentRepository:IComment
    {
        private readonly AppDbContext appDbContext;

        public CommentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task AddCommentAsync(string message, long productId, long userId)
        {
            Comment comment = new Comment();
            comment.DateTime = DateTime.Now;
            comment.Message = message;
            comment.ProductId = productId;
            comment.UserId = userId;
            await appDbContext.AddAsync(comment);
            await appDbContext.SaveChangesAsync();
        }
    }
}
