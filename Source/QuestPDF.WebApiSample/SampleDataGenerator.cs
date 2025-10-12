using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample;

public static class SampleDataGenerator
{
    public static StandardTaxInvoiceModel GetSampleTaxInvoice()
    {
        return new StandardTaxInvoiceModel
        {
            TaxInvoiceNumber = "TAX-2025-00789",
            InvoiceDate = DateTime.Now,
            SupplyDate = DateTime.Now.AddDays(-2),
            PurchaseOrderNumber = "PO-12345",
            PaymentTerms = "Net 30 Days",

            Seller = new CompanyInfo
            {
                CompanyName = "Gulf Technology Solutions W.L.L.",
                CompanyNameArabic = "شركة حلول التكنولوجيا الخليجية",
                VATRegistrationNumber = "BH100234567800003",
                CommercialRegistrationNumber = "123456-1",
                Address = "Building 2345, Road 2417, Block 324",
                City = "Manama",
                Country = "Kingdom of Bahrain",
                Phone = "+973 1729 8888",
                Email = "accounts@gulftech.com.bh",
                Fax = "+973 1729 8889"
            },

            Customer = new CompanyInfo
            {
                CompanyName = "Bahrain Trading Company B.S.C.",
                CompanyNameArabic = "شركة البحرين للتجارة",
                VATRegistrationNumber = "BH100987654300002",
                CommercialRegistrationNumber = "654321-2",
                Address = "Building 1122, Road 3315, Block 433",
                City = "Manama",
                Country = "Kingdom of Bahrain",
                Phone = "+973 1755 6666",
                Email = "procurement@bahraintrading.bh"
            },

            Items = new List<TaxInvoiceItem>
            {
                new() { ItemNo = 1, Description = "Enterprise Software License - Annual Subscription", HSNCode = "852351", Quantity = 5, UnitOfMeasure = "License", UnitPrice = 2850.000m, DiscountPercent = 5, VATPercent = 10 },
                new() { ItemNo = 2, Description = "Professional Implementation Services", HSNCode = "998314", Quantity = 80, UnitOfMeasure = "Hours", UnitPrice = 65.000m, DiscountPercent = 0, VATPercent = 10 },
                new() { ItemNo = 3, Description = "Cloud Infrastructure Hosting - Premium Tier", HSNCode = "998315", Quantity = 12, UnitOfMeasure = "Months", UnitPrice = 450.000m, DiscountPercent = 10, VATPercent = 10 },
                new() { ItemNo = 4, Description = "Custom Module Development", HSNCode = "998314", Quantity = 120, UnitOfMeasure = "Hours", UnitPrice = 85.000m, DiscountPercent = 0, VATPercent = 10 },
                new() { ItemNo = 5, Description = "Premium Support Package - 24/7 Technical Support", HSNCode = "998316", Quantity = 12, UnitOfMeasure = "Months", UnitPrice = 550.000m, DiscountPercent = 0, VATPercent = 10 },
                new() { ItemNo = 6, Description = "Security Audit and Penetration Testing", HSNCode = "998317", Quantity = 2, UnitOfMeasure = "Service", UnitPrice = 1800.000m, DiscountPercent = 0, VATPercent = 10 },
                new() { ItemNo = 7, Description = "Mobile Application Development - iOS and Android", HSNCode = "998314", Quantity = 1, UnitOfMeasure = "Project", UnitPrice = 8500.000m, DiscountPercent = 0, VATPercent = 10 },
                new() { ItemNo = 8, Description = "Data Analytics and Business Intelligence Tools", HSNCode = "852351", Quantity = 5, UnitOfMeasure = "License", UnitPrice = 1200.000m, DiscountPercent = 8, VATPercent = 10 },
                new() { ItemNo = 9, Description = "API Gateway and Microservices Architecture Setup", HSNCode = "998314", Quantity = 60, UnitOfMeasure = "Hours", UnitPrice = 95.000m, DiscountPercent = 0, VATPercent = 10 },
                new() { ItemNo = 10, Description = "Database Optimization and Performance Tuning", HSNCode = "998314", Quantity = 40, UnitOfMeasure = "Hours", UnitPrice = 75.000m, DiscountPercent = 0, VATPercent = 10 },
                new() { ItemNo = 11, Description = "DevOps and CI/CD Pipeline Setup", HSNCode = "998315", Quantity = 1, UnitOfMeasure = "Project", UnitPrice = 4500.000m, DiscountPercent = 0, VATPercent = 10 },
                new() { ItemNo = 12, Description = "Training and Knowledge Transfer Sessions", HSNCode = "998318", Quantity = 20, UnitOfMeasure = "Hours", UnitPrice = 120.000m, DiscountPercent = 0, VATPercent = 10 },
                new() { ItemNo = 13, Description = "Documentation Services - Technical and User Manuals", HSNCode = "998319", Quantity = 1, UnitOfMeasure = "Package", UnitPrice = 2200.000m, DiscountPercent = 0, VATPercent = 10 },
                new() { ItemNo = 14, Description = "Third-party Software Licenses", HSNCode = "852351", Quantity = 8, UnitOfMeasure = "License", UnitPrice = 650.000m, DiscountPercent = 5, VATPercent = 10 },
                new() { ItemNo = 15, Description = "Ongoing Maintenance and Software Updates", HSNCode = "998316", Quantity = 12, UnitOfMeasure = "Months", UnitPrice = 850.000m, DiscountPercent = 10, VATPercent = 10 }
            },

            BankDetails = new BankDetails
            {
                BankName = "National Bank of Bahrain B.S.C.",
                AccountName = "Gulf Technology Solutions W.L.L.",
                AccountNumber = "0123456789",
                IBAN = "BH67 NBOB 0000 1234 5678 90",
                SwiftCode = "NBOBBBMX",
                Branch = "Diplomatic Area Branch, Manama"
            },

            TermsAndConditions = "1. Payment is due within 30 days from the invoice date.\n2. Late payments will incur a charge of 2% per month.\n3. All prices are in Bahraini Dinars (BHD) and include VAT as applicable.\n4. Services are provided as per the signed agreement dated 15-Sep-2025.\n5. Any disputes are subject to the jurisdiction of Bahrain courts.",

            Notes = "Thank you for your business! For any queries regarding this invoice, please contact our accounts department at accounts@gulftech.com.bh or call +973 1729 8888. Reference this invoice number (TAX-2025-00789) in all communications."
        };
    }

