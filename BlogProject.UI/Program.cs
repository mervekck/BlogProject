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
	x.SignIn.RequireConfirmedEmail = true; //Kullan�c�lar hesaplar�n� etkinle�tirmeden �nce e-posta adreslerini do�rulamak zorundad�r.
	x.SignIn.RequireConfirmedPhoneNumber = false; //zorunlu olmad���n� belirtir.
	x.SignIn.RequireConfirmedAccount = false; //zorunlu olmad���n� belirtir.

	x.User.RequireUniqueEmail = true; //kullan�c�lar�n benzersiz e-posta adreslerine sahip olmas� gerekti�ini belirtir.

	x.Password.RequiredLength = 3; //�ifrenin minimum uzunlu�unu belirtir.
	x.Password.RequireUppercase = false; //B�y�k harf gereksinimlerini kapat�r.
	x.Password.RequireLowercase = false; //k���k  harf gereksinimlerini kapat�r.
	x.Password.RequireNonAlphanumeric = false; //�zel karakter gereksinimlerini kapat�r.
	x.Password.RequiredUniqueChars = 0; //�ifrede benzersiz karakter say�s�n� belirtir.
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
