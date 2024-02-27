using Microsoft.AspNetCore.Mvc;
using Resume01.Models;
using System.Diagnostics;

namespace Resume01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Resume()
        {
            return View();
        }

        public IActionResult Resume2()
        {
            return View();
        }

		public IActionResult Resume3()
		{
			return View();
		}

        public IActionResult Resume4()
        {
            return View();
        }

        public IActionResult Resume5()
        {
            return View();
        }

        public IActionResult TestLogic()
        {
            return View();
        }

		public IActionResult Resume6()
		{
			return View();
		}

        public IActionResult Resume6_5()
        {
            return View();
        }

        public IActionResult Resume7()
        {
            return View();
        }
        
        public IActionResult Resume8()
        {
            return View();
        }
        
        public IActionResult Shipment_Monitor()
        {
            return View();
        }

        public IActionResult Register_Info()
        {
            return View();
        }

        public IActionResult Testgap()
        {
            return View();
        }

        public IActionResult Qr_Scan()
        {
            return View();
        }
        public IActionResult KrirkDemoDataTable()
        {
            return View();
        }

        public IActionResult Register_Info_Table()
        {
            return View();
        }
        public IActionResult tryFixError_herrr()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
