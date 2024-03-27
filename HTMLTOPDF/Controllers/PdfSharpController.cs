using HtmlRendererCore.PdfSharp;
using HTMLTOPDF.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Text;

namespace HTMLTOPDF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfSharpController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPdf()
        {
            //using (var document = new PdfDocument())
            //{
            //    var page = document.AddPage();
            //    var gfx = XGraphics.FromPdfPage(page);
            //    var font = new XFont("Verdana", 20, XFontStyle.Bold);

            //    gfx.DrawString(GetHTMLString(), font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);

            //    var pdfStream = new System.IO.MemoryStream();
            //    document.Save(pdfStream, false);
            //    pdfStream.Position = 0;

            //    return File(pdfStream, "application/pdf", "example.pdf");
            //}

            // Get HTML content dynamically
            string htmlContent = GetHTMLString();

            // Path to save the PDF file
            string pdfFilePath = "output.pdf";

            // Generate the PDF
            Models.PdfGenerator pdfGenerator = new Models.PdfGenerator();
            pdfGenerator.GeneratePdf(pdfFilePath, htmlContent);

            // Return the PDF file
            byte[] pdfBytes = System.IO.File.ReadAllBytes(pdfFilePath);
            return File(pdfBytes, "application/pdf", "output.pdf");

        }

        //}
        //public async Task<IActionResult> GetPdf()
        //{
        //    // Initialize browser fetcher
        //    var browserFetcher = new BrowserFetcher();

        //    // Download the latest available revision of Chromium
        //    var revisionInfo = await browserFetcher.DownloadAsync();

        //    // Launch Puppeteer with the downloaded revision
        //    var browser = await Puppeteer.LaunchAsync(new LaunchOptions
        //    {
        //        Headless = true,
        //        ExecutablePath = revisionInfo.GetExecutablePath()
        //    });

        //    // Create a new page
        //    var page = await browser.NewPageAsync();

        //    // Get the HTML content
        //    string htmlContent = GetHTMLString();

        //    // Set the content of the page to the HTML content
        //    await page.SetContentAsync(htmlContent);

        //    // Path to save the PDF file temporarily
        //    string pdfPath = Path.Combine(Path.GetTempPath(), "example.pdf");

        //    // Generate the PDF
        //    await page.PdfAsync(pdfPath);

        //    // Close the browser
        //    await browser.CloseAsync();

        //    // Read the generated PDF file and return it as a FileStreamResult
        //    var pdfStream = new FileStream(pdfPath, FileMode.Open);
        //    return File(pdfStream, "application/pdf", "example.pdf");
        //}
        // No
        //public async Task<IActionResult> GetPdf()
        //{
        //    try
        //    {
        //        // Initialize browser fetcher
        //        using var browserFetcher = new BrowserFetcher();

        //        // Download the latest available revision of Chromium
        //        var revisionInfo = await browserFetcher.DownloadAsync();

        //        // Launch Puppeteer with the downloaded revision
        //        using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
        //        {
        //            Headless = true,
        //            ExecutablePath = revisionInfo.GetExecutablePath()
        //        });

        //        // Create a new page
        //        await using var page = await browser.NewPageAsync();

        //        // Get the HTML content
        //        string htmlContent = GetHTMLString();

        //        // Set the content of the page to the HTML content
        //        await page.SetContentAsync(htmlContent);

        //        // Path to save the PDF file temporarily
        //        string pdfPath = Path.Combine(Path.GetTempPath(), "example.pdf");

        //        // Generate the PDF asynchronously
        //        await page.PdfAsync(pdfPath);

        //        // Open the PDF file as a FileStream
        //        using var pdfStream = new FileStream(pdfPath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);

        //        // Return the PDF file as a FileStreamResult without loading it into memory
        //        return File(pdfStream, "application/pdf", "example.pdf");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exceptions
        //        // You can log the exception for debugging purposes
        //        Console.WriteLine($"An error occurred while generating the PDF: {ex.Message}");
        //        return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while generating the PDF.");
        //    }
        //}

        //public IActionResult GetPdf()
        //{
        //    // Get HTML content dynamically
        //    string htmlContent = GetHTMLString();

        //    // Path to the WkHtmlToPdf executable
        //    string wkHtmlToPdfPath = "path/to/wkhtmltopdf.exe";

        //    // Path to save the temporary HTML file
        //    string htmlFilePath = "temp.html";

        //    // Path to save the PDF file
        //    string pdfFilePath = "temp.pdf";

        //    try
        //    {
        //        // Write HTML content to a temporary file
        //        System.IO.File.WriteAllText(htmlFilePath, htmlContent);

        //        // Command to convert HTML to PDF
        //        string command = $"\"{wkHtmlToPdfPath}\" \"{htmlFilePath}\" \"{pdfFilePath}\"";

        //        // Execute the command
        //        ProcessStartInfo psi = new ProcessStartInfo
        //        {
        //            FileName = "cmd.exe",
        //            RedirectStandardInput = true,
        //            UseShellExecute = false
        //        };

        //        Process process = Process.Start(psi);
        //        process.StandardInput.WriteLine(command);
        //        process.WaitForExit();

        //        // Return the PDF file
        //        byte[] pdfBytes = System.IO.File.ReadAllBytes(pdfFilePath);
        //        return File(pdfBytes, "application/pdf", "output.pdf");
        //    }
        //    finally
        //    {
        //        // Clean up temporary files
        //        System.IO.File.Delete(htmlFilePath);
        //        System.IO.File.Delete(pdfFilePath);
        //    }
        //}




        private static string GetStyleSheetPath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css");
        }
        public static List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();
            for (int i = 1; i <= 5000; i++)
            {
                employees.Add(new Employee
                {
                    NameRonak = "Employee" + i,
                    LastName = "Lastname" + i,
                    Age = 25 + i % 20, // just an example for varying age
                    Gender = i % 2 == 0 ? "Male" : "Female" // alternate gender
                });
            }
            return employees;
        }
        public static string GetHTMLString()
        {
            var employees = GetAllEmployees();
            var sb = new StringBuilder();
            sb.Append(@"
        <html>
            <head>
                <link rel='stylesheet' type='text/css' href='" + GetStyleSheetPath() + @"'>
            </head>
            <body>
                <div class='header'><h1>This is the generated PDF report!!!</h1></div>
                <table align='center'>
                    <tr>");

            // Generate table headers dynamically based on Employee properties
            foreach (var property in typeof(Employee).GetProperties())
            {
                var displayNameAttribute = (DisplayNameAttribute)Attribute.GetCustomAttribute(property, typeof(DisplayNameAttribute));
                string displayName = displayNameAttribute != null ? displayNameAttribute.DisplayName : property.Name;
                sb.AppendFormat("<th>{0}</th>", displayName);
            }

            // Add extra column for the icon
            sb.Append("<th>Icon</th></tr>");

            // Generate table data rows dynamically
            foreach (var emp in employees)
            {
                sb.Append("<tr>");
                foreach (var property in typeof(Employee).GetProperties())
                {
                    sb.AppendFormat("<td>{0}</td>", property.GetValue(emp));
                }
                // Add SVG icon column
                sb.Append("<td><svg height='16' viewBox='0 0 16 16' width='16' xmlns='http://www.w3.org/2000/svg'><path d='m12.2417871 6.58543288-5.97153941 5.97295362c-.32039706.3203971-.72184675.5476941-1.16142789.6575893l-2.29099929.5727499c-.36619024.0915475-.69788662-.2401489-.60633907-.6063391l.57274983-2.2909993c.10989528-.4395811.33719224-.8410308.65758929-1.16142788l5.97153945-5.97295366zm1.4149207-4.24193358c.7810486.78104859.7810486 2.04737855 0 2.82842713l-.7078139.70639967-2.8284271-2.82842712.7078139-.70639968c.7810486-.78104858 2.0473785-.78104858 2.8284271 0z' fill='#212121'/></svg></td>");
                sb.Append("</tr>");
            }

            sb.Append(@"
                </table>
            </body>
        </html>");
            return sb.ToString();
        }
    }
}
