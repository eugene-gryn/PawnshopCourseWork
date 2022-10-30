using System.Runtime.InteropServices;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using PawnshopWebApp.Models;
using PawnshopWebApp.Shared;
using PawnshopWebApp.Services;

namespace PawnshopWebApp.Pages;

public class IndexBase : ComponentBase {

    // https://youtu.be/OclPAk50n6A TODO: VIDEO WITH AUTHORIZATION
    public bool? SuccessfulLogin;
    public User UserLogin { get; set; } = new();
    [Inject] public AuthorizeService AuthorizeS { get; set; }


    public void TryLogin() {
        // TODO: Make real password check
        if (!(string.IsNullOrEmpty(UserLogin.Login) || string.IsNullOrEmpty(UserLogin.Password))) {
            if (AuthorizeS.Login(UserLogin))
                // TODO: Add security and access managment to page
                MainLayoutBase.IsLoggedIn = true;
            else
                SuccessfulLogin = false;
        }
    }

    protected override async Task<Task> OnInitializedAsync() {
        if (await AuthorizeS.IsLoggedAsync())
        {
            AuthorizeS.Navigation.NavigateTo(AuthorizeS.RedirectPage);
        }
        return base.OnInitializedAsync();
    }

    public void Reset() {
        SuccessfulLogin = null;
    }
}