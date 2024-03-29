using Store;
using Store.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IBookRepository, BookRepository>();
builder.Services.AddSingleton<BookService>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => 
{ 
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    // controller/action/{id}
    // book/index
    // book/index/234
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
