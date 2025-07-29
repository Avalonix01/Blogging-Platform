using Microsoft.EntityFrameworkCore;
using BlogPlatform.Entities;
using BlogPlatform.Data;
using MediatR;

namespace BlogPlatform.Features.Comments.Delete;

public class DeleteCommentHandler(BlogDbContext context, ILogger<DeleteCommentHandler> logger)
    : IRequestHandler<DeleteCommentCommand>
{
    public async Task Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await context.Comments
            .FirstOrDefaultAsync(c => c.Id == request.CommentId, cancellationToken);

        if (comment is null)
        {
            logger.LogInformation("Comment with ID {CommentId} not found", request.CommentId);
            throw new NullReferenceException("Comment not found");
        }
        
        var isAuthorized = await IsUserAuthorized(request.UserId, comment, cancellationToken);

        if (!isAuthorized)
        {
            logger.LogInformation("Comment with ID {CommentId} not authorized", request.CommentId);
            throw new UnauthorizedAccessException("You are not authorized to delete this comment.");
        }
        
        context.Comments.Remove(comment);
        await context.SaveChangesAsync(cancellationToken);
        
        logger.LogInformation("Comment with ID {CommentId} deleted successfully", request.CommentId);
    }
    
    private async Task<bool> IsUserAuthorized(string userId, Comment comment, CancellationToken cancellationToken)
    {
        if (comment.AuthorId == userId)
        {
            logger.LogInformation("User {UserId} is the author of comment {CommentId}", userId, comment.Id);
            return true;
        }
        
        var blog = await context.Blogs
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == comment.BlogId, cancellationToken);

        return blog?.AuthorId == userId;
    }
}   