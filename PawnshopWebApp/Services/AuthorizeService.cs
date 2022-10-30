using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using PawnshopWebApp.Models;

namespace PawnshopWebApp.Services;

// TODO valid authorization
public class AuthorizeService {
    private const string Token = "login";

    public readonly string RedirectPage = "/pawnshop";
    public readonly string BasePage = "/";

    public AuthorizeService(ILocalStorageService storage, NavigationManager navigation) {
        Storage = storage;
        Navigation = navigation;
    }

    public ILocalStorageService Storage { get; set; }
    public NavigationManager Navigation { get; set; }

    public async Task<bool> IsLoggedAsync() {
        return await Storage.GetItemAsStringAsync(Token) == "login";
    }


    public bool Login(User user) {
        if (!(user.Login == "login" && user.Password == "possword1111")) return false;

        Storage.SetItemAsStringAsync("login", user.Login);

        Navigation.NavigateTo(RedirectPage);

        return true;
    }

    public void Logout() {
        Storage.SetItemAsStringAsync(Token, "");
    }
}