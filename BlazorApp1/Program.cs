using BlazorApp1.SeriLog;
using BlazorDownloadFile;
using Majorsoft.Blazor.Components.CssEvents;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();
Log.Logger = new LoggerConfiguration().WriteTo.File(new MyOwnCompactJsonFormatter(), "Stp-Controller_Log.txt").CreateLogger();
builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<BlazorApp1.Database.SettingSenderMan.SettingSenderManContext>();
builder.Services.AddSingleton<BlazorApp1.DataContext.Permissions.PermissionsContext>();
builder.Services.AddSingleton<BlazorApp1.DataContext.Traceability.TraceabilityContext>();
builder.Services.AddSingleton<BlazorApp1.DataBase.PackDataBase.UpackageContext>();
builder.Services.AddSingleton<BlazorApp1.DataBase.NewMesContext.NewMes>();
builder.Services.AddBlazorDownloadFile();

builder.Services.AddCssEvents();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();
//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


app.Run();


