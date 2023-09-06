using JsonPHSample.Models;

namespace JsonPHSample.Services;

public interface IPhService
{
    Task<string> GetUsers();
    Task<string> GetPosts();
    Task<string> GetComments();
    Task<IEnumerable<CommentModel>> GetCommentsById(int postId);
    Task<IEnumerable<PostModel>> GetPostsById(int userId);
    Task<string> GetTodos();
}