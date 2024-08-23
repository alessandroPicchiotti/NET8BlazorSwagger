using AppClient;
using AppClient.Class;
using AppClient.Services.Infrastructure;
using AppClient.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;



var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.Configure<MyAppSettings>(builder.Configuration.GetSection("MySettings"));
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//builder.Services.Configure<mySetting>(builder.Configuration.GetSection("Url").Bind);
builder.Services.Configure<mySetting>(builder.Configuration.GetSection("Url"));

builder.Services.AddScoped<IUserService,UserService>();

// Configure the HTTP request pipeline.
var app = builder.Build();

//var configuration = new ConfigurationBuilder()
//    .AddJsonFile("config.json")
//    .Build();



await builder.Build().RunAsync();
