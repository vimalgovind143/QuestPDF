using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.WebApiSample.Documents;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenericReportController : BasePdfController
{
    public GenericReportController(ILogger<BasePdfController> logger) : base(logger)
    {
    }

    /// <summary>
    /// Generates a Generic Report with sample data
    /// </summary>
    [HttpGet("sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateSample()
    {
        var model = SampleDataGenerator.GetSampleGenericReport();
        var document = new GenericReportDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return GeneratePdfFile(pdfBytes, "generic-report-sample.pdf");
    }

    /// <summary>
    /// Gets sample generic report data as JSON
    /// </summary>
    [HttpGet("sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<GenericReportModel> GetSampleJson()
    {
        return Ok(SampleDataGenerator.GetSampleGenericReport());
    }
}