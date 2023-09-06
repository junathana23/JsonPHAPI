using JsonPHSample.Models;
using Newtonsoft.Json;

namespace JsonPHSample.Connections;

public class JsonPHConnection : IJsonPHConnection
{
    public const string HTTPCLIENTNAME = "JsonPH";
    private readonly HttpClient _client;

    public JsonPHConnection(IHttpClientFactory clientFactory)
    {
        var _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
        _client = clientFactory.CreateClient(HTTPCLIENTNAME);
    }

    public async Task<string> GetUsers()
    {
        var url = "/users";
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
        var resStr = await _client.SendAsync(request);
        return await PhResponse(resStr);
    }

    public async Task<string> GetComments()
    {
        var url = "/comments";
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
        var resStr = await _client.SendAsync(request);
        return await PhResponse(resStr);
    }

    public async Task<string> GetPosts()
    {
        var url = "/posts";
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
        var resStr = await _client.SendAsync(request);
        return await PhResponse(resStr);
    }

    public async Task<string> GetTodos()
    {
        var url = "/todos";
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
        var resStr = await _client.SendAsync(request);
        return await PhResponse(resStr);
    }


    private async Task<string> PhResponse(HttpResponseMessage responseMessage)
    {
        if (responseMessage.IsSuccessStatusCode)
        {
            var resMsg = await responseMessage.Content.ReadAsStringAsync();
            return resMsg;

        }
        return "";
    }


}