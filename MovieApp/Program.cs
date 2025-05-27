var builder = WebApplication.CreateBuilder(args);

// 🚀 Controllers ve Session hizmetleri ekleniyor
builder.Services.AddControllersWithViews();

// 🚀 Session süresi 1 saat olarak ayarlandı
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(1); // 1 saat boyunca aktif kalır
    options.Cookie.HttpOnly = true;  // Güvenlik için sadece HTTP üzerinden erişilebilir
    options.Cookie.IsEssential = true; // Çerezlerin gerekli olduğu belirtildi
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // 🚨 Sunucu hatalarını (500) yakalar ve `/Error/500` sayfasına yönlendirir
    app.UseExceptionHandler("/Error/500");

    // 🌍 HSTS (HTTPS Güvenliği) etkin
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// 🚀 Cookie kullanımını etkinleştiriyoruz
app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict
});

app.UseAuthorization();
app.UseSession(); // ✅ Session Middleware'i buraya eklenmeli

// 🚀 **Hata sayfalarına yönlendirme ekliyoruz** `/Error/{code}` formatında çalışacak
app.UseStatusCodePagesWithRedirects("/Error/{0}");

// 🌍 Varsayılan route ayarı
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
