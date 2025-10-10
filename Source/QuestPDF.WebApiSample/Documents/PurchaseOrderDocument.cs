using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.WebApiSample.Models;

namespace QuestPDF.WebApiSample.Documents;

public class PurchaseOrderDocument : IDocument
{
    private PurchaseOrderModel Model { get; }

    public PurchaseOrderDocument(PurchaseOrderModel model)
    {
        Model = model;
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
    public DocumentSettings GetSettings() => DocumentSettings.Default;

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.Margin(40);
            page.PageColor(Colors.White);
            page.DefaultTextStyle(x => x.FontSize(9));

            page.Header().Element(ComposeHeader);
            page.Content().Element(ComposeContent);
            page.Footer().Element(ComposeFooter);
        });
    }

    void ComposeHeader(IContainer container)
    {
        container.Column(column =>
        {
            column.Spacing(5);

            column.Item().BorderBottom(2).BorderColor(Colors.Orange.Darken2).PaddingBottom(10).Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text("PURCHASE ORDER")
                        .FontSize(24)
                        .Bold()
                        .FontColor(Colors.Orange.Darken2);

                    col.Item().Text(Model.Buyer.CompanyName)
                        .FontSize(14)
                        .SemiBold();
                });

                row.ConstantItem(180).Background(Colors.Orange.Lighten4).Padding(8).Column(col =>
                {
                    col.Spacing(3);
                    col.Item().DefaultTextStyle(x => x.FontSize(10)).Text(text =>
                    {
                        text.Span("PO Number: ").SemiBold();
                        text.Span(Model.PONumber).FontColor(Colors.Orange.Darken3);
                    });

                    col.Item().DefaultTextStyle(x => x.FontSize(9)).Text(text =>
                    {
                        text.Span("PO Date: ").SemiBold();
                        text.Span(Model.PODate.ToString("dd-MMM-yyyy"));
                    });

                    col.Item().DefaultTextStyle(x => x.FontSize(9)).Text(text =>
                    {
                        text.Span("Required: ").SemiBold();
                        text.Span(Model.RequiredDate.ToString("dd-MMM-yyyy"));
                    });
                });
            });

            column.Item().PaddingTop(10).Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Spacing(3);
                    col.Item().Text("From (Buyer)").FontSize(10).SemiBold().FontColor(Colors.Orange.Darken1);
                    col.Item().BorderLeft(3).BorderColor(Colors.Orange.Darken1).PaddingLeft(8).Column(innerCol =>
                    {
                        innerCol.Spacing(2);
                        innerCol.Item().Text(Model.Buyer.CompanyName).FontSize(10).SemiBold();
                        innerCol.Item().Text(Model.Buyer.Address).FontSize(8);
                        innerCol.Item().Text($"{Model.Buyer.City}, {Model.Buyer.Country}").FontSize(8);
                        innerCol.Item().Text($"Phone: {Model.Buyer.Phone}").FontSize(8);
                        innerCol.Item().Text($"Email: {Model.Buyer.Email}").FontSize(8);
                    });
                });

                row.ConstantItem(20);

                row.RelativeItem().Column(col =>
                {
                    col.Spacing(3);
                    col.Item().Text("Supplier").FontSize(10).SemiBold().FontColor(Colors.Orange.Darken1);
                    col.Item().BorderLeft(3).BorderColor(Colors.Orange.Darken1).PaddingLeft(8).Column(innerCol =>
                    {
                        innerCol.Spacing(2);
                        innerCol.Item().Text(Model.Supplier.CompanyName).FontSize(10).SemiBold();
                        innerCol.Item().Text(Model.Supplier.Address).FontSize(8);
                        innerCol.Item().Text($"{Model.Supplier.City}, {Model.Supplier.Country}").FontSize(8);
                        innerCol.Item().Text($"Phone: {Model.Supplier.Phone}").FontSize(8);
                        innerCol.Item().Text($"Email: {Model.Supplier.Email}").FontSize(8);
                    });
                });
            });

            if (Model.ShipTo != null)
            {
                column.Item().PaddingTop(10).Background(Colors.Grey.Lighten4).Padding(8).Column(col =>
                {
                    col.Item().Text("Ship To").FontSize(10).SemiBold().FontColor(Colors.Orange.Darken1);
                    col.Item().PaddingTop(2).Text(Model.ShipTo.AttentionTo).FontSize(9).SemiBold();
                    col.Item().Text(Model.ShipTo.Address).FontSize(8);
                    col.Item().Text($"{Model.ShipTo.City}, {Model.ShipTo.Country}").FontSize(8);
                    if (!string.IsNullOrEmpty(Model.ShipTo.Phone))
                        col.Item().Text($"Phone: {Model.ShipTo.Phone}").FontSize(8);
                });
            }
        });
    }

    void ComposeContent(IContainer container)
    {
        container.PaddingTop(15).Column(column =>
        {
            column.Spacing(10);

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(25);
                    columns.ConstantColumn(70);
                    columns.RelativeColumn(3);
                    columns.ConstantColumn(40);
                    columns.ConstantColumn(35);
                    columns.RelativeColumn(2);
                    columns.RelativeColumn(2);
                    columns.RelativeColumn(2);
                });

                table.Header(header =>
                {
                    header.Cell().Element(HeaderStyle).Text("#");
                    header.Cell().Element(HeaderStyle).Text("Item Code");
                    header.Cell().Element(HeaderStyle).Text("Description");
                    header.Cell().Element(HeaderStyle).AlignCenter().Text("Qty");
                    header.Cell().Element(HeaderStyle).AlignCenter().Text("UOM");
                    header.Cell().Element(HeaderStyle).AlignRight().Text("Unit Price");
                    header.Cell().Element(HeaderStyle).AlignRight().Text("Tax %");
                    header.Cell().Element(HeaderStyle).AlignRight().Text("Total");

                    IContainer HeaderStyle(IContainer c) => c
                        .Background(Colors.Orange.Darken2)
                        .Padding(4)
                        .DefaultTextStyle(x => x.FontSize(8).SemiBold().FontColor(Colors.White));
                });

                foreach (var item in Model.Items)
                {
                    table.Cell().Element(CellStyle).Text(item.ItemNo.ToString());
                    table.Cell().Element(CellStyle).Text(item.ItemCode);
                    table.Cell().Element(CellStyle).Text(item.Description);
                    table.Cell().Element(CellStyle).AlignCenter().Text(item.Quantity.ToString());
                    table.Cell().Element(CellStyle).AlignCenter().Text(item.UnitOfMeasure);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.UnitPrice:N2}");
                    table.Cell().Element(CellStyle).AlignCenter().Text($"{item.TaxPercent:N0}%");
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.TotalWithTax:N2}");

                    IContainer CellStyle(IContainer c) => c
                        .Border(1)
                        .BorderColor(Colors.Grey.Lighten2)
                        .Padding(4)
                        .DefaultTextStyle(x => x.FontSize(8));
                }
            });

            column.Item().AlignRight().Column(col =>
            {
                col.Spacing(5);

                col.Item().Width(280).Border(1).BorderColor(Colors.Grey.Lighten2).Padding(6).Row(row =>
                {
                    row.RelativeItem().Text("Subtotal").FontSize(10);
                    row.AutoItem().Text($"BHD {Model.Subtotal:N2}").FontSize(10);
                });

                col.Item().Width(280).Border(1).BorderColor(Colors.Grey.Lighten2).Padding(6).Row(row =>
                {
                    row.RelativeItem().Text("Tax Amount").FontSize(10);
                    row.AutoItem().Text($"BHD {Model.TaxAmount:N2}").FontSize(10);
                });

                col.Item().Width(280).Background(Colors.Orange.Darken2).Padding(8).Row(row =>
                {
                    row.RelativeItem().Text("Total Amount").FontSize(11).SemiBold().FontColor(Colors.White);
                    row.AutoItem().Text($"BHD {Model.TotalAmount:N2}").FontSize(12).Bold().FontColor(Colors.White);
                });
            });

            column.Item().PaddingTop(10).Row(row =>
            {
                if (!string.IsNullOrEmpty(Model.PaymentTerms))
                {
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text("Payment Terms").FontSize(9).SemiBold();
                        col.Item().Text(Model.PaymentTerms).FontSize(9);
                    });
                    row.ConstantItem(20);
                }

                if (!string.IsNullOrEmpty(Model.DeliveryTerms))
                {
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text("Delivery Terms").FontSize(9).SemiBold();
                        col.Item().Text(Model.DeliveryTerms).FontSize(9);
                    });
                }
            });

            if (!string.IsNullOrEmpty(Model.SpecialInstructions))
            {
                column.Item().Background(Colors.Grey.Lighten4).Padding(8).Column(col =>
                {
                    col.Item().Text("Special Instructions").FontSize(9).SemiBold();
                    col.Item().Text(Model.SpecialInstructions).FontSize(8);
                });
            }

            if (!string.IsNullOrEmpty(Model.TermsAndConditions))
            {
                column.Item().Border(1).BorderColor(Colors.Grey.Lighten1).Padding(8).Column(col =>
                {
                    col.Item().Text("Terms & Conditions").FontSize(9).SemiBold();
                    col.Item().Text(Model.TermsAndConditions).FontSize(7).LineHeight(1.2f);
                });
            }

            column.Item().PaddingTop(15).Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().BorderTop(1).BorderColor(Colors.Black).PaddingTop(5)
                        .Text("Prepared By").FontSize(9).SemiBold();
                    col.Item().Text(Model.PreparedBy).FontSize(9);
                });

                row.ConstantItem(50);

                row.RelativeItem().Column(col =>
                {
                    col.Item().BorderTop(1).BorderColor(Colors.Black).PaddingTop(5)
                        .Text("Approved By").FontSize(9).SemiBold();
                    if (!string.IsNullOrEmpty(Model.ApprovedBy))
                        col.Item().Text(Model.ApprovedBy).FontSize(9);
                });

                row.ConstantItem(50);

                row.RelativeItem().Column(col =>
                {
                    col.Item().BorderTop(1).BorderColor(Colors.Black).PaddingTop(5)
                        .Text("Date").FontSize(9).SemiBold();
                });
            });
        });
    }

    void ComposeFooter(IContainer container)
    {
        container.BorderTop(1).BorderColor(Colors.Grey.Lighten1).PaddingTop(5).Row(row =>
        {
            row.RelativeItem().Text("This is a computer-generated purchase order.")
                .FontSize(7).Italic().FontColor(Colors.Grey.Darken1);

            row.AutoItem().DefaultTextStyle(x => x.FontSize(8)).Text(text =>
            {
                text.Span("Page ");
                text.CurrentPageNumber();
                text.Span(" of ");
                text.TotalPages();
            });
        });
    }
}
