namespace PersonalSite.Models;

public class Blog
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public DateTime CreatedDateTime { get; set; }
}