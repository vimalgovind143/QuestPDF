using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.WebApiSample.Documents;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BudgetAnalysisController : BasePdfController
{
    public BudgetAnalysisController(ILogger<BasePdfController> logger) : base(logger)
    {
    }

    /// <summary>
    /// Generates a Budget Analysis Report with sample data
    /// </summary>
    [HttpGet("sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateSample()
    {
        var model = SampleDataGenerator.GetSampleBudgetAnalysisReport();
        var document = new DynamicColumnReportDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return GeneratePdfFile(pdfBytes, "budget-analysis-sample.pdf");
    }

    /// <summary>
    /// Gets sample budget analysis report data as JSON
    /// </summary>
    [HttpGet("sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<DynamicColumnReportModel> GetSampleJson()
    {
        return Ok(SampleDataGenerator.GetSampleBudgetAnalysisReport());
    }
}