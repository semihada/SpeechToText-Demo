using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Net.Mime.MediaTypeNames;

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
        public async Task OnPostSubmitTextAsync(String textIn, String selectLanguage)
        {
            // Incoming data are stored in ViewData
            ViewData["TextIn"] = textIn;
            ViewData["language"] = selectLanguage;

            if ((textIn != null) && (selectLanguage != "select-SL"))
            {
                // Function that gets response and
                // changes ViewData["textOut"]
            }
        }
    }
}