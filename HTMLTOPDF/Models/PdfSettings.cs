using DinkToPdf.Contracts;
using DinkToPdf;
using System.Globalization;

namespace HTMLTOPDF.Models
{
    public class PdfSettings
    {
        public PdfSettings()
        {
            webSettings = new OwnWebSettings();
            headerSettings = new OwnHeaderSettings();
            footerSettings = new OwnFooterSettings();
            ownGlobalSettings = new OwnGlobalSettings();


        }


        public OwnWebSettings webSettings = new OwnWebSettings();

        public OwnHeaderSettings headerSettings = new OwnHeaderSettings();

        public OwnFooterSettings footerSettings = new OwnFooterSettings();

        public OwnGlobalSettings ownGlobalSettings = new OwnGlobalSettings();


    }

    public class OwnFooterSettings
    {
        //
        // Summary:
        //     The font size to use for the footer. Default = 12
        public int? FontSize { get; set; }

        //
        // Summary:
        //     The name of the font to use for the footer. Default = "Ariel"
        public string FontName { get; set; }

        //
        // Summary:
        //     The string to print in the left part of the footer, note that some sequences
        //     are replaced in this string, see the wkhtmltopdf manual. Default = ""
        public string Left { get; set; }

        //
        // Summary:
        //     The text to print in the right part of the footer, note that some sequences are
        //     replaced in this string, see the wkhtmltopdf manual. Default = ""
        public string Center { get; set; }

        //
        // Summary:
        //     The text to print in the right part of the footer, note that some sequences are
        //     replaced in this string, see the wkhtmltopdf manual. Default = ""
        public string Right { get; set; }

        //
        // Summary:
        //     Whether a line should be printed above the footer. Default = false
        public bool? Line { get; set; }

        //
        // Summary:
        //     The amount of space to put between the footer and the content, e.g. "1.8". Be
        //     aware that if this is too large the footer will be printed outside the pdf document.
        //     This can be corrected with the margin.bottom setting. Default = 0.00
        public double? Spacing { get; set; }

        //
        // Summary:
        //     Url for a HTML document to use for the footer. Default = ""
        public string HtmUrl { get; set; }
    }
    public class OwnHeaderSettings
    {
        //
        // Summary:
        //     The font size to use for the header. Default = 12
        public int? FontSize { get; set; }

        //
        // Summary:
        //     The name of the font to use for the header. Default = "Ariel"
        public string FontName { get; set; }

        //
        // Summary:
        //     The string to print in the left part of the header, note that some sequences
        //     are replaced in this string, see the wkhtmltopdf manual. Default = ""
        public string Left { get; set; }

        //
        // Summary:
        //     The text to print in the right part of the header, note that some sequences are
        //     replaced in this string, see the wkhtmltopdf manual. Default = ""
        public string Center { get; set; }

        //
        // Summary:
        //     The text to print in the right part of the header, note that some sequences are
        //     replaced in this string, see the wkhtmltopdf manual. Default = ""
        public string Right { get; set; }

        //
        // Summary:
        //     Whether a line should be printed under the header. Default = false
        public bool? Line { get; set; }

        //
        // Summary:
        //     The amount of space to put between the header and the content, e.g. "1.8". Be
        //     aware that if this is too large the header will be printed outside the pdf document.
        //     This can be corrected with the margin.top setting. Default = 0.00
        public double? Spacing { get; set; }

        //
        // Summary:
        //     Url for a HTML document to use for the header. Default = ""
        public string HtmUrl { get; set; }
    }
    public class OwnWebSettings
    {
        //
        // Summary:
        //     Should we print the background. Default = true
        public bool? Background { get; set; }

        //
        // Summary:
        //     Should we load images. Default = true
        public bool? LoadImages { get; set; }

        //
        // Summary:
        //     Should we enable javascript. Default = true
        public bool? EnableJavascript { get; set; }

        //
        // Summary:
        //     Should we enable intelligent shrinkng to fit more content on one page. Has no
        //     effect for wkhtmltoimage. Default = true
        public bool? EnableIntelligentShrinking { get; set; }

        //
        // Summary:
        //     The minimum font size allowed. Default = -1
        public int? MinimumFontSize { get; set; }

        //
        // Summary:
        //     Should the content be printed using the print media type instead of the screen
        //     media type. Default = false
        public bool? PrintMediaType { get; set; }

        //
        // Summary:
        //     What encoding should we guess content is using if they do not specify it properly.
        //     Default = ""
        public string DefaultEncoding { get; set; }

        //
        // Summary:
        //     Url or path to a user specified style sheet. Default = ""
        public string UserStyleSheet { get; set; }

        //
        // Summary:
        //     Should we enable NS plugins. Enabling this will have limited success. Default
        //     = false
        public bool? enablePlugins { get; set; }
    }
    public class PageMarginSettings
    {
        public Unit Unit { get; set; }

        public double? Top { get; set; }

        public double? Bottom { get; set; }

        public double? Left { get; set; }

        public double? Right { get; set; }

        public PageMarginSettings()
        {
            Unit = Unit.Millimeters;
        }

