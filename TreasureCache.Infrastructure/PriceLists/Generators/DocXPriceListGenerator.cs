using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using TreasureCache.Infrastructure.PriceLists.Constants;
using TreasureCache.Infrastructure.Queries.Products.Dtos;

namespace TreasureCache.Infrastructure.PriceLists.Generators;

public class DocXPriceListGenerator : IPriceListGenerator
{
    public IList<ProductWithCategoryDto> Products { get; set; }

    public Stream Generate(IList<ProductWithCategoryDto> products)
    {
        Products = products;
        
        MemoryStream stream = new MemoryStream();
        using(var wordDocument = WordprocessingDocument.Create(stream, WordprocessingDocumentType.Document, true))
        {
            MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
            mainPart.Document = new Document();
            Body body = mainPart.Document.AppendChild(new Body());

            Header(body);
            Content(body);
        }
        
        stream.Position = 0; 
        return stream;
    }

    private void Header(Body body)
    {
        Run titleRun = new Run(new Text(DocumentText.Header))
        {
            RunProperties = new RunProperties(
                new Bold(),
                new FontSize() { Val = "28" }) // Font size is in half-points
        };

        Paragraph titlePara = body.AppendChild(new Paragraph(titleRun));
        titlePara.ParagraphProperties = new ParagraphProperties(
            new Justification() { Val = JustificationValues.Center });
    }
    private void Content(Body body)
    {
         Table table = new Table();

        // Set table properties (borders, alignment)
        TableProperties tblProperties = new TableProperties(
            new TableBorders(
                new TopBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                new BottomBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                new LeftBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                new RightBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                new InsideHorizontalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                new InsideVerticalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 }),
            new TableJustification() { Val = TableRowAlignmentValues.Center }); 
       
        table.AppendChild(tblProperties);
        
        TableRow headerRow = new TableRow();

        headerRow.Append(HeaderCell(DocumentText.Id));
        headerRow.Append(HeaderCell(DocumentText.Name));
        headerRow.Append(HeaderCell(DocumentText.Price));
        headerRow.Append(HeaderCell(DocumentText.Discount));
        headerRow.Append(HeaderCell(DocumentText.Category));
        
        table.AppendChild(headerRow);

        // Add data rows with centered text
        foreach (var product in Products)
        {
            TableRow row = new TableRow();
            row.Append(TableCell($"{product.Id}"));
            row.Append(TableCell($"{product.Name}"));
            row.Append(TableCell($"{product.BasePrice}$"));
            row.Append(TableCell($"{product.Discount}%"));
            row.Append(TableCell($"{product.Category.Name}"));
            table.AppendChild(row);
        }
        body.AppendChild(table);
    }
    
    private TableCell HeaderCell(string text)
    {
        TableRow headerRow = new TableRow();
       
        Paragraph headerParagraph = new Paragraph
        {
            ParagraphProperties = new ParagraphProperties(
                new Justification() { Val = JustificationValues.Center })
        };

        Run headerRun = new Run(new Text(text))
        {
            RunProperties = new RunProperties(new Bold())
        };
        headerParagraph.AppendChild(headerRun);
        
        return new TableCell(headerParagraph)
        {
            TableCellProperties = new TableCellProperties
            {
                TableCellMargin = new TableCellMargin
                {
                    LeftMargin = new LeftMargin { Width = "100", Type = TableWidthUnitValues.Dxa },
                    RightMargin = new RightMargin { Width = "100", Type = TableWidthUnitValues.Dxa }
                }
            }
        };
    }

    private TableCell TableCell(string text)
    {
        Paragraph cellPara = new Paragraph(new Run(new Text(text)))
        {
            ParagraphProperties = new ParagraphProperties(
                new Justification() { Val = JustificationValues.Center })
        };
        return new TableCell(cellPara)
        {
            TableCellProperties = new TableCellProperties
            {
                TableCellMargin = new TableCellMargin
                {
                    LeftMargin = new LeftMargin { Width = "100", Type = TableWidthUnitValues.Dxa },
                    RightMargin = new RightMargin { Width = "100", Type = TableWidthUnitValues.Dxa }
                }
            }
        };
    }
}