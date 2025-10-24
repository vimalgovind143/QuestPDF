using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.WebApiSample.Documents;
using QuestPDF.WebApiSample.Models;
namespace QuestPDF.WebApiSample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaxInvoiceController : BasePdfController
{
    public TaxInvoiceController(ILogger<BasePdfController> logger) : base(logger)
    {
    }

    /// <summary>
    /// Generates a Standard TAX Invoice with sample data
    /// </summary>
    [HttpGet("sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateSample()
    {
        var model = SampleDataGenerator.GetSampleTaxInvoice();
        var document = new StandardTaxInvoiceDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return GeneratePdfFile(pdfBytes, $"tax-invoice-{model.TaxInvoiceNumber}.pdf");
    }

    /// <summary>
    /// Gets sample TAX invoice data as JSON
    /// </summary>
    [HttpGet("sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<StandardTaxInvoiceModel> GetSampleJson()
    {
        return Ok(SampleDataGenerator.GetSampleTaxInvoice());
    }
}