    public static ReceiptModel GetSampleReceipt()
    {
        return new ReceiptModel
        {
            ReceiptNumber = "RCP-2025-00456",
            ReceiptDate = DateTime.Now,
            PaymentMethod = "Bank Transfer",
            ReferenceNumber = "TXN-987654321",
            RelatedInvoiceNumber = "TAX-2025-00789",

            Company = new CompanyInfo
            {
                CompanyName = "Gulf Technology Solutions W.L.L.",
                Address = "Building 2345, Road 2417, Block 324",
                City = "Manama",
                Country = "Kingdom of Bahrain",
                Phone = "+973 1729 8888",
                Email = "accounts@gulftech.com.bh"
            },

            Customer = new CustomerInfo
            {
                Name = "Ahmed Al-Khalifa",
                CompanyName = "Bahrain Trading Company B.S.C.",
                Address = "Building 1122, Road 3315, Block 433, Manama",
                Phone = "+973 1755 6666",
                Email = "ahmed@bahraintrading.bh",
                VATNumber = "BH100987654300002"
            },

            Items = new List<ReceiptItem>
            {
                new() { ItemNo = 1, Description = "Payment for Invoice TAX-2025-00789", Amount = 45500.000m },
                new() { ItemNo = 2, Description = "Advance Payment for Next Month Services", Amount = 5000.000m }
            },

            Notes = "Payment received in full. Thank you for your prompt payment!",
            ReceivedBy = "Sara Mohammed - Accounts Manager"
        };
    }

