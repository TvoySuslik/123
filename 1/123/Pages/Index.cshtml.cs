using Microsoft.AspNetCore.Mvc; // �������������� ������������ ���� ��� ������ � MVC (Model-View-Controller)
using Microsoft.AspNetCore.Mvc.RazorPages; // �������������� ������������ ���� ��� ������ � Razor Pages

namespace CRUDtest2.Pages
{
    // ������ �������� Index (������� ��������)
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger; // ������ ��� ������ ��������� � �������� �� ������� ��������

        // ����������� ��� ������������� �������
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        // ����� ��������� GET-������� �� ������� ��������
        public void OnGet()
        {
            // � ������ ������ ����� �� ��������� ������� ��������, �� ����� ���� ����������� ��� �������� ������ ��� ������ �����
        }
    }
}
