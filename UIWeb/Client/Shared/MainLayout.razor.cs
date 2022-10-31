using Microsoft.AspNetCore.Components;
using UIWeb.Client.Services;

namespace UIWeb.Client.Shared;

public class MainLayoutBase : LayoutComponentBase {
    public static bool IsLoggedIn { get; set; }

    [Inject] public AuthorizeService AuthorizeS { get; set; }

    protected override async Task<Task> OnParametersSetAsync() {
        IsLoggedIn = await AuthorizeS.IsLoggedAsync();
        return base.OnParametersSetAsync();
    }

    public void Logout() {
        AuthorizeS.Logout();
        IsLoggedIn = false;
        AuthorizeS.Navigation.NavigateTo(AuthorizeS.BasePage);
    }
}