using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages()
                .AddViewLocalization(); // Регистрация доступа к файлам ресурсов для локализации представлений

var app = builder.Build();

// Установка культуры по умолчанию
var supportedCultures = new[]
{
    new CultureInfo("en-US"), // Поддержка английского языка
    new CultureInfo("ru-RU"), // Поддержка русского языка
    new CultureInfo("kz-KZ") // Поддержка казахского языка
};

var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("ru-RU"), // Устанавливаем русский язык как культуру по умолчанию
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
};

app.UseRequestLocalization(localizationOptions);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

// Run the application.
app.Run();
