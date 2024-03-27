using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using WkHtmlToXSharp;

namespace HTMLTOPDF.Models
{
    public class PdfGenerator
    {
        public void GeneratePdf(string outputPath, string htmlContent)
        {
            // Create a new PDF document
            PdfDocument document = new PdfDocument();

            // Add a page to the document
            PdfPage page = document.AddPage();

            // Set page settings if needed (e.g., size, orientation)
            // page.Size = PageSize.A4;
            // page.Orientation = PdfSharpCore.PageOrientation.Portrait;

            // Create a graphics object for drawing on the page
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create a temporary file to store HTML content
            string tempHtmlFilePath = Path.GetTempFileName();

            try
            {
                // Write the HTML content to the temporary file
                File.WriteAllText(tempHtmlFilePath, htmlContent);

                // Convert HTML to PDF using WkHtmlToPdf
                var converter = new WkHtmlToPdfConverter();
                //converter.Convert(new PdfDocument(), page, tempHtmlFilePath);

                // Save the PDF document to the specified output path
                document.Save(outputPath);
            }
            finally
            {
                // Cleanup: delete the temporary file
                File.Delete(tempHtmlFilePath);
            }
        }
    }
}
