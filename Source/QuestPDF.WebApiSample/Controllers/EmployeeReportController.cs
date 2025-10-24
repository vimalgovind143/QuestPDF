using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.WebApiSample.Documents;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeReportController : BasePdfController
{
    public EmployeeReportController(ILogger<BasePdfController> logger) : base(logger)
    {
    }

    /// <summary>
    /// Generates an Employee Report with sample data
    /// </summary>
    [HttpGet("sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateSample()
    {
        var model = SampleDataGenerator.GetSampleEmployeeReport();
        var document = new EmployeeReportDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return GeneratePdfFile(pdfBytes, "employee-report-sample.pdf");
    }

    /// <summary>
    /// Gets sample employee report data as JSON
    /// </summary>
    [HttpGet("sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<EmployeeReportModel> GetSampleJson()
    {
        return Ok(SampleDataGenerator.GetSampleEmployeeReport());
    }
}