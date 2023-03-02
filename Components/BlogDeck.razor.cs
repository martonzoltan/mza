using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using PersonalSite.Models;
using PersonalSite.Services.Interfaces;

namespace PersonalSite.Components;

public partial class BlogDeck
{
    private List<Blog> _blogs = new();
    [Inject] private IBlogsService BlogsService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _blogs = await BlogsService.GetBlogs();
        await base.OnInitializedAsync();
    }
}