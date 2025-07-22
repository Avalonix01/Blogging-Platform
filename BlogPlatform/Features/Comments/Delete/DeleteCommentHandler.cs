using Microsoft.EntityFrameworkCore;
using BlogPlatform.Entities;
using BlogPlatform.Data;
using MediatR;

namespace BlogPlatform.Features.Comments.Delete;

public class DeleteCommentHandler(BlogDbContext context)
    : IRequestHandler<DeleteCommentCommand>
{
    public async Task Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await context.Comments
            .FirstOrDefaultAsync(c => c.Id == request.CommentId, cancellationToken);
        
        if (comment is null)
            throw new NullReferenceException("Comment not found");
        
        var isAuthorized = await IsUserAuthorized(request.UserId, comment, cancellationToken);
        
        if (!isAuthorized)
            throw new UnauthorizedAccessException("You are not authorized to delete this comment.");
        
        context.Comments.Remove(comment);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    private async Task<bool> IsUserAuthorized(string userId, Comment comment, CancellationToken cancellationToken)
    {
        if (comment.AuthorId == userId)
            return true;
        
        var blog = await context.Blogs
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == comment.BlogId, cancellationToken);

        return blog?.AuthorId == userId;
    }
}   