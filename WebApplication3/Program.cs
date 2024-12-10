using Microsoft.AspNetCore.Mvc;
using WebApplication3;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ HttpClient để sử dụng cho API call
builder.Services.AddHttpClient();

// Đăng ký TelegramService với HttpClient và Bot Token của bạn
builder.Services.AddSingleton<TelegramService>(provider =>
    new TelegramService(
        provider.GetRequiredService<HttpClient>(), // Lấy HttpClient từ DI container
        "7911455670:AAFvxGLWcnZfl5j8ZzXhJ7aRvD9T5aDROro" // Thay thế bằng bot token của bạn
    )
);

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Cấu hình middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
