using Microsoft.AspNetCore.SignalR;
using RevoApp.Hubs;

var builder = WebApplication.CreateBuilder(args);

// MVC ve SignalR hizmetlerini ekliyoruz
builder.Services.AddControllersWithViews(); // MVC Controller'lar için gerekli servis
builder.Services.AddSignalR(); // SignalR'ı projeye ekliyoruz

var app = builder.Build();

// Statik dosyaları (css, js, img) sunmak için gerekli ayar
app.UseStaticFiles();

// Routing ayarlarını yapalım (Sayfa yönlendirme)
app.UseRouting();

// Controller Route ayarları
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Chat}/{action=Login}");  // Ana sayfanın yönlendirilmesi

// SignalR hub'ını burada tanımlıyoruz
app.MapHub<ChatHub>("/chatHub");

// Uygulamayı başlatıyoruz
app.Run();
