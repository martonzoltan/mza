using System.Net.Http.Json;
using PersonalSite.Models;
using PersonalSite.Services.Interfaces;

namespace PersonalSite.Services;

public class BlogsService : IBlogsService
{
    private readonly HttpClient _http;

    public BlogsService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Blog>> GetBlogs()
    {
        var blogs = await _http.GetFromJsonAsync<List<Blog>>("data/blogs.json");
        return blogs ?? new List<Blog>();
    }
    
    public async Task<Blog> GetBlog(int id)
    {
        var blogs = await _http.GetFromJsonAsync<List<Blog>>("data/blogs.json");
        return blogs?.FirstOrDefault(x => x.Id == id) ?? new Blog();
    }
}