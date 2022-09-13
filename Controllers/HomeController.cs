using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebChatForEveryone.Models;



namespace WebChatForEveryone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration Configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }
        
        public IActionResult Index()
        {
            ViewData["GoogleAuth"] = Configuration["UseGoogleAuth"];
            ViewData["GoogleClientID"] = Configuration["GoogleClientID"];
            return View();
        }

        [HttpGet]
        public async Task<string> GetAllText(string datetime)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(Configuration["APIUrl"] +"GetSharedText?dateTime=" + datetime))
                
                
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return apiResponse;
                }
            }
        }

        [HttpPost]
        public  ActionResult SendText(string submitText, string username)
        {
            TransferedText model = new TransferedText();
            using (var httpClient = new HttpClient())
            {
                HttpRequestMessage m = new HttpRequestMessage();
                m.RequestUri = new Uri( Configuration["APIUrl"] + "SaveTextFromUser?txt=" + submitText + "&userid=" + username);
                using (var response =  httpClient.Send(m))
                {
                    
                }
            }

            return new EmptyResult();

        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}