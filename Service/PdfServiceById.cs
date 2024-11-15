using System.IO;
using System.Threading.Tasks;
using iText.Commons.Actions.Data;
using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using PdfTest.Models;

namespace PdfTest.Service
{
    public class PdfServiceById
    {
        public async Task<byte[]> GeneratePdfAsync(Person person)
    {
        using (var memoryStream = new MemoryStream())
        {
            using (var writer = new PdfWriter(memoryStream))
            using (var pdf = new PdfDocument(writer))
            using (var document = new Document(pdf))
            {
                 // Load a font (update the path to your font)
                var fontPath = Path.Combine("wwwroot", "fonts", "NotoSans-Regular.ttf");
                var font = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H);
                
                // Create a table with 3 columns
                var table = new Table(UnitValue.CreatePercentArray(2)).UseAllAvailableWidth();

                // Add table headers (optional)
                table.AddHeaderCell(new Cell().Add(new Paragraph("Field").SetFont(font).SetBold()));
                table.AddHeaderCell(new Cell().Add(new Paragraph("Value").SetFont(font).SetBold()));
                
                // Add rows for Name and Occupation
                table.AddCell(new Cell().Add(new Paragraph("Name").SetFont(font)));
                table.AddCell(new Cell().Add(new Paragraph(person.Name).SetFont(font)));
                
                table.AddCell(new Cell().Add(new Paragraph("Occupation").SetFont(font)));
                table.AddCell(new Cell().Add(new Paragraph(person.Occupation).SetFont(font)));

                // Add table to the document
                document.Add(table);
                
                document.Add(new Paragraph(person.Name).SetFontSize(20).SetFont(font));
                document.Add(new Paragraph(person.Occupation).SetFont(font));

            }

            return await Task.FromResult(memoryStream.ToArray());
        }
    }
    }
}