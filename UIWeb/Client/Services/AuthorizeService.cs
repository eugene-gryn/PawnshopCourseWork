using System.Net.Http.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using UIWeb.Shared.SharedModels;

namespace UIWeb.Client.Services;

// TODO valid authorization
public class AuthorizeService {
    private const string Token = "login";

    public readonly string BasePage = "/";

    public readonly string RedirectPage = "/pawnshop";


    public AuthorizeService(ILocalStorageService storage, NavigationManager navigation, HttpClient http) {
        Storage = storage;
        Navigation = navigation;
        Http = http;
    }

    public ILocalStorageService Storage { get; set; }
    public NavigationManager Navigation { get; set; }
    public HttpClient Http { get; }

    public async Task<bool> IsLoggedAsync() {
        var token = await Storage.GetItemAsStringAsync(Token);

        if (token == null || String.IsNullOrEmpty(token)) return false;

        return await Http.GetFromJsonAsync<bool>($"/authorize/validateToken?token={token}");
    }


    public async Task<bool> Login(UserLogin user) {

        try {
            var result = await Http.PostAsJsonAsync($"authorize/login", user);

            var token = await result.Content.ReadAsStringAsync();

            if (String.IsNullOrEmpty(token)) return false;

            await Storage.SetItemAsStringAsync(Token, token);

            Navigation.NavigateTo(RedirectPage);

            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e);
            return false;
        }
    }

    public void Logout() {
        Storage.SetItemAsStringAsync(Token, "");
    }
}