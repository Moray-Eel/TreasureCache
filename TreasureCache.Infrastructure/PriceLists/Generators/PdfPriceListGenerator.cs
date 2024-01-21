using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using TreasureCache.Infrastructure.PriceLists.Constants;
using TreasureCache.Infrastructure.Queries.Products.Dtos;

namespace TreasureCache.Infrastructure.PriceLists.Generators;

public class PdfPriceListGenerator : IPriceListGenerator
{
    public IList<ProductWithCategoryDto> Products { get; set; }
    public Stream Generate(IList<ProductWithCategoryDto> products)
    {
        Products = products;
        var pdf = Document.Create(document =>
        {
            document.Page(page =>
            {
                page.Margin(2, Unit.Centimetre);
                page.Size(PageSizes.A4);

                page.Header().Element(Header);
                page.Content().Element(Content);
                page.Footer().Element(Footer);

            });
        }).GeneratePdf();
        
        return new MemoryStream(pdf);
    }
    void Header(IContainer container)
    {
        container.Height(50)
            .AlignCenter()
            .Row(row =>
            {
                row.RelativeItem().Text(DocumentText.Header)
                    .FontSize(20)
                    .Bold();
            });
    }
    void Content(IContainer container)
    {
        container.PaddingVertical(25).Table(table =>
        {
            table.ColumnsDefinition(columns =>
            {
                columns.ConstantColumn(50);
                columns.RelativeColumn();
                columns.ConstantColumn(50);
                columns.ConstantColumn(100);
                columns.ConstantColumn(100);
            });
        
            table.Header(header =>
            {
                header.Cell().Border(1).PaddingLeft(5).Text(DocumentText.Id).Bold().FontSize(16);;
                header.Cell().Border(1).PaddingLeft(5).Text(DocumentText.Name).Bold().FontSize(16);;
                header.Cell().Border(1).PaddingLeft(5).Text(DocumentText.Price).Bold().FontSize(16);;
                header.Cell().Border(1).PaddingLeft(5).AlignCenter().Text(DocumentText.Discount).Bold().FontSize(16);;
                header.Cell().Border(1).PaddingLeft(5).AlignCenter().Text(DocumentText.Category).Bold().FontSize(16);
            });

            foreach (var product in Products)
            {
                table.Cell().Border(1).PaddingLeft(5).Text($"{product.Id}");
                table.Cell().Border(1).PaddingLeft(5).Text($"{product.Name}");
                table.Cell().Border(1).PaddingLeft(5).Text($"{product.BasePrice}");
                table.Cell().Border(1).PaddingLeft(5).AlignCenter().Text($"{product.Discount}%");
                table.Cell().Border(1).PaddingLeft(5).AlignCenter().Text($"{product.Category.Name}");
            }
        });
    
    }
    void Footer(IContainer container)
    {
        container.AlignCenter().Text(text =>
        {
            text.Span(DocumentText.Page);
            text.CurrentPageNumber();
            text.Span(DocumentText.Of);
            text.TotalPages();
        });
    }
}