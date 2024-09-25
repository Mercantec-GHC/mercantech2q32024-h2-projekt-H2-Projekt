using Blazor.Auth;
using Blazor.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using System.Net.Http;
using Blazored.LocalStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddMudServices();
builder.Services.AddHttpClient<AuthService>("api");
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvide>();
builder.Services.AddAuthorizationCore();
builder.Services.AddAuthenticationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddBlazoredLocalStorage();


// Register HttpClient for server-side Blazor
builder.Services.AddHttpClient();  // Registers HttpClient to be available for dependency injection

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
