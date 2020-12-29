using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Technics.com.Models;

namespace Technics.com.Interfaces
{
    public interface IComment
    {
        Task AddCommentAsync(string message, long productId, long userId);
    }
}
