using System.Globalization;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using TreasureCache.Infrastructure.PriceLists.Constants;
using TreasureCache.Infrastructure.Queries.Products.Dtos;

namespace TreasureCache.Infrastructure.PriceLists.Generators;

public class ExcelPriceListGenerator : IPriceListGenerator
{
    public IList<ProductWithCategoryDto> Products { get; set; }

    public Stream Generate(IList<ProductWithCategoryDto> products)
    {
        Products = products;
        var stream = new MemoryStream();
        using var package = new ExcelPackage(stream);
        
        var worksheet = package.Workbook.Worksheets.Add("Price List");
        
        var all = worksheet.Cells["A:E"];
        all.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        
        Header(worksheet);
        Table(worksheet);
        
        all.AutoFitColumns();
        package.Save();
        
        stream.Position = 0;
        return stream;
    }

    private void Header(ExcelWorksheet sheet)
    {
        var header = sheet.Cells["A1:E1"];
        header.Value = DocumentText.Header;
        header.Merge = true;
        header.Style.Font.Bold = true;
    }
    
    private void HeaderCell(ExcelWorksheet sheet, string cellDiscrimnator, string text)
    {
        var cell = sheet.Cells[cellDiscrimnator];
        cell.Value = text;
        cell.Style.Font.Bold = true;
    }

    private void Table(ExcelWorksheet sheet)
    {
        HeaderCell(sheet, "A2", DocumentText.Id);                        
        HeaderCell(sheet, "B2", DocumentText.Name);
        HeaderCell(sheet, "C2", DocumentText.Price);
        HeaderCell(sheet, "D2", DocumentText.Discount);
        HeaderCell(sheet, "E2", DocumentText.Category);

        var row = 3;
        for (var i = 0; i < Products.Count; i++)
        {
            sheet.Cells[i + row, 1].Value = Products[i].Id.ToString();
            sheet.Cells[i + row, 2].Value = Products[i].Name;
                
            sheet.Cells[i + row, 1].Style.Numberformat.Format = "#,##0"; // Number format

            sheet.Cells[i + row, 3].Value = Products[i].BasePrice.ToString(CultureInfo.InvariantCulture);
            sheet.Cells[i + row, 3].Style.Numberformat.Format = "$#,##0.00"; // Currency format

            sheet.Cells[i + row, 4].Value = ((double)Products[i].Discount).ToString();
            sheet.Cells[i + row, 4].Style.Numberformat.Format = "0.00%"; // Percent format

            sheet.Cells[i + row, 5].Value = Products[i].Category.Name;
        }
    }
}