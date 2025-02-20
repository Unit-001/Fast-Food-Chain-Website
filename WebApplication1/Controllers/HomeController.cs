using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using WebApplication1.Models;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // Default action for the home page
    [Route("/")]
    public IActionResult Index()
    {
        // Check if the session has been set to indicate the introduction has been visited
        if (HttpContext.Session.GetString("VisitedIntroduction") == null)
        {
            // Set session variable to indicate the introduction has been visited
            HttpContext.Session.SetString("VisitedIntroduction", "True");

            // Redirect to the Introduction.html page
            return Redirect("Introduction.html");
        }

        // If the introduction page has already been visited, proceed to the homepage
        return View(); // Returns the homepage (Index.cshtml)
    }

    // Action for the Privacy page
    [Route("Home/Privacy")]
    public IActionResult Privacy()
    {
        return View();  // Returns the Privacy view (Privacy.cshtml)
    }

    // Action for the Contact page
    [Route("Home/Contact")]
    public IActionResult Contact()
    {
        return View();  // Returns the Contact view (Contact.cshtml)
    }

    // Error page handler
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
