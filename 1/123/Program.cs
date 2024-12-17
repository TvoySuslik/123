using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CRUDtest2.Data;

namespace CRUDtest2
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// Создание объекта Builder для настройки приложения
			var builder = WebApplication.CreateBuilder(args);

			// Добавление DbContext с использованием строки подключения
			builder.Services.AddDbContext<CRUDtest2Context>(options =>
				options.UseSqlServer(
					builder.Configuration.GetConnectionString("CRUDtest2Context")
					?? throw new InvalidOperationException("Connection string 'CRUDtest2Context' not found.")));

			// Добавление поддержки Razor-страниц
			builder.Services.AddRazorPages();

			// Построение приложения
			var app = builder.Build();

			// Настройка обработки ошибок и HTTP Strict Transport Security для production-среды
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error"); // Перенаправление на страницу ошибок
				app.UseHsts(); // Включение HSTS
			}

			// Включение перенаправления с HTTP на HTTPS
			app.UseHttpsRedirection();

			// Подключение статических файлов
			app.UseStaticFiles();

			// Включение маршрутизации
			app.UseRouting();

			// Включение авторизации (можно настроить позже)
			app.UseAuthorization();

			// Настройка маршрутов для Razor-страниц
			app.MapRazorPages();

			// Запуск приложения
			app.Run();
		}
	}
}