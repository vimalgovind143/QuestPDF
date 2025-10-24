using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;

namespace QuestPDF.WebApiSample.Controllers;

[ApiController]
public class BasePdfController : ControllerBase
{
    protected readonly ILogger<BasePdfController> _logger;

    public BasePdfController(ILogger<BasePdfController> logger)
    {
        _logger = logger;
    }

    protected IActionResult GeneratePdfFile(byte[] pdfBytes, string fileName)
    {
        return File(pdfBytes, "application/pdf", fileName);
    }
}