using Microsoft.AspNetCore.Mvc;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Text;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.html;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.parser;
using HTMLTOPDF.Models;
using DinkToPdf; // For Encoding if needed

namespace HTMLTOPDF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ITextCharpController : ControllerBase
    {
        [HttpGet]
        public IActionResult CreatePDF()
        {
            // Initialize a MemoryStream to eventually hold the PDF bytes
            using (var memoryStream = new MemoryStream())
            {
                // Initialize a document with A4 page size
                using (var document = new Document(PageSize.A4))
                {
                    // Get the path to the CSS file
                    var cssPath = GetStyleSheetPath();
                    var cssFile = System.IO.File.ReadAllText(cssPath);

                    // Use the XMLWorker to parse HTML and CSS
                    var cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(false);
                    cssResolver.AddCss(cssFile, "utf-8", true);

                    // Create a pipeline for HTML and CSS
                    var cssPipeline = new CssResolverPipeline(cssResolver,
                        new HtmlPipeline(new HtmlPipelineContext(null), new PdfWriterPipeline(document, PdfWriter.GetInstance(document, memoryStream))));

                    // Initialize XMLWorker and XMLParser
                    var worker = new XMLWorker(cssPipeline, true);
                    var parser = new XMLParser(worker);

                    // Get HTML content from settings
                    string htmlContent = GetObjectSettings().HtmlContent;

                    // Parse HTML into the document
                    using (var stringReader = new StringReader(htmlContent))
                    {
                        parser.Parse(stringReader);
                    }
                }

                // Reset the position of the memory stream to the beginning
                memoryStream.Seek(0, SeekOrigin.Begin);

                // Return the generated PDF file
                return File(memoryStream.ToArray(), "application/pdf", "Employee_Report.pdf");
            }
        }

        private ObjectSettings GetObjectSettings()
        {
            
            return new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GetHTMLString(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = GetStyleSheetPath() },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 1.8, HtmUrl = "https://example.com/header.html" },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };
        }
        private GlobalSettings GetGlobalSettings()
        {
            return new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 20, Bottom = 10, Left = 10, Right = 10 }, // Adjust margins as needed
                DocumentTitle = "PDF Report",
                Out = @"D:\PDFCreator\Employee_Report.pdf"
            };
        }
        // Helper method to get the path of the stylesheet
        private string GetStyleSheetPath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css");
        }
    }
}
