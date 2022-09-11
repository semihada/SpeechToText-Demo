using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebSpeechAPI_SpeechToText.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        // On Refresh - On First Page Open
        public void OnGet()
        {

        }
        // On Submission of Form submitText
        public void OnPostSubmitTextAsync(String textIn, String selectLanguage)
        {

        }
    }
}