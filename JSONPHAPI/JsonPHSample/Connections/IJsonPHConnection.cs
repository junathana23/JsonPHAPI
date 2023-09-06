
using JsonPHSample.Models;

namespace JsonPHSample.Connections;

public interface IJsonPHConnection
{
    Task<string> GetUsers();
    Task<string> GetComments();
    Task<string> GetPosts();
    Task<string> GetTodos();
}