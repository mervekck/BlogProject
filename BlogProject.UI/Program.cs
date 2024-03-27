using BlogProject.Application.Services.Concretes;
using BlogProject.Application.Services.Interfaces;
using BlogProject.Domain.Entities.Concrete;
using BlogProject.Infrastucture.Contexts;
using BlogProject.UI.Profiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Con")));
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddIdentity<AppUser, AppRole>(x =>
{
	x.SignIn.RequireConfirmedEmail = true; //Kullanýcýlar hesaplarýný etkinleþtirmeden önce e-posta adreslerini doðrulamak zorundadýr.
	x.SignIn.RequireConfirmedPhoneNumber = false; //zorunlu olmadýðýný belirtir.
	x.SignIn.RequireConfirmedAccount = false; //zorunlu olmadýðýný belirtir.

	x.User.RequireUniqueEmail = true; //kullanýcýlarýn benzersiz e-posta adreslerine sahip olmasý gerektiðini belirtir.

	x.Password.RequiredLength = 3; //Þifrenin minimum uzunluðunu belirtir.
	x.Password.RequireUppercase = false; //Büyük harf gereksinimlerini kapatýr.
	x.Password.RequireLowercase = false; //küçük  harf gereksinimlerini kapatýr.
	x.Password.RequireNonAlphanumeric = false; //özel karakter gereksinimlerini kapatýr.
	x.Password.RequiredUniqueChars = 0; //Þifrede benzersiz karakter sayýsýný belirtir.
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<IPostCategoriesService, PostCategoriesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "areas",
	pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
