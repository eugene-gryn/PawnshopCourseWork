using Microsoft.AspNetCore.Components;
using UIWeb.Client.Services;

namespace UIWeb.Client.Pages;

public class PawnshopBaseComponent : ComponentBase
{
    [Inject] public AuthorizeService AuthorizeS { get; set; }
    [Inject] public HttpClient Http { get; set; }
    [Inject] public EntitiesService Server { get; set; }


    protected override async Task<Task> OnInitializedAsync()
    {
        if (!await AuthorizeS.IsLoggedAsync()) AuthorizeS.Navigation.NavigateTo("/");

        return base.OnInitializedAsync();
    }
}