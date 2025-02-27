using Azure.Monitor.OpenTelemetry.AspNetCore;
using DSDD.DebatniMayhem.Web.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddDbContext<MayhemDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("MayhemDatabase"));
    })
    .AddRazorPages();

builder.Services.AddOpenTelemetry().UseAzureMonitor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();
