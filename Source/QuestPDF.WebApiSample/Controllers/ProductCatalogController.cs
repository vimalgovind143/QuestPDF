using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.WebApiSample.Documents;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductCatalogController : BasePdfController
{
    public ProductCatalogController(ILogger<BasePdfController> logger) : base(logger)
    {
    }

    /// <summary>
    /// Generates a Product Catalog with sample data
    /// </summary>
    [HttpGet("sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateSample()
    {
        var model = SampleDataGenerator.GetSampleProductCatalog();
        var document = new ProductCatalogDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return GeneratePdfFile(pdfBytes, "product-catalog-sample.pdf");
    }

    /// <summary>
    /// Gets sample product catalog data as JSON
    /// </summary>
    [HttpGet("sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<ProductCatalogModel> GetSampleJson()
    {
        return Ok(SampleDataGenerator.GetSampleProductCatalog());
    }
}