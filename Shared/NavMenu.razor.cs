using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;

namespace PersonalSite.Shared;

public partial class NavMenu
{
    [Inject] private NavigationManager NavigationManager { get; set; }

    private async Task HandleClick(string elementId)
    {
        NavigationManager.NavigateTo($"{elementId}");
    }
}