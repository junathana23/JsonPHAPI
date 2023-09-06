using Microsoft.AspNetCore.Mvc;
using JsonPHSample.Services;
using JsonPHSample.Models;

namespace JsonPHSample.Controllers;

[ApiController]
[Route("[controller]")]
public class JsonPHController : ControllerBase
{
    private readonly IPhService _service;

    public JsonPHController( IPhService service)
    {
        _service = service;
    }

    [HttpGet("GetUsers")]
    public async Task<string> GetUsers()
    {
        var result = await _service.GetUsers();
        return result;
    }

    [HttpGet("GetPosts")]
    public async Task<string> GetPosts()
    {
        var result = await _service.GetPosts();
        return result;
    }

    [HttpGet("GetComments")]
    public async Task<string> GetComments()
    {
        var result = await _service.GetComments();
        return result;
    }

    [HttpGet("GetTodos")]
    public async Task<string> GetTodos()
    {
        var result = await _service.GetTodos();
        return result;
    }

    [HttpGet("GetPostsById/{userId}")]
    public async Task<IEnumerable<PostModel>> GetPostsById(int userId)
    {
        var result = await _service.GetPostsById(userId);
        return result;
    }

    [HttpGet("GetCommentsById/{postId}")]
    public async Task<IEnumerable<CommentModel>> GetCommentsById(int postId)
    {
        var result = await _service.GetCommentsById(postId);
        return result;
    }



}
