using Microsoft.AspNetCore.Mvc; // Импортирование пространства имен для работы с MVC (Model-View-Controller)
using Microsoft.AspNetCore.Mvc.RazorPages; // Импортирование пространства имен для работы с Razor Pages

namespace CRUDtest2.Pages
{
    // Модель страницы Index (главная страница)
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger; // Логгер для записи сообщений о событиях на главной странице

        // Конструктор для инициализации логгера
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        // Метод обработки GET-запроса на главную страницу
        public void OnGet()
        {
            // В данном случае метод не выполняет никаких действий, но может быть использован для загрузки данных или записи логов
        }
    }
}
