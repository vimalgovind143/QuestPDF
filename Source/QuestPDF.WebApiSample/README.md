# QuestPDF Web API Sample

A real-time PDF generation web API built with **ASP.NET Core 8** and **QuestPDF**. This sample demonstrates how to generate professional PDF documents on-demand through RESTful endpoints.

## Features

✅ **Real-time PDF Generation** - Generate PDFs dynamically via HTTP requests  
✅ **RESTful API** - Easy-to-use endpoints for PDF creation  
✅ **Swagger UI** - Interactive API documentation and testing  
✅ **Multiple Document Types** - Various business document templates  
✅ **Sample Data** - Pre-built examples to get started quickly  
✅ **Dynamic Layouts** - Reports with variable columns determined at runtime  
✅ **Multiple Orientations** - Both A4 Portrait and Landscape formats  
✅ **Branding Support** - Add company logos, seals, and watermarks to all documents  

## Getting Started

### Prerequisites

- .NET 8 SDK or later
- Your favorite HTTP client (browser, Postman, curl, etc.)

### Running the Application

1. **Navigate to the project directory:**
   ```bash
   cd Source\QuestPDF.WebApiSample
   ```

2. **Run the application:**
   ```bash
   dotnet run
   ```

3. **Access Swagger UI:**
   Open your browser and navigate to:
   - HTTP: http://localhost:5100/swagger
   - HTTPS: https://localhost:5001/swagger

## API Endpoints

All endpoints support both GET (with sample data) and POST (with custom data) methods, plus JSON data retrieval for testing.

### 1. Standard TAX Invoice

Professional tax invoice with VAT calculations, multi-page support, and Arabic text.

**GET** `/api/pdf/tax-invoice/sample` - Generate sample TAX invoice  
**POST** `/api/pdf/tax-invoice` - Generate custom TAX invoice  
**GET** `/api/pdf/tax-invoice/sample/json` - Get sample data as JSON

**Example:**
```bash
curl http://localhost:5100/api/pdf/tax-invoice/sample --output tax-invoice.pdf
```

---

### 2. Receipt Document

Compact A5 receipt for payment confirmations.

**GET** `/api/pdf/receipt/sample` - Generate sample receipt  
**POST** `/api/pdf/receipt` - Generate custom receipt  
**GET** `/api/pdf/receipt/sample/json` - Get sample data as JSON

**Example:**
```bash
curl http://localhost:5100/api/pdf/receipt/sample --output receipt.pdf
```

---

### 3. Purchase Order

Comprehensive purchase order with delivery details and approval signatures.

**GET** `/api/pdf/purchase-order/sample` - Generate sample purchase order  
**POST** `/api/pdf/purchase-order` - Generate custom purchase order  
**GET** `/api/pdf/purchase-order/sample/json` - Get sample data as JSON

**Example:**
```bash
curl http://localhost:5100/api/pdf/purchase-order/sample --output purchase-order.pdf
```

---

### 4. Dynamic Column Report

Flexible report with variable columns determined at runtime - perfect for sales reports, analytics, or any data with changing column structures.

**GET** `/api/pdf/dynamic-column-report/sample` - Generate sample report  
**POST** `/api/pdf/dynamic-column-report` - Generate custom report  
**GET** `/api/pdf/dynamic-column-report/sample/json` - Get sample data as JSON

**Example:**
```bash
curl http://localhost:5100/api/pdf/dynamic-column-report/sample --output dynamic-report.pdf
```

**Key Features:**
- Variable number of columns
- Highlighted rows for emphasis
- Summary row support
- Ideal for quarterly reports, regional analysis

---

### 5. Product Catalog (A4 Landscape)

Wide-format product catalog showcasing multiple categories and products - demonstrates A4 landscape orientation.

**GET** `/api/pdf/product-catalog/sample` - Generate sample catalog  
**POST** `/api/pdf/product-catalog` - Generate custom catalog  
**GET** `/api/pdf/product-catalog/sample/json` - Get sample data as JSON

**Example:**
```bash
curl http://localhost:5100/api/pdf/product-catalog/sample --output product-catalog.pdf
```

**Key Features:**
- A4 Landscape format for wider content
- Multiple product categories
- Discount pricing with strikethrough
- Color-coded availability status
- Terms and conditions on separate page

---

### 6. Employee Report (A4 Portrait)

Professional employee directory and performance report - demonstrates A4 portrait layout with structured data.

**GET** `/api/pdf/employee-report/sample` - Generate sample report  
**POST** `/api/pdf/employee-report` - Generate custom report  
**GET** `/api/pdf/employee-report/sample/json` - Get sample data as JSON

**Example:**
```bash
curl http://localhost:5100/api/pdf/employee-report/sample --output employee-report.pdf
```

**Key Features:**
- A4 Portrait format
- Summary statistics cards
- Performance ratings with color coding
- Attendance tracking
- Signature sections