    public static PurchaseOrderModel GetSamplePurchaseOrder()
    {
        return new PurchaseOrderModel
        {
            PONumber = "PO-2025-1234",
            PODate = DateTime.Now,
            RequiredDate = DateTime.Now.AddDays(30),
            DeliveryTerms = "DDP - Delivered Duty Paid",
            PaymentTerms = "50% advance, 50% on delivery",
            ShippingMethod = "Express Courier",

            Buyer = new CompanyInfo
            {
                CompanyName = "Bahrain Trading Company B.S.C.",
                Address = "Building 1122, Road 3315, Block 433",
                City = "Manama",
                Country = "Kingdom of Bahrain",
                Phone = "+973 1755 6666",
                Email = "procurement@bahraintrading.bh",
                VATRegistrationNumber = "BH100987654300002"
            },

            Supplier = new CompanyInfo
            {
                CompanyName = "Global Tech Supplies Ltd.",
                Address = "Silicon Valley Tech Park, Building 5",
                City = "Dubai",
                Country = "United Arab Emirates",
                Phone = "+971 4 123 4567",
                Email = "sales@globaltechsupplies.ae",
                VATRegistrationNumber = "AE123456789000001"
            },

            ShipTo = new ShippingAddress
            {
                AttentionTo = "Ahmed Al-Khalifa - IT Manager",
                Address = "Building 1122, Road 3315, Block 433",
                City = "Manama",
                Country = "Kingdom of Bahrain",
                Phone = "+973 1755 6666"
            },

            Items = new List<PurchaseOrderItem>
            {
                new() { ItemNo = 1, ItemCode = "SRV-HP-DL380", Description = "HP ProLiant DL380 Gen11 Server - 32GB RAM, 2TB SSD", Quantity = 5, UnitOfMeasure = "Unit", UnitPrice = 4500.00m, TaxPercent = 10, ExpectedDeliveryDate = DateTime.Now.AddDays(20) },
                new() { ItemNo = 2, ItemCode = "SW-VMWARE-VSPHERE", Description = "VMware vSphere Enterprise Plus License", Quantity = 5, UnitOfMeasure = "License", UnitPrice = 3200.00m, TaxPercent = 10, ExpectedDeliveryDate = DateTime.Now.AddDays(5) },
                new() { ItemNo = 3, ItemCode = "NET-CISCO-SW48", Description = "Cisco Catalyst 9300 48-Port Switch", Quantity = 2, UnitOfMeasure = "Unit", UnitPrice = 5800.00m, TaxPercent = 10, ExpectedDeliveryDate = DateTime.Now.AddDays(15) },
                new() { ItemNo = 4, ItemCode = "STG-DELL-SAN", Description = "Dell PowerStore 500T Storage Array", Quantity = 1, UnitOfMeasure = "Unit", UnitPrice = 28000.00m, TaxPercent = 10, ExpectedDeliveryDate = DateTime.Now.AddDays(25) },
                new() { ItemNo = 5, ItemCode = "UPS-APC-10KVA", Description = "APC Smart-UPS 10KVA Rack-Mount with Battery Pack", Quantity = 3, UnitOfMeasure = "Unit", UnitPrice = 3500.00m, TaxPercent = 10, ExpectedDeliveryDate = DateTime.Now.AddDays(10) },
                new() { ItemNo = 6, ItemCode = "RACK-42U-STD", Description = "42U Server Rack Cabinet with PDU", Quantity = 2, UnitOfMeasure = "Unit", UnitPrice = 1200.00m, TaxPercent = 10, ExpectedDeliveryDate = DateTime.Now.AddDays(12) },
                new() { ItemNo = 7, ItemCode = "SRV-INST", Description = "Professional Installation & Configuration Services", Quantity = 40, UnitOfMeasure = "Hours", UnitPrice = 150.00m, TaxPercent = 10, ExpectedDeliveryDate = DateTime.Now.AddDays(30) }
            },

            SpecialInstructions = "1. All equipment must be brand new with manufacturer warranty\n2. Installation to be coordinated with IT team 2 weeks in advance\n3. Deliver between 8 AM - 4 PM on weekdays only\n4. Supplier to provide training for 2 IT staff members",

            TermsAndConditions = "1. Prices are fixed and valid for 60 days from PO date\n2. Supplier must provide delivery schedule within 5 business days\n3. Any delays must be communicated immediately\n4. Goods remain property of supplier until full payment received",

            PreparedBy = "Ahmed Al-Khalifa - IT Manager",
            ApprovedBy = "Mohammed Al-Mansoori - CFO"
        };
    }

