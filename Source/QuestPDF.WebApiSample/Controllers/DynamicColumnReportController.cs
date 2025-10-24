using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.WebApiSample.Documents;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DynamicColumnReportController : BasePdfController
{
    public DynamicColumnReportController(ILogger<BasePdfController> logger) : base(logger)
    {
    }

    /// <summary>
    /// Generates a Dynamic Column Report with sample data
    /// </summary>
    [HttpGet("sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateSample()
    {
        var model = SampleDataGenerator.GetSampleDynamicColumnReport();
        var document = new DynamicColumnReportDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return GeneratePdfFile(pdfBytes, "dynamic-column-report-sample.pdf");
    }

    /// <summary>
    /// Gets sample dynamic column report data as JSON
    /// </summary>
    [HttpGet("sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<DynamicColumnReportModel> GetSampleJson()
    {
        return Ok(SampleDataGenerator.GetSampleDynamicColumnReport());
    }
}