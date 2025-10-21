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

    #region Generic Report

    /// <summary>
    /// Generates a Generic Report with sample data
    /// </summary>
    [HttpGet("generic-report/sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateGenericReportSample()
    {
        var model = SampleDataGenerator.GetSampleGenericReport();
        var document = new GenericReportDocument(model);

        var pdfBytes = document.GeneratePdf();

        return File(pdfBytes, "application/pdf", "generic-report-sample.pdf");
    }

    /// <summary>
    /// Generates a custom Generic Report from request body
    /// </summary>
    [HttpPost("generic-report")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GenerateGenericReport([FromBody] GenericReportModel model)
    {
        if (model == null)
            return BadRequest("Generic report model is required");

        if (string.IsNullOrEmpty(model.ReportName))
            return BadRequest("Report name is required");

        if (model.ColumnNames == null || !model.ColumnNames.Any())
            return BadRequest("Column names are required");

        if (model.Data == null || !model.Data.Any())
            return BadRequest("Data rows are required");

        try
        {
            var document = new GenericReportDocument(model);
            var pdfBytes = document.GeneratePdf();

            return File(pdfBytes, "application/pdf", $"{model.ReportName.Replace(" ", "-").ToLower()}-report.pdf");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating generic report PDF");
            return StatusCode(500, $"Error generating PDF: {ex.Message}");
        }
    }

    /// <summary>
    /// Gets sample generic report data as JSON
    /// </summary>
    [HttpGet("generic-report/sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<GenericReportModel> GetSampleGenericReportJson()
    {
        return Ok(SampleDataGenerator.GetSampleGenericReport());
    }

    /// <summary>
    /// Generates a Generic Report with Arabic sample data (RTL support)
    /// </summary>
    [HttpGet("generic-report/sample/arabic")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateGenericReportArabicSample()
    {
        var model = SampleDataGenerator.GetSampleGenericReportArabic();
        var document = new GenericReportDocument(model);
        var pdfBytes = document.GeneratePdf();

        return File(pdfBytes, "application/pdf", "generic-report-arabic-sample.pdf");
    }

    /// <summary>
    /// Gets sample Arabic generic report data as JSON
    /// </summary>
    [HttpGet("generic-report/sample/arabic/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<GenericReportModel> GetSampleGenericReportArabicJson()
    {
        return Ok(SampleDataGenerator.GetSampleGenericReportArabic());
    }

    #endregion

    #region Attendance Report (Dynamic Columns)

    /// <summary>
    /// Generates an Employee Attendance Report with dynamic date columns
    /// </summary>
    [HttpGet("attendance-report/sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateAttendanceReportSample()
    {
        var model = SampleDataGenerator.GetSampleAttendanceReport();
        var document = new DynamicColumnReportDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return File(pdfBytes, "application/pdf", "attendance-report-sample.pdf");
    }

    /// <summary>
    /// Generates a custom Attendance Report from request body
    /// </summary>
    [HttpPost("attendance-report")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GenerateAttendanceReport([FromBody] DynamicColumnReportModel model)
    {
        if (model == null)
            return BadRequest("Attendance report model is required");

        try
        {
            var document = new DynamicColumnReportDocument(model);
            var pdfBytes = document.GeneratePdf();
            
            return File(pdfBytes, "application/pdf", "attendance-report.pdf");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating attendance report PDF");
            return StatusCode(500, $"Error generating PDF: {ex.Message}");
        }
    }

    /// <summary>
    /// Gets sample attendance report data as JSON
    /// </summary>
    [HttpGet("attendance-report/sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<DynamicColumnReportModel> GetSampleAttendanceReportJson()
    {
        return Ok(SampleDataGenerator.GetSampleAttendanceReport());
    }

    #endregion

    #region Assets Report (Dynamic Columns)

    /// <summary>
    /// Generates an IT Assets Report with dynamic location/status columns
    /// </summary>
    [HttpGet("assets-report/sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateAssetsReportSample()
    {
        var model = SampleDataGenerator.GetSampleAssetsReport();
        var document = new DynamicColumnReportDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return File(pdfBytes, "application/pdf", "assets-report-sample.pdf");
    }

    /// <summary>
    /// Generates a custom Assets Report from request body
    /// </summary>
    [HttpPost("assets-report")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GenerateAssetsReport([FromBody] DynamicColumnReportModel model)
    {
        if (model == null)
            return BadRequest("Assets report model is required");

        try
        {
            var document = new DynamicColumnReportDocument(model);
            var pdfBytes = document.GeneratePdf();
            
            return File(pdfBytes, "application/pdf", "assets-report.pdf");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating assets report PDF");
            return StatusCode(500, $"Error generating PDF: {ex.Message}");
        }
    }

    /// <summary>
    /// Gets sample assets report data as JSON
    /// </summary>
    [HttpGet("assets-report/sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<DynamicColumnReportModel> GetSampleAssetsReportJson()
    {
        return Ok(SampleDataGenerator.GetSampleAssetsReport());
    }

    #endregion

    #region Budget Analysis Report (Dynamic Columns)

    /// <summary>
    /// Generates a Budget vs Actual Analysis Report with dynamic month columns
    /// </summary>
    [HttpGet("budget-analysis/sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateBudgetAnalysisReportSample()
    {
        var model = SampleDataGenerator.GetSampleBudgetAnalysisReport();
        var document = new DynamicColumnReportDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return File(pdfBytes, "application/pdf", "budget-analysis-sample.pdf");
    }

    /// <summary>
    /// Generates a custom Budget Analysis Report from request body
    /// </summary>
    [HttpPost("budget-analysis")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GenerateBudgetAnalysisReport([FromBody] DynamicColumnReportModel model)
    {
        if (model == null)
            return BadRequest("Budget analysis report model is required");

        try
        {
            var document = new DynamicColumnReportDocument(model);
            var pdfBytes = document.GeneratePdf();
            
            return File(pdfBytes, "application/pdf", "budget-analysis.pdf");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating budget analysis report PDF");
            return StatusCode(500, $"Error generating PDF: {ex.Message}");
        }
    }

    /// <summary>
    /// Gets sample budget analysis report data as JSON
    /// </summary>
    [HttpGet("budget-analysis/sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<DynamicColumnReportModel> GetSampleBudgetAnalysisReportJson()
    {
        return Ok(SampleDataGenerator.GetSampleBudgetAnalysisReport());
    }

    #endregion

    #region Employee Payslip

    /// <summary>
    /// Generates an Employee Payslip with sample data and QR code
    /// </summary>
    [HttpGet("employee-payslip/sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateEmployeePayslipSample()
    {
        var model = SampleDataGenerator.GetSampleEmployeePayslip();
        var document = new EmployeePayslipDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return File(pdfBytes, "application/pdf", $"payslip-{model.PayslipNumber}.pdf");
    }

    /// <summary>
    /// Generates an Employee Payslip with password protection (password: secure123)
    /// </summary>
    [HttpGet("employee-payslip/sample/protected")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateEmployeePayslipSampleProtected()
    {
        var model = SampleDataGenerator.GetSampleEmployeePayslipWithPassword();
        var document = new EmployeePayslipDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        // Apply password protection if password is provided
        if (!string.IsNullOrEmpty(model.Password))
        {
            var tempInputFile = Path.GetTempFileName();
            var tempOutputFile = Path.GetTempFileName();
            
            try
            {
                System.IO.File.WriteAllBytes(tempInputFile, pdfBytes);
                
                DocumentOperation.LoadFile(tempInputFile)
                    .Encrypt(new DocumentOperation.Encryption128Bit
                    {
                        UserPassword = model.Password,
                        OwnerPassword = model.Password,
                        AllowPrinting = true,
                        AllowContentExtraction = false,
                        AllowAnnotation = false
                    })
                    .Save(tempOutputFile);
                
                var protectedBytes = System.IO.File.ReadAllBytes(tempOutputFile);
                return File(protectedBytes, "application/pdf", $"payslip-{model.PayslipNumber}-protected.pdf");
            }
            finally
            {
                if (System.IO.File.Exists(tempInputFile))
                    System.IO.File.Delete(tempInputFile);
                if (System.IO.File.Exists(tempOutputFile))
                    System.IO.File.Delete(tempOutputFile);
            }
        }
        
        return File(pdfBytes, "application/pdf", $"payslip-{model.PayslipNumber}-protected.pdf");
    }

    /// <summary>
    /// Generates a custom Employee Payslip from request body
    /// </summary>
    [HttpPost("employee-payslip")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GenerateEmployeePayslip([FromBody] EmployeePayslipModel model)
    {
        if (model == null)
            return BadRequest("Employee payslip model is required");

        try
        {
            var document = new EmployeePayslipDocument(model);
            var pdfBytes = document.GeneratePdf();
            
            // Apply password protection if password is provided
            if (!string.IsNullOrEmpty(model.Password))
            {
                var tempInputFile = Path.GetTempFileName();
                var tempOutputFile = Path.GetTempFileName();
                
                try
                {
                    System.IO.File.WriteAllBytes(tempInputFile, pdfBytes);
                    
                    DocumentOperation.LoadFile(tempInputFile)
                        .Encrypt(new DocumentOperation.Encryption128Bit
                        {
                            UserPassword = model.Password,
                            OwnerPassword = model.Password,
                            AllowPrinting = true,
                            AllowContentExtraction = false,
                            AllowAnnotation = false
                        })
                        .Save(tempOutputFile);
                    
                    var protectedBytes = System.IO.File.ReadAllBytes(tempOutputFile);
                    return File(protectedBytes, "application/pdf", $"payslip-{model.PayslipNumber}.pdf");
                }
                finally
                {
                    if (System.IO.File.Exists(tempInputFile))
                        System.IO.File.Delete(tempInputFile);
                    if (System.IO.File.Exists(tempOutputFile))
                        System.IO.File.Delete(tempOutputFile);
                }
            }
            
            return File(pdfBytes, "application/pdf", $"payslip-{model.PayslipNumber}.pdf");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating employee payslip PDF");
            return StatusCode(500, $"Error generating PDF: {ex.Message}");
        }
    }

    /// <summary>
    /// Gets sample employee payslip data as JSON
    /// </summary>
    [HttpGet("employee-payslip/sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<EmployeePayslipModel> GetSampleEmployeePayslipJson()
    {
        return Ok(SampleDataGenerator.GetSampleEmployeePayslip());
    }

    #endregion

    #region Project Timeline Report (Dynamic Columns)

    /// <summary>
    /// Generates a Project Timeline Report with dynamic milestone columns
    /// </summary>
    [HttpGet("project-timeline/sample")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateProjectTimelineReportSample()
    {
        var model = SampleDataGenerator.GetSampleProjectTimelineReport();
        var document = new DynamicColumnReportDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return File(pdfBytes, "application/pdf", "project-timeline-sample.pdf");
    }

    /// <summary>
    /// Generates a custom Project Timeline Report from request body
    /// </summary>
    [HttpPost("project-timeline")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GenerateProjectTimelineReport([FromBody] DynamicColumnReportModel model)
    {
        if (model == null)
            return BadRequest("Project timeline report model is required");

        try
        {
            var document = new DynamicColumnReportDocument(model);
            var pdfBytes = document.GeneratePdf();
            
            return File(pdfBytes, "application/pdf", "project-timeline.pdf");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating project timeline report PDF");
            return StatusCode(500, $"Error generating PDF: {ex.Message}");
        }
    }

    /// <summary>
    /// Gets sample project timeline report data as JSON
    /// </summary>
    [HttpGet("project-timeline/sample/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<DynamicColumnReportModel> GetSampleProjectTimelineReportJson()
    {
        return Ok(SampleDataGenerator.GetSampleProjectTimelineReport());
    }

    #endregion
}
