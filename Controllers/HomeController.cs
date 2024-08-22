using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyCoins.Models;

namespace MyCoins.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public CoinsData coinsList { get; set; }
    
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;      
        this.coinsList = new CoinsData();      
    }
        

    public IActionResult Index()
    {      
        return View(this.coinsList.Coins);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [Route("Save")]
    [HttpPost]
    public IActionResult Save(Coin element)
    {
        this.coinsList.AddCoin(element);
        return View("Index", this.coinsList.Coins);
    }

    [Route("addCoin")]
    public IActionResult AddCoin()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
