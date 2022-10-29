using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components;

namespace PawnshopWebApp.Pages;

public class IndexBase : ComponentBase {
    public string Login = "";
    public string Password = "";

    public bool? SuccessfulLogin = null;

    public void TryLogin() {
        if (!String.IsNullOrEmpty(Login) || !String.IsNullOrEmpty(Password)) {
            if (Login == "login" && Password == "password") {
                SuccessfulLogin = true;
            }
            else {
                SuccessfulLogin = false;
            }
        }
    }
}