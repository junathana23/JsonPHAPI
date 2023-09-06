using Newtonsoft.Json;
namespace JsonPHSample.Models;

public class PostModel
{
    public int userId { get; set; }
    [JsonProperty("id")]
    public int postId { get; set; }
    public string title { get; set; }
    public string body { get; set; }

}