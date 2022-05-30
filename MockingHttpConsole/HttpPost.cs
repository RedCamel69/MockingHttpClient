using System.Text.Json;

namespace MockingHttpConsole
{
    public class HttpPost
    {
        private readonly HttpClient httpClient;
        private const string url = "https://jsonplaceholder.typicode.com/posts";

        public HttpPost(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<JsonElement>> GetPosts()
        {
            var response = await httpClient.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            var posts = JsonSerializer.Deserialize<IEnumerable<JsonElement>>(body);
            return posts;
        }

        public async Task<JsonElement> CreatePost(string title)
        {
            var payload = new
            {
                title
            };
            var httpContent = new StringContent(JsonSerializer.Serialize(payload));
            var response = await httpClient.PostAsync(url, httpContent);
            var body = await response.Content.ReadAsStringAsync();
            var created = JsonSerializer.Deserialize<JsonElement>(body);
            return created;
        }
    }
}
