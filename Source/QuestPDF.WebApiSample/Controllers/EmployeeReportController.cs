using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.WebApiSample.Documents;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Controllers;

/// <summary>
/// Comprehensive Employee Controller for all employee-related reports
/// Supports merged reports, employee listings, citizenship analysis, department analysis, payslips, and traditional reports
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class EmployeeReportController : BasePdfController
{
    public EmployeeReportController(ILogger<BasePdfController> logger) : base(logger)
    {
    }

    /// <summary>
    /// Generates a comprehensive merged employee report with payslip and analysis
    /// </summary>
    [HttpGet("merged")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateMergedReport()
    {
        var model = SampleDataGenerator.GetSampleEmployeeData(EmployeeReportType.Merged);
        var document = new EmployeeMergedDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return GeneratePdfFile(pdfBytes, $"employee-merged-report-{DateTime.Now:yyyyMMdd}.pdf");
    }

    /// <summary>
    /// Generates a complete employee listing report
    /// </summary>
    [HttpGet("listing")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateListingReport()
    {
        var model = SampleDataGenerator.GetSampleEmployeeData(EmployeeReportType.Listing);
        var document = new EmployeeMergedDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return GeneratePdfFile(pdfBytes, $"employee-listing-report-{DateTime.Now:yyyyMMdd}.pdf");
    }

    /// <summary>
    /// Generates an employee count by citizenship report
    /// </summary>
    [HttpGet("citizenship")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateCitizenshipReport()
    {
        var model = SampleDataGenerator.GetSampleEmployeeData(EmployeeReportType.Citizenship);
        var document = new EmployeeMergedDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return GeneratePdfFile(pdfBytes, $"employee-citizenship-report-{DateTime.Now:yyyyMMdd}.pdf");
    }

    /// <summary>
    /// Generates a department-wise employee analysis report
    /// </summary>
    [HttpGet("department")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateDepartmentReport()
    {
        var model = SampleDataGenerator.GetSampleEmployeeData(EmployeeReportType.Department);
        var document = new EmployeeMergedDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return GeneratePdfFile(pdfBytes, $"employee-department-report-{DateTime.Now:yyyyMMdd}.pdf");
    }

    /// <summary>
    /// Generates a specific report type based on parameter
    /// </summary>
    [HttpGet("{reportType}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GenerateReportByType(string reportType)
    {
        EmployeeReportType type;
        switch (reportType.ToLower())
        {
            case "merged":
            case "all":
                type = EmployeeReportType.Merged;
                break;
            case "listing":
            case "list":
                type = EmployeeReportType.Listing;
                break;
            case "citizenship":
            case "nationality":
                type = EmployeeReportType.Citizenship;
                break;
            case "department":
            case "dept":
                type = EmployeeReportType.Department;
                break;
            default:
                return BadRequest($"Invalid report type: {reportType}. Valid types are: merged, listing, citizenship, department");
        }

        var model = SampleDataGenerator.GetSampleEmployeeData(type);
        var document = new EmployeeMergedDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return GeneratePdfFile(pdfBytes, $"employee-{reportType}-report-{DateTime.Now:yyyyMMdd}.pdf");
    }

    /// <summary>
    /// Gets sample employee data as JSON for merged report
    /// </summary>
    [HttpGet("merged/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<EmployeeDataModel> GetMergedJson()
    {
        return Ok(SampleDataGenerator.GetSampleEmployeeData(EmployeeReportType.Merged));
    }

    /// <summary>
    /// Gets sample employee data as JSON for listing report
    /// </summary>
    [HttpGet("listing/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<EmployeeDataModel> GetListingJson()
    {
        return Ok(SampleDataGenerator.GetSampleEmployeeData(EmployeeReportType.Listing));
    }

    /// <summary>
    /// Gets sample employee data as JSON for citizenship report
    /// </summary>
    [HttpGet("citizenship/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<EmployeeDataModel> GetCitizenshipJson()
    {
        return Ok(SampleDataGenerator.GetSampleEmployeeData(EmployeeReportType.Citizenship));
    }

    /// <summary>
    /// Gets sample employee data as JSON for department report
    /// </summary>
    [HttpGet("department/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<EmployeeDataModel> GetDepartmentJson()
    {
        return Ok(SampleDataGenerator.GetSampleEmployeeData(EmployeeReportType.Department));
    }

    /// <summary>
    /// Gets all available employee report types
    /// </summary>
    [HttpGet("types")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<object>> GetReportTypes()
    {
        var reportTypes = new[]
        {
            new { Type = "merged", Description = "Comprehensive merged report with payslip and analysis", Url = "/api/EmployeeReport/merged" },
            new { Type = "listing", Description = "Complete employee listing with all details", Url = "/api/EmployeeReport/listing" },
            new { Type = "citizenship", Description = "Employee count and analysis by citizenship", Url = "/api/EmployeeReport/citizenship" },
            new { Type = "department", Description = "Department-wise employee analysis", Url = "/api/EmployeeReport/department" },
            new { Type = "payslip", Description = "Traditional employee payslip", Url = "/api/EmployeeReport/payslip" },
            new { Type = "report", Description = "Traditional employee report", Url = "/api/EmployeeReport/report" }
        };

        return Ok(reportTypes);
    }

    /// <summary>
    /// Gets employee summary statistics
    /// </summary>
    [HttpGet("summary")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<object> GetEmployeeSummary()
    {
        var model = SampleDataGenerator.GetSampleEmployeeData(EmployeeReportType.Merged);
        var summary = new
        {
            ReportDate = model.ReportDate,
            ReportingPeriod = model.ReportingPeriod,
            TotalEmployees = model.Summary.TotalEmployees,
            ActiveEmployees = model.Summary.ActiveEmployees,
            OnLeaveEmployees = model.Summary.OnLeaveEmployees,
            TerminatedEmployees = model.Summary.TerminatedEmployees,
            TotalDepartments = model.Summary.TotalDepartments,
            TotalCitizenshipCategories = model.Summary.TotalCitizenshipCategories,
            TotalSalaryExpense = model.Summary.TotalSalaryExpense,
            AverageSalary = model.Summary.AverageSalary,
            AverageYearsOfService = model.Summary.AverageYearsOfService,
            OverallAttendanceRate = model.Summary.OverallAttendanceRate,
            MaleEmployees = model.Summary.MaleEmployees,
            FemaleEmployees = model.Summary.FemaleEmployees,
            FullTimeEmployees = model.Summary.FullTimeEmployees,
            PartTimeEmployees = model.Summary.PartTimeEmployees,
            ContractEmployees = model.Summary.ContractEmployees,
            DepartmentBreakdown = model.DepartmentAnalysis.Select(d => new
            {
                Department = d.DepartmentName,
                EmployeeCount = d.EmployeeCount,
                ActiveEmployees = d.ActiveEmployees,
                AverageSalary = d.AverageSalary,
                DepartmentHead = d.DepartmentHead
            }),
            CitizenshipBreakdown = model.CitizenshipAnalysis.Select(c => new
            {
                Citizenship = c.Citizenship,
                EmployeeCount = c.EmployeeCount,
                PercentageOfTotal = c.PercentageOfTotal,
                AverageSalary = c.AverageSalary
            })
        };

        return Ok(summary);
    }

    /// <summary>
    /// Generates a custom report with specific filters (placeholder for future enhancement)
    /// </summary>
    [HttpPost("custom")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GenerateCustomReport([FromBody] EmployeeCustomReportRequest request)
    {
        // This is a placeholder for future enhancement
        // Currently returns the merged report with custom title
        var model = SampleDataGenerator.GetSampleEmployeeData(EmployeeReportType.Merged);
        
        if (!string.IsNullOrEmpty(request.ReportTitle))
        {
            model.ReportTitle = request.ReportTitle;
        }
        
        if (!string.IsNullOrEmpty(request.ReportingPeriod))
        {
            model.ReportingPeriod = request.ReportingPeriod;
        }

        var document = new EmployeeMergedDocument(model);
        var pdfBytes = document.GeneratePdf();
        
        return GeneratePdfFile(pdfBytes, $"custom-employee-report-{DateTime.Now:yyyyMMdd}.pdf");
    }

    /// <summary>
    /// Generates an Employee Payslip with sample data (traditional payslip)
    /// </summary>
    [HttpGet("payslip")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GeneratePayslip()
    {
        var model = SampleDataGenerator.GetSampleEmployeePayslip();
        var document = new EmployeePayslipDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return GeneratePdfFile(pdfBytes, $"payslip-{model.PayslipNumber}.pdf");
    }

    /// <summary>
    /// Gets sample employee payslip data as JSON
    /// </summary>
    [HttpGet("payslip/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<EmployeePayslipModel> GetPayslipJson()
    {
        return Ok(SampleDataGenerator.GetSampleEmployeePayslip());
    }

    /// <summary>
    /// Generates an Employee Report with sample data (traditional report)
    /// </summary>
    [HttpGet("report")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GenerateTraditionalReport()
    {
        var model = SampleDataGenerator.GetSampleEmployeeReport();
        var document = new EmployeeReportDocument(model);
        
        var pdfBytes = document.GeneratePdf();
        
        return GeneratePdfFile(pdfBytes, "employee-report-sample.pdf");
    }

    /// <summary>
    /// Gets sample employee report data as JSON
    /// </summary>
    [HttpGet("report/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<EmployeeReportModel> GetTraditionalReportJson()
    {
        return Ok(SampleDataGenerator.GetSampleEmployeeReport());
    }
}

/// <summary>
/// Request model for custom employee reports
/// </summary>
public class EmployeeCustomReportRequest
{
    public string ReportTitle { get; set; } = string.Empty;
    public string ReportingPeriod { get; set; } = string.Empty;
    public List<string> Departments { get; set; } = new();
    public List<string> CitizenshipTypes { get; set; } = new();
    public string ReportType { get; set; } = "Merged";
    public bool IncludePayslip { get; set; } = true;
    public bool IncludeCharts { get; set; } = false;
}