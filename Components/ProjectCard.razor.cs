using Microsoft.AspNetCore.Components;
using MudBlazor;
using PersonalSite.Models;

namespace PersonalSite.Components;

public partial class ProjectCard
{
    [Parameter] public Project Project { get; set; }

    [Inject] private IDialogService Dialog { get; set; }

    private void OpenModal()
    {
        var parameters = new DialogParameters {["Project"] = Project};
        var options = new DialogOptions {MaxWidth = MaxWidth.Medium, CloseButton = true};
        Dialog.Show<ProjectModal>(Project.Title, parameters, options);
    }
}