    public static DynamicColumnReportModel GetSampleDynamicColumnReport()
    {
        return new DynamicColumnReportModel
        {
            ReportTitle = "Regional Sales Performance Report",
            ReportSubtitle = "Quarterly Revenue by Product Category (2025)",
            GeneratedDate = DateTime.Now,
            GeneratedBy = "Sarah Ahmed - Analytics Manager",
            
            ColumnHeaders = new List<string>
            {
                "Q1 2025",
                "Q2 2025",
                "Q3 2025",
                "Q4 2025",
                "Total",
                "YoY Growth"
            },
            
            DataRows = new List<DynamicDataRow>
            {
                new() { RowLabel = "Electronics", Values = new List<string> { "285,450", "312,800", "298,600", "425,900", "1,322,750", "+18.5%" } },
                new() { RowLabel = "Home Appliances", Values = new List<string> { "156,200", "178,500", "165,300", "245,800", "745,800", "+12.3%" } },
                new() { RowLabel = "Computing", Values = new List<string> { "425,600", "468,900", "512,300", "598,700", "2,005,500", "+22.7%" } },
                new() { RowLabel = "Mobile Devices", Values = new List<string> { "512,800", "545,200", "587,400", "689,500", "2,334,900", "+15.8%" } },
                new() { RowLabel = "Accessories", Values = new List<string> { "98,500", "112,300", "125,600", "156,800", "493,200", "+28.4%" }, IsHighlighted = true },
                new() { RowLabel = "Gaming", Values = new List<string> { "245,600", "278,900", "312,500", "389,200", "1,226,200", "+31.2%" }, IsHighlighted = true },
                new() { RowLabel = "Smart Home", Values = new List<string> { "134,500", "156,800", "178,900", "212,400", "682,600", "+24.6%" } },
                new() { RowLabel = "Audio Equipment", Values = new List<string> { "89,200", "95,600", "102,300", "128,900", "416,000", "+9.8%" } }
            },
            
            SummaryRow = new DynamicDataRow
            {
                RowLabel = "GRAND TOTAL",
                Values = new List<string> { "1,947,850", "2,149,000", "2,282,900", "2,847,200", "9,226,950", "+19.4%" }
            },
            
            FooterNotes = "All figures in BHD (Bahraini Dinars). YoY Growth calculated against previous year same period. Highlighted rows indicate categories exceeding 25% growth target."
        };
    }

