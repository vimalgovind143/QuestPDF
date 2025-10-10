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
}
