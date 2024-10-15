using System.IO;
using System.Threading.Tasks;
using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace PdfTest.Service
{
    public class PdfService
    {
    public async Task<byte[]> GeneratePdfAsync(string title, string content)
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

                document.Add(new Paragraph(title).SetFontSize(20).SetFont(font));
                document.Add(new Paragraph(content).SetFont(font));
            }

            return await Task.FromResult(memoryStream.ToArray());
        }
    }

     
    }
}