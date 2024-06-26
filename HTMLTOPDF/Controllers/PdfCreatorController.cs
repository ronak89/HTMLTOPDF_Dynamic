﻿using DinkToPdf;
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
        [HttpPost]   
        public IActionResult CreatePDF([FromBody] ParentHeader parentHeader)
        {
            try
            {
                string html = "";
                PdfSettings settings = new PdfSettings
                {
                    headerSettings = {HtmUrl=html},
                    footerSettings = {HtmUrl=html},
                    webSettings = {},
                    ownGlobalSettings = {}

                };
                OwnPdfGenerates ownPdfGenerates = new OwnPdfGenerates();

                byte[] pdfBytes = ownPdfGenerates.GeneratePdf(settings, html);

                // Assuming you want to return the PDF as a file
                return File(pdfBytes, "application/pdf", "output.pdf");

                //var globalSettings = GetGlobalSettings();
                //var objectSettings = GetObjectSettings(parentHeader);

                //var pdf = new HtmlToPdfDocument
                //{
                //    GlobalSettings = globalSettings,
                //    Objects = { objectSettings }
                //};

                //// Asynchronously convert HTML to PDF
                //await Task.Run(() => _converter.Convert(pdf));

                //// Return success message
                //return Ok("Successfully created PDF document.");
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
                Margins = new MarginSettings { Top = 100, Bottom = 10, Left = 10, Right = 10 }, // Adjust margins as needed
                DocumentTitle = "PDF Report",
                Out = @"D:\PDFCreator\Employee_Report.pdf"
            };
        }


        private GlobalHtmlTags GetHtmlTags()
        {
            return new GlobalHtmlTags
            {
                Tag = HtmlTag.Head,
                Heading1 = HtmlTag.Heading1,

            };
        }




        // Helper method to get object settings for HTML content
        private ObjectSettings GetObjectSettings(ParentHeader userHeaderParam)
        {
            string headingString = string.Empty;
            string imagePath = string.Empty;
            var userParamHeader = userHeaderParam.HeaderParameters;

            int height = 200; // Example height
            int width = 300; // Example width
            string imgTag = string.Empty;

            foreach (var userParam in userParamHeader)
            {
                string style = $"font-size: {userParam.FontSize}; color: {userParam.FontColor};";

                // Split the Title string by commas
                //string[] titles = userParam.Title;
                //string titleString = string.Join(",", titles); // Concatenate array elements into a single string
                //string[] splittedTitles = titleString.Split(','); // Split the concatenated string

                string titleString = string.Join(",", userParam.Title); // Concatenate array elements into a single string
                string[] splittedTitles = titleString.Split(','); // Split the concatenated string


                // Iterate over each title and create a div element
                foreach (var title in splittedTitles)
                {
                    headingString += $"<div style=\"{style}\">{title}</div>";
                }

                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "assets", userParam.Image);
                imgTag = $"<img src=\"{imagePath}\" alt=\"Italian Trulli\" height=\"{height}\" width=\"{width}\">";

                
               
            }

            //// HTML content for the header
            //GlobalHtmlTags htmlTags = GetHtmlTags();
            //// Define styles for the heading
            //var styles = new Dictionary<CssProperty, string>
            //    {
            //        { CssProperty.Color, "blue" },
            //        { CssProperty.FontSize, "24px" }
            //    };
            //// Generate the heading HTML with styles
            //string headingHtml = HtmlGenerator.GenerateHtml(htmlTags.Heading1, "Document Title", styles);


            string headerHtml = $@"<!DOCTYPE html>
                                    <html>
                                    <head>
                                        <title>Header</title>
                                        <style>
                                            .header-container {{
                                                display: flex;
                                                justify-content: space-between;
                                                font-family: Arial;
                                                font-size: 9pt;
                                            }}
                                            .left-content, .right-content {{
                                                display: flex;
                                                flex-direction: column;
                                                justify-content: center;
                                            }}
                                            .right-content {{
                                                align-items: flex-end;
                                            }}
                                            svg {{
                                                margin-top: 10px;
                                            }}
                                        </style>
                                    </head>
                                    <body>
                    <div class=""header-container"">
                        <div class=""left-content"">
                            {headingString}
                            <p>This is a custom header for the document. It beautifully encapsulates the essence of dynamic page numbering alongside a simplistic SVG illustration.</p>
                        </div>
                        <div class=""right-content"">
                            <div>Page [page] of [toPage]</div>
                           {imgTag}
                        
                        </div>
                    </div>
                    </body>
                    </html>";


            //string headerHtml = $@"<!DOCTYPE html>
            //                        <html>
            //                        <head>
            //                            <title>Header</title>
            //                            <style>
            //                                .header-container {{
            //                                    display: flex;
            //                                    justify-content: space-between;
            //                                    font-family: Arial;
            //                                    font-size: 9pt;
            //                                }}
            //                                .left-content, .right-content {{
            //                                    display: flex;
            //                                    flex-direction: column;
            //                                    justify-content: center;
            //                                }}
            //                                .right-content {{
            //                                    align-items: flex-end;
            //                                }}
            //                                svg {{
            //                                    margin-top: 10px;
            //                                }}
            //                            </style>
            //                        </head>
            //                        <body>
            //        <div class=""header-container"">
            //            <div class=""left-content"">
            //                <div>ABCD</div>
            //                <p>This is a custom header for the document. It beautifully encapsulates the essence of dynamic page numbering alongside a simplistic SVG illustration.</p>
            //            </div>
            //            <div class=""right-content"">
            //                <div>Page [page] of [toPage]</div>
            //                <svg width=""100"" height=""100"" xmlns=""http://www.w3.org/2000/svg"">
            //                    <circle cx=""50"" cy=""50"" r=""40"" stroke=""green"" stroke-width=""4"" fill=""yellow"" />
            //                </svg>
            //            </div>
            //        </div>
            //        </body>
            //        </html>";




            // Path to save the HTML file
            string filePath = "header.html";

            // Write the HTML content to a file
            System.IO.File.WriteAllText(filePath, headerHtml);

            // Assign the file URL to the HtmUrl property
            string htmUrls = Path.GetFullPath(filePath);


            return new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GetHTMLString(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = GetStyleSheetPath() },
                //HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 1.8, HtmUrl = Path.Combine(Directory.GetCurrentDirectory(), "assets", "htmlpage.html") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Line = true, Spacing = 1.8, HtmUrl = htmUrls },
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
