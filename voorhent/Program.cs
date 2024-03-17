using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages()
                .AddViewLocalization(); // ����������� ������� � ������ �������� ��� ����������� �������������

var app = builder.Build();

// ��������� �������� �� ���������
var supportedCultures = new[]
{
    new CultureInfo("en-US"), // ��������� ����������� �����
    new CultureInfo("ru-RU"), // ��������� �������� �����
    new CultureInfo("kz-KZ") // ��������� ���������� �����
};

var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("ru-RU"), // ������������� ������� ���� ��� �������� �� ���������
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