    public static ProductCatalogModel GetSampleProductCatalog()
    {
        return new ProductCatalogModel
        {
            CatalogTitle = "PREMIUM TECHNOLOGY PRODUCTS CATALOG",
            Season = "Summer",
            Year = 2025,
            ValidUntil = DateTime.Now.AddMonths(6),
            
            Company = new CompanyInfo
            {
                CompanyName = "Gulf Technology Solutions W.L.L.",
                Address = "Building 2345, Road 2417, Block 324",
                City = "Manama",
                Country = "Kingdom of Bahrain",
                Phone = "+973 1729 8888",
                Email = "sales@gulftech.com.bh",
                VATRegistrationNumber = "BH100234567800003"
            },
            
            Categories = new List<ProductCategory>
            {
                new()
                {
                    CategoryName = "Enterprise Servers",
                    Description = "High-performance server solutions for business-critical applications",
                    Products = new List<Product>
                    {
                        new() { ProductCode = "SRV-HP-DL380", ProductName = "HP ProLiant DL380 Gen11", Description = "2U Rack Server with dual Intel Xeon processors", Specifications = "32GB RAM, 2TB SSD, Redundant PSU", ListPrice = 4500.00m, Unit = "Unit", MinOrderQuantity = 1, AvailabilityStatus = "In Stock", LeadTime = "3-5 days" },
                        new() { ProductCode = "SRV-DELL-R750", ProductName = "Dell PowerEdge R750", Description = "Next-gen 2U rack server for demanding workloads", Specifications = "64GB RAM, 4TB NVMe, RAID Controller", ListPrice = 5800.00m, DiscountPrice = 5200.00m, Unit = "Unit", MinOrderQuantity = 1, AvailabilityStatus = "In Stock", LeadTime = "2-4 days" },
                        new() { ProductCode = "SRV-IBM-X3650", ProductName = "IBM System x3650 M5", Description = "Versatile 2U rack server with enterprise features", Specifications = "128GB RAM, 6TB Storage, Hot-swap drives", ListPrice = 6200.00m, Unit = "Unit", MinOrderQuantity = 1, AvailabilityStatus = "On Order", LeadTime = "10-15 days" }
                    }
                },
                new()
                {
                    CategoryName = "Network Equipment",
                    Description = "Professional networking hardware for reliable connectivity",
                    Products = new List<Product>
                    {
                        new() { ProductCode = "NET-CISCO-SW48", ProductName = "Cisco Catalyst 9300 48-Port", Description = "Enterprise-grade managed switch", Specifications = "48x 1GbE ports, 4x 10GbE uplinks, PoE+", ListPrice = 5800.00m, DiscountPrice = 5400.00m, Unit = "Unit", MinOrderQuantity = 1, AvailabilityStatus = "In Stock", LeadTime = "1-3 days" },
                        new() { ProductCode = "NET-HP-SW24", ProductName = "HP Aruba 2930F 24-Port", Description = "Layer 3 managed switch with advanced features", Specifications = "24x 1GbE + 4x SFP+, Stacking capable", ListPrice = 2400.00m, Unit = "Unit", MinOrderQuantity = 2, AvailabilityStatus = "In Stock", LeadTime = "1-2 days" },
                        new() { ProductCode = "NET-UBNT-DREAM", ProductName = "Ubiquiti Dream Machine Pro", Description = "All-in-one enterprise gateway and controller", Specifications = "8-port PoE switch, IDS/IPS, UniFi controller", ListPrice = 450.00m, DiscountPrice = 399.00m, Unit = "Unit", MinOrderQuantity = 1, AvailabilityStatus = "In Stock", LeadTime = "1-2 days" }
                    }
                },
                new()
                {
                    CategoryName = "Storage Solutions",
                    Description = "Scalable storage systems for data-intensive operations",
                    Products = new List<Product>
                    {
                        new() { ProductCode = "STG-DELL-SAN", ProductName = "Dell PowerStore 500T", Description = "Next-gen midrange storage array", Specifications = "All-flash, 100TB usable, dual controllers", ListPrice = 28000.00m, DiscountPrice = 25500.00m, Unit = "Unit", MinOrderQuantity = 1, AvailabilityStatus = "On Order", LeadTime = "20-30 days" },
                        new() { ProductCode = "STG-QNAP-NAS", ProductName = "QNAP TS-h1283XU-RP", Description = "High-performance rackmount NAS", Specifications = "12-bay, 10GbE, 32GB RAM, redundant PSU", ListPrice = 3200.00m, Unit = "Unit", MinOrderQuantity = 1, AvailabilityStatus = "In Stock", LeadTime = "5-7 days" },
                        new() { ProductCode = "STG-SYNOLOGY-SA", ProductName = "Synology SA3600", Description = "Enterprise NAS with high availability", Specifications = "12-bay, dual controller, 64GB RAM", ListPrice = 4500.00m, DiscountPrice = 4200.00m, Unit = "Unit", MinOrderQuantity = 1, AvailabilityStatus = "In Stock", LeadTime = "3-5 days" }
                    }
                },
                new()
                {
                    CategoryName = "Backup & UPS",
                    Description = "Power protection and backup solutions",
                    Products = new List<Product>
                    {
                        new() { ProductCode = "UPS-APC-10KVA", ProductName = "APC Smart-UPS SRT 10KVA", Description = "Double-conversion online UPS", Specifications = "10KVA/10KW, rack-mount 6U, LCD display", ListPrice = 3500.00m, Unit = "Unit", MinOrderQuantity = 1, AvailabilityStatus = "In Stock", LeadTime = "2-4 days" },
                        new() { ProductCode = "UPS-EATON-5P", ProductName = "Eaton 5P 3000VA Rack", Description = "Line-interactive UPS for IT equipment", Specifications = "3000VA/2700W, 2U rack, hot-swap batteries", ListPrice = 850.00m, DiscountPrice = 799.00m, Unit = "Unit", MinOrderQuantity = 2, AvailabilityStatus = "In Stock", LeadTime = "1-2 days" },
                        new() { ProductCode = "UPS-CYBERPOWER", ProductName = "CyberPower OR2200LCDRTXL2U", Description = "Smart App LCD UPS", Specifications = "2200VA/1600W, 2U rack, sine wave output", ListPrice = 425.00m, Unit = "Unit", MinOrderQuantity = 1, AvailabilityStatus = "In Stock", LeadTime = "1-3 days" }
                    }
                }
            },
            
            TermsAndConditions = "TERMS AND CONDITIONS:\n\n" +
                "1. PRICING: All prices are in Bahraini Dinars (BHD) and exclude VAT unless stated otherwise. Prices are valid until the date specified on the catalog cover.\n\n" +
                "2. MINIMUM ORDER: Minimum order quantities (MOQ) apply as specified per product. Orders below MOQ may incur additional charges.\n\n" +
                "3. PAYMENT TERMS: Standard payment terms are 50% advance and 50% upon delivery. Credit terms available for approved customers.\n\n" +
                "4. DELIVERY: Lead times are estimates and may vary based on stock availability. Express delivery available at additional cost.\n\n" +
                "5. WARRANTY: All products carry manufacturer warranty. Extended warranty options available upon request.\n\n" +
                "6. RETURNS: Returns accepted within 14 days for unopened items in original packaging. Restocking fee may apply.\n\n" +
                "7. TECHNICAL SUPPORT: Pre-sales consultation and post-sales technical support included. Professional installation services available.\n\n" +
                "8. RESERVATION OF RIGHTS: We reserve the right to modify prices, specifications, and availability without prior notice.\n\n" +
                "For inquiries, bulk orders, or custom quotations, please contact our sales team at sales@gulftech.com.bh or call +973 1729 8888."
        };
    }

