using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.WebApiSample.Documents;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PurchaseOrderController : BasePdfController
{
    public PurchaseOrderController(ILogger<BasePdfController> logger) : base(logger)
    {
    }

    /// <summary>
    /// Generates a Purchase Order with sample data
    /// </summary>
    [HttpGet("sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateSample()
    {
        var model = SampleDataGenerator.GetSamplePurchaseOrder();
        var document = new PurchaseOrderDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return GeneratePdfFile(pdfBytes, $"purchase-order-{model.PONumber}.pdf");
    }

    /// <summary>
    /// Gets sample purchase order data as JSON
    /// </summary>
    [HttpGet("sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<PurchaseOrderModel> GetSampleJson()
    {
        return Ok(SampleDataGenerator.GetSamplePurchaseOrder());
    }
}