using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.WebApiSample.Documents;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReceiptController : BasePdfController
{
    public ReceiptController(ILogger<BasePdfController> logger) : base(logger)
    {
    }

    /// <summary>
    /// Generates a Receipt with sample data
    /// </summary>
    [HttpGet("sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateSample()
    {
        var model = SampleDataGenerator.GetSampleReceipt();
        var document = new ReceiptDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return GeneratePdfFile(pdfBytes, $"receipt-{model.ReceiptNumber}.pdf");
    }

    /// <summary>
    /// Gets sample receipt data as JSON
    /// </summary>
    [HttpGet("sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<ReceiptModel> GetSampleJson()
    {
        return Ok(SampleDataGenerator.GetSampleReceipt());
    }
}