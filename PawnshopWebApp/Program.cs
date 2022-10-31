using Blazored.LocalStorage;
using DataAccessLayer.Context;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using PawnshopWebApp;
using PawnshopWebApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


builder.Services.AddBlazoredLocalStorage();


builder.Services.AddScoped<AuthorizeService>();

builder.Services.AddDbContextFactory<PawnshopDbContext>(opt => {
    opt.UseSqlServer("Data Source=DESKTOP-UQPFITT;Initial Catalog=PawnshopDB;Integrated Security=True",
        optBuild => optBuild.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
});

await builder.Build().RunAsync();
