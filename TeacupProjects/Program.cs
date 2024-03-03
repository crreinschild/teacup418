using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;
using TeacupProjects.Battleship.Signal;
using TeacupProjects.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
    //.AddInteractiveWebAssemblyComponents();
builder.Services.AddSignalR();
builder.Services.AddScoped<IBattleshipClient, BattleshipClient>();
builder.Services
    .AddAntiforgery()
    .AddDataProtection()
    .SetApplicationName("TeacupProjects")
    .PersistKeysToFileSystem(
        new DirectoryInfo(@"/var/TeacupProjects/dp/"));

var app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapHub<BattleshipHub>(BattleshipHub.Path);

app.Run();