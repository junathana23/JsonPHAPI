using JsonPHSample.Connections;
using JsonPHSample.Models;
using Newtonsoft.Json;

namespace JsonPHSample.Services;

public class PhServices : IPhService
{
    private readonly IJsonPHConnection _connection;

    public PhServices(IJsonPHConnection connection)
    {
        _connection = connection;
    }

    public async Task<string> GetUsers()
    {
        return await _connection.GetUsers();
    }

    public async Task<string> GetComments()
    {
        return await _connection.GetComments();
    }

    public async Task<string> GetPosts()
    {
        return await _connection.GetPosts();
    }

    public async Task<string> GetTodos()
    {
        return await _connection.GetTodos();
    }

    public async Task<IEnumerable<PostModel>> GetPostsById(int userId)
    {
        try
        {
            var result = await _connection.GetPosts();
            var posts = JsonConvert.DeserializeObject<List<PostModel>>(result);
            return posts.Where(p => p.userId == userId);
        }
        catch (Exception)
        {

            throw;
        }
        //write a logic to filter out the results based on userId and return it to Front end
    }
    public async Task<IEnumerable<CommentModel>> GetCommentsById(int postId)
    {
        try
        {
            var result = await _connection.GetComments();
            var posts = JsonConvert.DeserializeObject<List<CommentModel>>(result);
            return posts.Where(p => p.postId == postId);
        }
        catch (Exception)
        {

            throw;
        }
    }



}