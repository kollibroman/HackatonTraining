using System.Net.Http.Headers;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using RestaurantClient.Interfaces;
using RestaurantClient.Services;
using Westwind.AspNetCore.LiveReload;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("RestaurantAPI",
    options =>
    {
        options.BaseAddress = new Uri("https://localhost:5000/");
        options.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue(
                "application/json", 1.0));
    });
builder.Services.AddLiveReload(config =>
{
    config.FileInclusionFilter = path =>
    {
        // don't trigger refreshes for files changes in the LocalizationAdmin sub-folder
        if (path.Contains("\\LocalizationAdmin", StringComparison.OrdinalIgnoreCase))
            return FileInclusionModes.DontRefresh;

        // explicitly force a file to refresh without regard to file extension et al. rules
        // are checked before the configuration file filter is applied
        if (path.Contains("/customfile.mm"))
            return FileInclusionModes.ForceRefresh;
            
        // continue regular file extension list filtering
        return FileInclusionModes.ContinueProcessing;
    };
});
builder.Services.AddScoped<IDishService, DishService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 5;
    config.IsDismissable = true;
    config.Position = NotyfPosition.BottomRight;
});
builder.Services.AddMvc().AddRazorRuntimeCompilation();
builder.Services.AddMvc().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseLiveReload();
app.UseNotyf();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
