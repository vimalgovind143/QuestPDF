using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.WebApiSample.Documents;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PdfController : ControllerBase
{
    private readonly ILogger<PdfController> _logger;

    public PdfController(ILogger<PdfController> logger)
    {
        _logger = logger;
    }

    #region Standard Tax Invoice

    /// <summary>
    /// Generates a Standard TAX Invoice with sample data (2 pages)
    /// </summary>
    [HttpGet("tax-invoice/sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateTaxInvoiceSample()
    {
        var model = SampleDataGenerator.GetSampleTaxInvoice();
        var document = new StandardTaxInvoiceDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return File(pdfBytes, "application/pdf", $"tax-invoice-{model.TaxInvoiceNumber}.pdf");
    }

    /// <summary>
    /// Generates a custom TAX Invoice from request body
    /// </summary>
    [HttpPost("tax-invoice")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GenerateTaxInvoice([FromBody] StandardTaxInvoiceModel model)
    {
        if (model == null)
            return BadRequest("Tax invoice model is required");

        try
        {
            var document = new StandardTaxInvoiceDocument(model);
            var pdfBytes = document.GeneratePdf();
            
            return File(pdfBytes, "application/pdf", $"tax-invoice-{model.TaxInvoiceNumber}.pdf");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating TAX invoice PDF");
            return StatusCode(500, $"Error generating PDF: {ex.Message}");
        }
    }

    /// <summary>
    /// Gets sample TAX invoice data as JSON
    /// </summary>
    [HttpGet("tax-invoice/sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<StandardTaxInvoiceModel> GetSampleTaxInvoiceJson()
    {
        return Ok(SampleDataGenerator.GetSampleTaxInvoice());
    }

    #endregion

    #region Receipt

    /// <summary>
    /// Generates a Receipt with sample data
    /// </summary>
    [HttpGet("receipt/sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateReceiptSample()
    {
        var model = SampleDataGenerator.GetSampleReceipt();
        var document = new ReceiptDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return File(pdfBytes, "application/pdf", $"receipt-{model.ReceiptNumber}.pdf");
    }

    /// <summary>
    /// Generates a custom Receipt from request body
    /// </summary>
    [HttpPost("receipt")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GenerateReceipt([FromBody] ReceiptModel model)
    {
        if (model == null)
            return BadRequest("Receipt model is required");

        try
        {
            var document = new ReceiptDocument(model);
            var pdfBytes = document.GeneratePdf();
            
            return File(pdfBytes, "application/pdf", $"receipt-{model.ReceiptNumber}.pdf");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating receipt PDF");
            return StatusCode(500, $"Error generating PDF: {ex.Message}");
        }
    }

    /// <summary>
    /// Gets sample receipt data as JSON
    /// </summary>
    [HttpGet("receipt/sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<ReceiptModel> GetSampleReceiptJson()
    {
        return Ok(SampleDataGenerator.GetSampleReceipt());
    }

    #endregion

    #region Purchase Order

    /// <summary>
    /// Generates a Purchase Order with sample data
    /// </summary>
    [HttpGet("purchase-order/sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GeneratePurchaseOrderSample()
    {
        var model = SampleDataGenerator.GetSamplePurchaseOrder();
        var document = new PurchaseOrderDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return File(pdfBytes, "application/pdf", $"purchase-order-{model.PONumber}.pdf");
    }

    /// <summary>
    /// Generates a custom Purchase Order from request body
    /// </summary>
    [HttpPost("purchase-order")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GeneratePurchaseOrder([FromBody] PurchaseOrderModel model)
    {
        if (model == null)
            return BadRequest("Purchase order model is required");

        try
        {
            var document = new PurchaseOrderDocument(model);
            var pdfBytes = document.GeneratePdf();
            
            return File(pdfBytes, "application/pdf", $"purchase-order-{model.PONumber}.pdf");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating purchase order PDF");
            return StatusCode(500, $"Error generating PDF: {ex.Message}");
        }
    }

    /// <summary>
    /// Gets sample purchase order data as JSON
    /// </summary>
    [HttpGet("purchase-order/sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<PurchaseOrderModel> GetSamplePurchaseOrderJson()
    {
        return Ok(SampleDataGenerator.GetSamplePurchaseOrder());
    }

    #endregion
}
