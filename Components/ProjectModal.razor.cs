using Microsoft.AspNetCore.Components;
using MudBlazor;
using PersonalSite.Models;

namespace PersonalSite.Components;

public partial class ProjectModal
{
    [Parameter] public Project Project { get; set; } = new();

    [CascadingParameter] private MudDialogInstance MudDialog { get; set; } = new();
}