using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace PersonalSite.Shared;

public partial class NavMenu
{
    [Inject] private IJSRuntime Js { get; set; }

    private async Task ScrollToPage(string elementId)
    {
        await Js.InvokeVoidAsync("scrollToElement", elementId);
    }
}