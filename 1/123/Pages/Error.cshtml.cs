using System.Diagnostics; // Импортирование пространства имен для работы с диагностикой (например, получение идентификатора запроса)
using Microsoft.AspNetCore.Mvc; // Импортирование пространства имен для работы с MVC (Model-View-Controller)
using Microsoft.AspNetCore.Mvc.RazorPages; // Импортирование пространства имен для работы с Razor Pages

namespace CRUDtest2.Pages
{
    // Атрибут для настройки кэширования ответа. Указывает, что кэширование не используется и запрос не сохраняется.
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // Атрибут для игнорирования проверки на подделку запросов (антифальсификация) на этой странице.
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        // Свойство для хранения идентификатора запроса
        public string? RequestId { get; set; }

        // Свойство, которое проверяет, задан ли идентификатор запроса
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger; // Логгер для записи сообщений об ошибках

        // Конструктор класса, принимающий логгер как зависимость
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        // Метод обработки GET-запроса. Записывает идентификатор запроса.
        public void OnGet()
        {
            // Получение идентификатора текущего запроса, если он существует, или использование идентификатора трассировки HTTP контекста
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
