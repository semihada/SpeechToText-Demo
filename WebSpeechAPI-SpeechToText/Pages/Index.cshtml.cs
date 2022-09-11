using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Net.Mime.MediaTypeNames;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using System.Xml;

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
                await getResponseDemo(textIn, selectLanguage);
            }
        }

        private async Task getResponseDemo(String text, String language)
        {
            // Assign Secrets
            string username = "demoUsername";
            string pw = "demoPassword";

            // Assign Endpoint Addresses
            string baseAdress = "https://dummy.restapiexample.com/api/v1";
            string requestAddress = "/employees";

            // Initialize Request
            var client = new RestClient(baseAdress)
            {
                Authenticator = new HttpBasicAuthenticator(username, pw)
            };
            var request = new RestRequest(requestAddress, Method.Get);

            var response = client.Execute(request);

            // Beautify response
            var parsedJson = JsonConvert.DeserializeObject(response.Content);
            var json = JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);

            // Print beautified response to screen
            ViewData["TextOut"] = json;

        }
    }
}