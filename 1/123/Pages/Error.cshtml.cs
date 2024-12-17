using System.Diagnostics; // �������������� ������������ ���� ��� ������ � ������������ (��������, ��������� �������������� �������)
using Microsoft.AspNetCore.Mvc; // �������������� ������������ ���� ��� ������ � MVC (Model-View-Controller)
using Microsoft.AspNetCore.Mvc.RazorPages; // �������������� ������������ ���� ��� ������ � Razor Pages

namespace CRUDtest2.Pages
{
    // ������� ��� ��������� ����������� ������. ���������, ��� ����������� �� ������������ � ������ �� �����������.
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // ������� ��� ������������� �������� �� �������� �������� (�����������������) �� ���� ��������.
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        // �������� ��� �������� �������������� �������
        public string? RequestId { get; set; }

        // ��������, ������� ���������, ����� �� ������������� �������
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger; // ������ ��� ������ ��������� �� �������

        // ����������� ������, ����������� ������ ��� �����������
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        // ����� ��������� GET-�������. ���������� ������������� �������.
        public void OnGet()
        {
            // ��������� �������������� �������� �������, ���� �� ����������, ��� ������������� �������������� ����������� HTTP ���������
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
