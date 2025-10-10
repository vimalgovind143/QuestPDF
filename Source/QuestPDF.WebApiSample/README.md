# QuestPDF Web API Sample

A real-time PDF generation web API built with **ASP.NET Core 8** and **QuestPDF**. This sample demonstrates how to generate professional PDF documents on-demand through RESTful endpoints.

## Features

✅ **Real-time PDF Generation** - Generate PDFs dynamically via HTTP requests  
✅ **RESTful API** - Easy-to-use endpoints for PDF creation  
✅ **Swagger UI** - Interactive API documentation and testing  
✅ **Multiple Document Types** - Invoice generation with customizable templates  
✅ **Sample Data** - Pre-built examples to get started quickly  

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

### 1. Hello World PDF
Simple demonstration PDF with basic content.

**GET** `/api/pdf/hello`

**Example:**
```bash
curl http://localhost:5100/api/pdf/hello --output hello.pdf
```

Or simply open in your browser:
```
http://localhost:5100/api/pdf/hello
```

---

### 2. Sample Invoice PDF
Generate a pre-built invoice with sample data.

**GET** `/api/pdf/invoice/sample`

**Example:**
```bash
curl http://localhost:5100/api/pdf/invoice/sample --output invoice.pdf
```

Or open in browser:
```
http://localhost:5100/api/pdf/invoice/sample
```

---

### 3. Custom Invoice PDF
Generate an invoice with your own data.

**POST** `/api/pdf/invoice`

**Content-Type:** `application/json`

**Example Request Body:**
```json
{
  "invoiceNumber": 1001,
  "issueDate": "2025-10-09T00:00:00",
  "dueDate": "2025-11-09T00:00:00",
  "sellerAddress": {
    "companyName": "Your Company",
    "street": "123 Main St",
    "city": "New York",
    "state": "NY 10001",
    "email": "contact@yourcompany.com",
    "phone": "+1 555-0123"
  },
  "customerAddress": {
    "companyName": "Customer Inc",
    "street": "456 Oak Ave",
    "city": "Boston",
    "state": "MA 02101",
    "email": "billing@customer.com",
    "phone": "+1 555-9876"
  },
  "items": [
    {
      "name": "Professional Services",
      "price": 1500.00,
      "quantity": 1
    },
    {
      "name": "Consulting Hours",
      "price": 150.00,
      "quantity": 5
    }
  ],
  "comments": "Thank you for your business!"
}
```

**Example using curl:**
```bash
curl -X POST http://localhost:5100/api/pdf/invoice \
  -H "Content-Type: application/json" \
  -d @invoice-data.json \
  --output custom-invoice.pdf
```

**Example using PowerShell:**
```powershell
Invoke-RestMethod -Uri "http://localhost:5100/api/pdf/invoice" `
  -Method Post `
  -ContentType "application/json" `
  -InFile "invoice-data.json" `
  -OutFile "custom-invoice.pdf"
```

---

### 4. Get Sample Invoice JSON
Retrieve the sample invoice data as JSON (useful for testing).

**GET** `/api/pdf/invoice/sample/json`

**Example:**
```bash
curl http://localhost:5100/api/pdf/invoice/sample/json
```

## Project Structure

```
QuestPDF.WebApiSample/
├── Controllers/
│   └── PdfController.cs          # API endpoints
├── Documents/
│   └── InvoiceDocument.cs        # PDF document template
├── Models/
│   └── InvoiceModel.cs           # Data models
├── Properties/
│   └── launchSettings.json       # Launch configuration
├── Program.cs                    # Application entry point
├── appsettings.json              # Configuration
└── README.md                     # This file
```

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

### Modifying the Invoice Template

Edit `Documents/InvoiceDocument.cs` to customize:
- Layout and styling
- Colors and fonts
- Table structure
- Header and footer content

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