## Project Structure

```
QuestPDF.WebApiSample/
├── Controllers/
│   └── PdfController.cs                      # API endpoints for all documents
├── Documents/
│   ├── StandardTaxInvoiceDocument.cs         # TAX invoice template
│   ├── ReceiptDocument.cs                    # Receipt template (A5)
│   ├── PurchaseOrderDocument.cs              # Purchase order template
│   ├── DynamicColumnReportDocument.cs        # Dynamic column report (A4)
│   ├── ProductCatalogDocument.cs             # Product catalog (A4 Landscape)
│   └── EmployeeReportDocument.cs             # Employee report (A4 Portrait)
├── Models/
│   ├── StandardTaxInvoiceModel.cs            # TAX invoice data model
│   ├── ReceiptModel.cs                       # Receipt data model
│   ├── PurchaseOrderModel.cs                 # Purchase order data model
│   ├── DynamicColumnReportModel.cs           # Dynamic report data model
│   ├── ProductCatalogModel.cs                # Product catalog data model
│   └── EmployeeReportModel.cs                # Employee report data model
├── SampleDataGenerator.cs                    # Sample data for all document types
├── Program.cs                                # Application entry point
├── appsettings.json                          # Configuration
└── README.md                                 # This file
```

## Document Type Overview

| Document | Format | Orientation | Use Case |
|----------|--------|-------------|----------|
| **TAX Invoice** | A4 | Portrait | Professional invoices with VAT |
| **Receipt** | A5 | Portrait | Payment confirmations |
| **Purchase Order** | A4 | Portrait | Procurement documents |
| **Dynamic Column Report** | A4 | Portrait | Analytics & sales reports |
| **Product Catalog** | A4 | **Landscape** | Product listings & catalogs |
| **Employee Report** | A4 | Portrait | HR reports & directories |

## Adding Your Company Branding

All documents support company branding through images. To add your logos and watermarks:

1. **Create an `Images` folder** in the project root (if not already present)
2. **Add your image files** with these exact names:
   - `company-logo.png` - Main header logo (120x60px recommended)
   - `company-logo-footer.png` - Footer logo (40x30px, optional)
   - `company-seal.png` - Official seal/stamp (80x80px)
   - `watermark.png` - Background watermark (400x400px, semi-transparent)

3. **Restart the application** if it's running

See `Images/README.md` for detailed guidelines and specifications.

### Branding Features

- **Header Logo:** Appears in top-right corner of all documents
- **Footer Logo:** Small logo in document footers with company info
- **Watermark:** Semi-transparent background image on all pages (15% opacity)
- **Company Seal:** Official stamp in signature sections (Tax Invoice, Receipt, Purchase Order)

The system works with or without images - placeholders appear if images are missing.

## Customization

### Creating New Document Templates

1. Create a new class implementing `IDocument`:
```csharp
public class MyCustomDocument : IDocument
{
    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            // Your custom layout here
        });
    }
    
    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
    public DocumentSettings GetSettings() => DocumentSettings.Default;
}
```

2. Add a new endpoint in `PdfController.cs`:
```csharp
[HttpGet("my-custom-pdf")]
public IActionResult GenerateCustomPdf()
{
    var document = new MyCustomDocument();
    var pdfBytes = document.GeneratePdf();
    return File(pdfBytes, "application/pdf", "custom.pdf");
}
```

### Modifying Existing Templates

Each document template in the `Documents/` folder can be customized:
- Layout and styling
- Colors and fonts
- Table structure and columns
- Header and footer content
- Page size and orientation

**Example - Changing to Landscape:**
```csharp
// In any Document class Compose method
page.Size(PageSizes.A4.Landscape());  // Instead of Portrait()
```

**Example - Custom Page Size:**
```csharp
page.Size(new PageSize(800, 600));  // Custom width x height in points
```

## Technologies Used

- **ASP.NET Core 8** - Web framework
- **QuestPDF** - PDF generation library
- **Swagger/OpenAPI** - API documentation

## Production Considerations

For production deployment, consider:

1. **License**: Update the QuestPDF license in `Program.cs`
   ```csharp
   QuestPDF.Settings.License = LicenseType.Professional; // or Enterprise
   ```

2. **Error Handling**: Add comprehensive error handling and logging

3. **Performance**: Implement caching for frequently generated documents

4. **Security**: Add authentication and authorization

5. **Rate Limiting**: Protect against abuse

6. **File Storage**: Consider streaming large PDFs or storing them

## Additional Resources

- [QuestPDF Documentation](https://www.questpdf.com/documentation/getting-started.html)
- [QuestPDF GitHub](https://github.com/QuestPDF/QuestPDF)
- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)

## License

This sample project follows the QuestPDF licensing terms. For production use, ensure you have an appropriate QuestPDF license.
