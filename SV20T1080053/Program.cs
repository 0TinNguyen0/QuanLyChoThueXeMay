using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SV20T1080053;
using SV20T1080053.AppCodes;
using SV20T1080053.BusinessLayers.Services.Implementations;
using SV20T1080053.BusinessLayers.Services.Interfaces;
using SV20T1080053.DataLayers.EFCore;
using SV20T1080053.DataLayers.Repositories.Implementions;
using SV20T1080053.DataLayers.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddDbContext<ApplicationDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString"))
);

builder.Services.AddScoped<ILogger<UserService>, Logger<UserService>>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddScoped<ILogger<MotorcycleService>, Logger<MotorcycleService>>();
builder.Services.AddTransient<IMotorcycleService, MotorcycleService>();
builder.Services.AddTransient<IMotorcycleRepository, MotorcycleRepository>();

builder.Services.AddScoped<ILogger<BrandService>, Logger<BrandService>>();
builder.Services.AddTransient<IBrandService, BrandService>();
builder.Services.AddTransient<IBrandRepository, BrandRepository>();

builder.Services.AddScoped<ILogger<OrderService>, Logger<OrderService>>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
// B? sung c�c service c?n d�ng:

builder.Services.AddHttpContextAccessor();

builder.Services.AddMvc();

builder.Services.AddControllersWithViews()
    .AddMvcOptions(option =>
    {
        option.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true; //Kh�ng s? d?ng th�ng b�o m?c ??nh cho gi� tr? null                    
    });

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.Cookie.Name = "AuthenticationCookie";
    option.LoginPath = "/Account/Login";
    option.AccessDeniedPath = "/Account/AccessDenied";
    option.ExpireTimeSpan = TimeSpan.FromMinutes(60);
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(60);
    option.Cookie.HttpOnly = true;
    option.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();


app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "areaAdmin",
        areaName: "Admin",
        pattern: "admin/{controller=Dashboard}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Kh?i t?o c?u h�nh cho ApplicationContext
ApplicationContext.Configure
(
    httpContextAccessor: app.Services.GetRequiredService<IHttpContextAccessor>(),
    hostEnvironment: app.Services.GetService<IWebHostEnvironment>()
);

app.Run();