using Azure.Monitor.OpenTelemetry.AspNetCore;
using DSDD.DebatniMayhem.Web.Controllers;
using DSDD.DebatniMayhem.Web.DataAccess;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;

QuestPDF.Settings.License = LicenseType.Community;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .Configure<PrintingController.PrintingConfiguration>(opts =>
    {
        opts.Key = builder.Configuration.GetValue<string>("PrintingKey");
    })
    .AddDbContext<MayhemDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("MayhemDatabase"));
    })
    .AddRazorPages();

#if !DEBUG
builder.Services.AddOpenTelemetry().UseAzureMonitor();
#endif

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

app.MapControllers();

app.Run();