    public static EmployeeReportModel GetSampleEmployeeReport()
    {
        return new EmployeeReportModel
        {
            ReportTitle = "Monthly Employee Performance & Attendance Report",
            Department = "Information Technology Department",
            ReportDate = DateTime.Now,
            ReportingPeriod = "October 2025",
            
            Company = new CompanyInfo
            {
                CompanyName = "Gulf Technology Solutions W.L.L.",
                Address = "Building 2345, Road 2417, Block 324",
                City = "Manama",
                Country = "Kingdom of Bahrain",
                Phone = "+973 1729 8888",
                Email = "hr@gulftech.com.bh",
                VATRegistrationNumber = "BH100234567800003"
            },
            
            Employees = new List<EmployeeRecord>
            {
                new() { EmployeeId = "EMP001", FullName = "Ahmed Al-Khalifa", Position = "Senior System Administrator", JoinDate = new DateTime(2020, 3, 15), Email = "ahmed.k@gulftech.bh", Phone = "+973 3312 4567", MonthlySalary = 1800m, WorkingDays = 22, LeaveDays = 0, PerformanceRating = "Excellent", Status = "Active" },
                new() { EmployeeId = "EMP002", FullName = "Sarah Mohammed", Position = "Software Developer", JoinDate = new DateTime(2021, 6, 1), Email = "sarah.m@gulftech.bh", Phone = "+973 3345 6789", MonthlySalary = 1500m, WorkingDays = 20, LeaveDays = 2, PerformanceRating = "Excellent", Status = "Active" },
                new() { EmployeeId = "EMP003", FullName = "Mohammed Al-Mansoori", Position = "Network Engineer", JoinDate = new DateTime(2019, 1, 10), Email = "mohammed.a@gulftech.bh", Phone = "+973 3398 7654", MonthlySalary = 1650m, WorkingDays = 22, LeaveDays = 0, PerformanceRating = "Good", Status = "Active" },
                new() { EmployeeId = "EMP004", FullName = "Fatima Hassan", Position = "Database Administrator", JoinDate = new DateTime(2022, 9, 5), Email = "fatima.h@gulftech.bh", Phone = "+973 3356 4321", MonthlySalary = 1400m, WorkingDays = 21, LeaveDays = 1, PerformanceRating = "Excellent", Status = "Active" },
                new() { EmployeeId = "EMP005", FullName = "Khalid Ibrahim", Position = "IT Support Specialist", JoinDate = new DateTime(2023, 2, 20), Email = "khalid.i@gulftech.bh", Phone = "+973 3334 5678", MonthlySalary = 950m, WorkingDays = 22, LeaveDays = 0, PerformanceRating = "Good", Status = "Active" },
                new() { EmployeeId = "EMP006", FullName = "Noora Ali", Position = "Security Analyst", JoinDate = new DateTime(2021, 11, 8), Email = "noora.a@gulftech.bh", Phone = "+973 3367 8901", MonthlySalary = 1550m, WorkingDays = 19, LeaveDays = 3, PerformanceRating = "Good", Status = "Active" },
                new() { EmployeeId = "EMP007", FullName = "Hamad Yousif", Position = "DevOps Engineer", JoinDate = new DateTime(2020, 7, 12), Email = "hamad.y@gulftech.bh", Phone = "+973 3389 0123", MonthlySalary = 1700m, WorkingDays = 22, LeaveDays = 0, PerformanceRating = "Excellent", Status = "Active" },
                new() { EmployeeId = "EMP008", FullName = "Mariam Abdullah", Position = "Junior Developer", JoinDate = new DateTime(2024, 1, 15), Email = "mariam.a@gulftech.bh", Phone = "+973 3323 4567", MonthlySalary = 850m, WorkingDays = 21, LeaveDays = 1, PerformanceRating = "Good", Status = "Active" },
                new() { EmployeeId = "EMP009", FullName = "Ali Salman", Position = "IT Manager", JoinDate = new DateTime(2018, 4, 1), Email = "ali.s@gulftech.bh", Phone = "+973 3345 6789", MonthlySalary = 2200m, WorkingDays = 20, LeaveDays = 2, PerformanceRating = "Excellent", Status = "Active" },
                new() { EmployeeId = "EMP010", FullName = "Aysha Jamal", Position = "Cloud Architect", JoinDate = new DateTime(2021, 3, 22), Email = "aysha.j@gulftech.bh", Phone = "+973 3378 9012", MonthlySalary = 1900m, WorkingDays = 22, LeaveDays = 0, PerformanceRating = "Excellent", Status = "Active" }
            },
            
            Summary = new EmployeeSummary
            {
                TotalEmployees = 10,
                ActiveEmployees = 10,
                OnLeaveEmployees = 0,
                TotalSalaryExpense = 15500m,
                AverageSalary = 1550m
            },
            
            Remarks = "Overall department performance has been excellent this month. All critical projects are on schedule. Team collaboration and productivity metrics show positive trends. Continue monitoring the new junior developers' progress and provide necessary mentoring support.",
            
            PreparedBy = "Layla Ahmed - HR Manager",
            ReviewedBy = "Rashid Al-Khater - Head of IT"
        };
    }
}
