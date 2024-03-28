using DinkToPdf;
using DinkToPdf.Contracts;
using HTMLTOPDF.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.util;

namespace HTMLTOPDF.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class PdfCreatorController : ControllerBase
    {
        private IConverter _converter;
        public PdfCreatorController(IConverter converter)
        {
            _converter = converter;
        }
        [HttpGet]
        public async Task<IActionResult> CreatePDF()
        {
            try
            {
                var globalSettings = GetGlobalSettings();
                var objectSettings = GetObjectSettings();

                var pdf = new HtmlToPdfDocument
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };

                // Asynchronously convert HTML to PDF
                await Task.Run(() => _converter.Convert(pdf));

                // Return success message
                return Ok("Successfully created PDF document.");
            }
            catch (Exception ex)
            {
                // Return error message if an exception occurs
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        //[HttpGet] 
        //public IActionResult CreatePDF()
        //{
        //    // Define global settings for the PDF
        //    var globalSettings = GetGlobalSettings();

        //    // Define object settings for HTML content
        //    var objectSettings = GetObjectSettings();

        //    // Generate PDF document
        //    var pdf = new HtmlToPdfDocument
        //    {
        //        GlobalSettings = globalSettings,
        //        Objects = { objectSettings }
        //    };

        //    // Convert HTML to PDF
        //    _converter.Convert(pdf);

        //    // Return success message
        //    return Ok("Successfully created PDF document.");
        //}

        // Helper method to get global settings for the PDF
        private GlobalSettings GetGlobalSettings()
        {
            return new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 40, Bottom = 10, Left = 10, Right = 10 }, // Adjust margins as needed
                DocumentTitle = "PDF Report",
                Out = @"D:\PDFCreator\Employee_Report.pdf"
            };
        }

        // Helper method to get object settings for HTML content
        private ObjectSettings GetObjectSettings()
        {
            

            return new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GetHTMLString(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = GetStyleSheetPath() },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 1.8, HtmUrl = Path.Combine(Directory.GetCurrentDirectory(), "assets", "htmlpage.html") },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };
        }

        // Helper method to get the path of the stylesheet
        private string GetStyleSheetPath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css");
        }


    }
}
