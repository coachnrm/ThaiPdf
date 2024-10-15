using System.IO;
using System.Threading.Tasks;
using iText.Commons.Actions.Data;
using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using PdfTest.Models;

namespace PdfTest.Service
{
    public class PdfService
    {
    public async Task<byte[]> GeneratePdfAsync(string Title, string Content, List<Person> persons)
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
                var table = new Table(UnitValue.CreatePercentArray(3)).UseAllAvailableWidth();

                document.Add(new Paragraph(Title).SetFontSize(20).SetFont(font));
                document.Add(new Paragraph(Content).SetFont(font));

                // Add header cells
                table.AddHeaderCell("Id");
                table.AddHeaderCell("ชื่อ").SetFont(font);
                table.AddHeaderCell("อาชีพ").SetFont(font);

                // // Add data cells
                // for (int i = 1; i <= 5; i++)
                // {
                //     table.AddCell($"Row {i}, Cell 1");
                //     table.AddCell($"Row {i}, Cell 2");
                //     table.AddCell($"Row {i}, Cell 3");
                // }

                // Add data cells
                foreach (var person in persons)
                {
                    table.AddCell($"{person.Id}");
                    table.AddCell($"{person.Name}");
                    table.AddCell($"{person.Occupation}");
                }

                // Add the table to the document
                document.Add(table);
                
            }

            return await Task.FromResult(memoryStream.ToArray());
        }
    }

     
    }
}