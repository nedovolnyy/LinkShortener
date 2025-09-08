namespace LinkShortener.WebUI.Controllers;

public class HomeController(IServiceProvider serviceProvider) : Controller
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public async Task<IActionResult> Index()
    {
        return View(await _serviceProvider.GetRequiredService<IShortUrlService>().GetAllAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ShortUrl shortUrl)
    {
        if (ModelState.IsValid)
        {
            return View();
        }

        await _serviceProvider.GetRequiredService<IShortUrlService>().InsertAsync(shortUrl);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
