using CentosCrafts.Models;
using CentosCrafts.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CentosCrafts.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public JsonFileProductService ProductService;
    public IEnumerable<Product> Products { get; private set; }

    public IndexModel(ILogger<IndexModel> logger, JsonFileProductService productService)
    {
        _logger = logger;
        ProductService = productService;
    }

    public void OnGet()
    {
        Products = ProductService.GetProducts();
    }
}
