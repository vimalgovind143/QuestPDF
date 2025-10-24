using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.WebApiSample.Documents;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeePayslipController : BasePdfController
{
    public EmployeePayslipController(ILogger<BasePdfController> logger) : base(logger)
    {
    }

    /// <summary>
    /// Generates an Employee Payslip with sample data
    /// </summary>
    [HttpGet("sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateSample()
    {
        var model = SampleDataGenerator.GetSampleEmployeePayslip();
        var document = new EmployeePayslipDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return GeneratePdfFile(pdfBytes, $"payslip-{model.PayslipNumber}.pdf");
    }

    /// <summary>
    /// Gets sample employee payslip data as JSON
    /// </summary>
    [HttpGet("sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<EmployeePayslipModel> GetSampleJson()
    {
        return Ok(SampleDataGenerator.GetSampleEmployeePayslip());
    }
}