        public PageMarginSettings(double top, double right, double bottom, double left)
            : this()
        {
            Top = top;
            Bottom = bottom;
            Left = left;
            Right = right;
        }

        public string GetMarginValue(double? value)
        {
            if (!value.HasValue)
            {
                return null;
            }

            string text = "in";
            return string.Concat(str1: Unit switch
            {
                Unit.Inches => "in",
                Unit.Millimeters => "mm",
                Unit.Centimeters => "cm",
                _ => "in",
            }, str0: value.Value.ToString("0.##", CultureInfo.InvariantCulture));
        }
    }
    public class OwnGlobalSettings
    {
        private PageMarginSettings margins = new PageMarginSettings();

        //
        // Summary:
        //     The orientation of the output document, must be either "Landscape" or "Portrait".
        //     Default = "portrait"
        public Orientation? Orientation { get; set; }

        //
        // Summary:
        //     Should the output be printed in color or gray scale, must be either "Color" or
        //     "Grayscale". Default = "color"
        public ColorMode? ColorMode { get; set; }

        //
        // Summary:
        //     Should we use loss less compression when creating the pdf file. Default = true
        public bool? UseCompression { get; set; }

        //
        // Summary:
        //     What dpi should we use when printing. Default = 96
        public int? DPI { get; set; }

        //
        // Summary:
        //     A number that is added to all page numbers when printing headers, footers and
        //     table of content. Default = 0
        public int? PageOffset { get; set; }

        //
        // Summary:
        //     How many copies should we print. Default = 1
        public int? Copies { get; set; }

        //
        // Summary:
        //     Should the copies be collated. Default = true
        public bool? Collate { get; set; }

        //
        // Summary:
        //     Should a outline (table of content in the sidebar) be generated and put into
        //     the PDF. Default = true
        public bool? Outline { get; set; }

        //
        // Summary:
        //     The maximal depth of the outline. Default = 4
        public int? OutlineDepth { get; set; }

        //
        // Summary:
        //     If not set to the empty string a XML representation of the outline is dumped
        //     to this file. Default = ""
        public string DumpOutline { get; set; }

        //
        // Summary:
        //     The path of the output file, if "-" output is sent to stdout, if empty the output
        //     is stored in a buffer. Default = ""
        public string Out { get; set; }

        //
        // Summary:
        //     The title of the PDF document. Default = ""
        public string DocumentTitle { get; set; }

        //
        // Summary:
        //     The maximal DPI to use for images in the pdf document. Default = 600
        public int? ImageDPI { get; set; }

        //
        // Summary:
        //     The jpeg compression factor to use when producing the pdf document. Default =
        //     94
        public int? ImageQuality { get; set; }

        //
        // Summary:
        //     Path of file used to load and store cookies. Default = ""
        public string CookieJar { get; set; }

        //
        // Summary:
        //     Size of output paper
        public PechkinPaperSize PaperSize { get; set; }

        //
        // Summary:
        //     The height of the output document
        private string PaperHeight => (PaperSize == null) ? null : PaperSize.Height;

        //
        // Summary:
        //     The width of the output document
        private string PaperWidth => (PaperSize == null) ? null : PaperSize.Width;

        public PageMarginSettings Margins
        {
            get
            {
                return margins;
            }
            set
            {
                margins = value;
            }
        }

        //
        // Summary:
        //     Size of the left margin
        private string MarginLeft => margins.GetMarginValue(margins.Left);

        //
        // Summary:
        //     Size of the right margin
        private string MarginRight => margins.GetMarginValue(margins.Right);

        //
        // Summary:
        //     Size of the top margin
        private string MarginTop => margins.GetMarginValue(margins.Top);

        //
        // Summary:
        //     Size of the bottom margin
        private string MarginBottom => margins.GetMarginValue(margins.Bottom);

        //
        // Summary:
        //     Set viewport size. Not supported in wkhtmltopdf API since v0.12.2.4
        public string ViewportSize { get; set; }
    }
    public class OwnPdfGenerates
    {
        private readonly IConverter _converter;

        

        public byte[] GeneratePdf(PdfSettings pdfSettings, string htmlContent)
        {
            var globalSettings = new GlobalSettings
            {
                // Set global settings based on ownGlobalSettings
                Orientation = pdfSettings.ownGlobalSettings.Orientation ?? Orientation.Portrait,
                ColorMode = pdfSettings.ownGlobalSettings.ColorMode ?? ColorMode.Color,
                UseCompression = pdfSettings.ownGlobalSettings.UseCompression ?? true,
                DPI = pdfSettings.ownGlobalSettings.DPI ?? 96,
                // Set other properties similarly...
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = htmlContent,
                WebSettings = new WebSettings
                {
                    // Set web settings based on ownWebSettings
                    EnableJavascript = pdfSettings.webSettings.EnableJavascript ?? true,
                    LoadImages = pdfSettings.webSettings.LoadImages ?? true,
                    PrintMediaType = pdfSettings.webSettings.PrintMediaType ?? false
                }
            };

            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            return _converter.Convert(pdf);
        }
    }
}
