namespace LinkShortener.WebUI.Controllers;

public class UrlsManagementController(IServiceProvider serviceProvider) : Controller
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public async Task<IActionResult> IncrementCounter(int shortUrlId)
    {
        var url = await _serviceProvider.GetRequiredService<IShortUrlService>().IncrementCounterAsync(shortUrlId);
        if (ModelState.IsValid)
        {
            return Redirect(url);
        }

        return Redirect(url);
    }

    public IActionResult Insert()
    {
        var initShortUrlModel = new ShortUrlModel(string.Empty);

        return View(initShortUrlModel);
    }

    [HttpPost]
    public async Task<IActionResult> Insert(ShortUrlModel shortUrlModel)
    {
        await _serviceProvider.GetRequiredService<IShortUrlService>().InsertNewUrlAsync(shortUrlModel.Url!);
        if (ModelState.IsValid)
        {
            return View(shortUrlModel);
        }

        return RedirectToRoute(new { controller = "Home", action = "Index" });
    }

    public async Task<IActionResult> Edit(int shortUrlId)
    {
        var shortUrl = await _serviceProvider.GetRequiredService<IShortUrlService>().GetByIdAsync(shortUrlId);
        var editShortUrlModel = new ShortUrlModel(shortUrl!.Url!);
        if (ModelState.IsValid)
        {
            return View(editShortUrlModel);
        }

        return View(editShortUrlModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int shortUrlId, ShortUrlModel shortUrlModel)
    {
        if (!ModelState.IsValid)
        {
            await _serviceProvider.GetRequiredService<IShortUrlService>().UpdateOnlyUrlAsync(shortUrlId, shortUrlModel.Url!);
        }

        return RedirectToRoute(new { controller = "Home", action = "Index" });
    }

    [HttpPost]
    public async Task<ActionResult> Delete(int shortUrlId)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        await _serviceProvider.GetRequiredService<IShortUrlService>().DeleteAsync(shortUrlId);

        return RedirectToRoute(new { controller = "Home", action = "Index" });
    }
}