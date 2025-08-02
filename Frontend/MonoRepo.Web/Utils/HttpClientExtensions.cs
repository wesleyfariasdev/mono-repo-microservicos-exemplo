using System.Text;
using System.Text.Json;

namespace MonoRepo.Web.Utils;

public static class HttpClientExtensions
{
    private const string mediaType = "application/json";
    public static async Task<T> GetAsync<T>(this HttpClient client, string requestUri)
    {
        var response = await client.GetAsync(requestUri);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<T>();
    }
    public static async Task<T> PostAsync<T>(this HttpClient client, string requestUri, T value)
    {
        var dataAsString = JsonSerializer.Serialize(value);
        var content = new StringContent(dataAsString, Encoding.UTF8, mediaType);
        var response = await client.PostAsJsonAsync(requestUri, content);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<T>();
    }
    public static async Task<T> PutAsync<T>(this HttpClient client, string requestUri, T value)
    {
        var dataAsString = JsonSerializer.Serialize(value);
        var content = new StringContent(dataAsString, Encoding.UTF8, mediaType);
        var response = await client.PutAsJsonAsync(requestUri, content);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<T>();
    }
    public static async Task DeleteAsync(this HttpClient client, string requestUri)
    {
        var response = await client.DeleteAsync(requestUri);
        response.EnsureSuccessStatusCode();
    }
}
