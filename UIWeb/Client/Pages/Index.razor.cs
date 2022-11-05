using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using UIWeb.Client.Services;
using UIWeb.Client.Shared;
using UIWeb.Shared.SharedModels;

namespace UIWeb.Client.Pages;

public class IndexBase : ComponentBase {
    // https://youtu.be/OclPAk50n6A TODO: VIDEO WITH AUTHORIZATION
    public bool? SuccessfulLogin;
    public UserLogin UserLogin { get; set; } = new();
    [Inject] public AuthorizeService AuthorizeS { get; set; }
    [Inject] public HttpClient Http { get; set; }


    public async Task TryLogin() {
        // TODO: Make real password check
        if (!(string.IsNullOrEmpty(UserLogin.Login) || string.IsNullOrEmpty(UserLogin.Password))) {
            if (await AuthorizeS.Login(UserLogin))
                // TODO: Add security and access managment to page
                MainLayoutBase.IsLoggedIn = true;
            else
                SuccessfulLogin = false;
        }
    }

    protected override async Task<Task> OnInitializedAsync() {
        if (await AuthorizeS.IsLoggedAsync()) AuthorizeS.Navigation.NavigateTo(AuthorizeS.RedirectPage);
        return base.OnInitializedAsync();
    }

    public void Reset() {
        SuccessfulLogin = null;
    }
}