using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace api.Interfaces
{
    public interface ICommentRepository
    {
        Task <Comment> CreateAsync(Comment commentModel);
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment?> UpdateCommentAsync(int id, Comment comment);
        Task<bool> CommentExistsAsync(int id);
        Task<Comment?> DeleteAsync(int id);
    }
};