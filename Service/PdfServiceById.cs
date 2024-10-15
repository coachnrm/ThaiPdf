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
                var table = new Table(UnitValue.CreatePercentArray(3)).UseAllAvailableWidth();

                document.Add(new Paragraph(person.Name).SetFontSize(20).SetFont(font));
                document.Add(new Paragraph(person.Occupation).SetFont(font));

                
            }

            return await Task.FromResult(memoryStream.ToArray());
        }
    }
    }
}