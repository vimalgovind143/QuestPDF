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

    #region Dynamic Column Report

    /// <summary>
    /// Generates a Dynamic Column Report with sample data
    /// </summary>
    [HttpGet("dynamic-column-report/sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateDynamicColumnReportSample()
    {
        var model = SampleDataGenerator.GetSampleDynamicColumnReport();
        var document = new DynamicColumnReportDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return File(pdfBytes, "application/pdf", "dynamic-column-report-sample.pdf");
    }

    /// <summary>
    /// Generates a custom Dynamic Column Report from request body
    /// </summary>
    [HttpPost("dynamic-column-report")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GenerateDynamicColumnReport([FromBody] DynamicColumnReportModel model)
    {
        if (model == null)
            return BadRequest("Dynamic column report model is required");

        try
        {
            var document = new DynamicColumnReportDocument(model);
            var pdfBytes = document.GeneratePdf();
            
            return File(pdfBytes, "application/pdf", "dynamic-column-report.pdf");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating dynamic column report PDF");
            return StatusCode(500, $"Error generating PDF: {ex.Message}");
        }
    }

    /// <summary>
    /// Gets sample dynamic column report data as JSON
    /// </summary>
    [HttpGet("dynamic-column-report/sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<DynamicColumnReportModel> GetSampleDynamicColumnReportJson()
    {
        return Ok(SampleDataGenerator.GetSampleDynamicColumnReport());
    }

    #endregion

    #region Product Catalog (A4 Landscape)

    /// <summary>
    /// Generates a Product Catalog in A4 Landscape format with sample data
    /// </summary>
    [HttpGet("product-catalog/sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateProductCatalogSample()
    {
        var model = SampleDataGenerator.GetSampleProductCatalog();
        var document = new ProductCatalogDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return File(pdfBytes, "application/pdf", "product-catalog-sample.pdf");
    }

    /// <summary>
    /// Generates a custom Product Catalog from request body
    /// </summary>
    [HttpPost("product-catalog")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GenerateProductCatalog([FromBody] ProductCatalogModel model)
    {
        if (model == null)
            return BadRequest("Product catalog model is required");

        try
        {
            var document = new ProductCatalogDocument(model);
            var pdfBytes = document.GeneratePdf();
            
            return File(pdfBytes, "application/pdf", "product-catalog.pdf");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating product catalog PDF");
            return StatusCode(500, $"Error generating PDF: {ex.Message}");
        }
    }

    /// <summary>
    /// Gets sample product catalog data as JSON
    /// </summary>
    [HttpGet("product-catalog/sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<ProductCatalogModel> GetSampleProductCatalogJson()
    {
        return Ok(SampleDataGenerator.GetSampleProductCatalog());
    }

    #endregion

    #region Employee Report (A4 Portrait)

    /// <summary>
    /// Generates an Employee Report in A4 Portrait format with sample data
    /// </summary>
    [HttpGet("employee-report/sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateEmployeeReportSample()
    {
        var model = SampleDataGenerator.GetSampleEmployeeReport();
        var document = new EmployeeReportDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return File(pdfBytes, "application/pdf", "employee-report-sample.pdf");
    }

    /// <summary>
    /// Generates a custom Employee Report from request body
    /// </summary>
    [HttpPost("employee-report")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GenerateEmployeeReport([FromBody] EmployeeReportModel model)
    {
        if (model == null)
            return BadRequest("Employee report model is required");

        try
        {
            var document = new EmployeeReportDocument(model);
            var pdfBytes = document.GeneratePdf();
            
            return File(pdfBytes, "application/pdf", "employee-report.pdf");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating employee report PDF");
            return StatusCode(500, $"Error generating PDF: {ex.Message}");
        }
    }

    /// <summary>
    /// Gets sample employee report data as JSON
    /// </summary>
    [HttpGet("employee-report/sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<EmployeeReportModel> GetSampleEmployeeReportJson()
    {
        return Ok(SampleDataGenerator.GetSampleEmployeeReport());
    }

    #endregion
}
