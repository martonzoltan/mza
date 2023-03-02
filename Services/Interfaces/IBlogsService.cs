using PersonalSite.Models;

namespace PersonalSite.Services.Interfaces;

public interface IBlogsService
{
    Task<List<Blog>> GetBlogs();

    Task<Blog> GetBlog(int id);
}