using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Whiskies.Models;
using Whiskies.Services;

namespace Whiskies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGraphQlService _graphQl;

        public HomeController(ILogger<HomeController> logger, IGraphQlService gqlService)
        {
            _logger = logger;
            _graphQl = gqlService;
        }

        public async Task<IActionResult> Index()
        {
            var collection = await _graphQl.GetCollection();
            return View(collection);
        }

        public async Task<IActionResult> Whisky(string id)
        {
            var whisky = await _graphQl.GetItem(id);
            return View(whisky);
        }

        public async Task<IActionResult> Download()
        {
            // that method id overkill, ideally
            var collection = await _graphQl.GetCollection();

            if (collection.Archive.Results.Any())
            {
                var url = collection.Archive.Results[0].FileUrl;
                var name = collection.Archive.Results[0].Name;
                name = Path.GetFileNameWithoutExtension(name);

                var binaryData = await Download(url);
                if (binaryData != null)
                {
                    // Set the correct MIME type for a zip file
                    Response.Headers.Add("Content-Disposition", $"attachment; filename={name}");
                    Response.ContentType = "application/zip";

                    // Return the binary data as a FileContentResult
                    return File(binaryData, "application/zip");
                }
            }

            return StatusCode(404);
        }
        private async Task<byte[]> Download(string url)
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            // Get the binary data from the response
            return await response.Content.ReadAsByteArrayAsync();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}