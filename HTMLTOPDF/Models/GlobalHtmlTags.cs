using System.Text;
using static HTMLTOPDF.Controllers.PdfCreatorController;

namespace HTMLTOPDF.Models
{
    public class GlobalHtmlTags
    {
        public HtmlTag Head { get; set; }
        public HtmlTag Title { get; set; }
        public HtmlTag Body { get; set; }
        public HtmlTag Paragraph { get; set; }
        public HtmlTag Div { get; set; }
        public HtmlTag Span { get; set; }
        public HtmlTag Anchor { get; set; }
        public HtmlTag Image { get; set; }
        public HtmlTag UnorderedList { get; set; }
        public HtmlTag OrderedList { get; set; }
        public HtmlTag ListItem { get; set; }
        public HtmlTag Table { get; set; }
        public HtmlTag TableRow { get; set; }
        public HtmlTag TableHeaderCell { get; set; }
        public HtmlTag TableCell { get; set; }
        public HtmlTag Form { get; set; }
        public HtmlTag Input { get; set; }
        public HtmlTag Button { get; set; }
        public HtmlTag TextArea { get; set; }
        public HtmlTag Select { get; set; }
        public HtmlTag Option { get; set; }
        public HtmlTag Label { get; set; }
        public HtmlTag Heading1 { get; set; }
        public HtmlTag Heading2 { get; set; }
        public HtmlTag Heading3 { get; set; }
        public HtmlTag Heading4 { get; set; }
        public HtmlTag Heading5 { get; set; }
        public HtmlTag Heading6 { get; set; }
        public HtmlTag Header { get; set; }
        public HtmlTag Footer { get; set; }
        public HtmlTag Break { get; set; }
        public HtmlTag Tag { get; set; }

        public GlobalHtmlTags()
        {
            // Initialize all tags to a default value, such as HtmlTag.Div
            Head = HtmlTag.Head;
            Title = HtmlTag.Title;
            Body = HtmlTag.Body;
            Paragraph = HtmlTag.Paragraph;
            Div = HtmlTag.Div;
            Span = HtmlTag.Span;
            Anchor = HtmlTag.Anchor;
            Image = HtmlTag.Image;
            UnorderedList = HtmlTag.UnorderedList;
            OrderedList = HtmlTag.OrderedList;
            ListItem = HtmlTag.ListItem;
            Table = HtmlTag.Table;
            TableRow = HtmlTag.TableRow;
            TableHeaderCell = HtmlTag.TableHeaderCell;
            TableCell = HtmlTag.TableCell;
            Form = HtmlTag.Form;
            Input = HtmlTag.Input;
            Button = HtmlTag.Button;
            TextArea = HtmlTag.TextArea;
            Select = HtmlTag.Select;
            Option = HtmlTag.Option;
            Label = HtmlTag.Label;
            Heading1 = HtmlTag.Heading1;
            Heading2 = HtmlTag.Heading2;
            Heading3 = HtmlTag.Heading3;
            Heading4 = HtmlTag.Heading4;
            Heading5 = HtmlTag.Heading5;
            Heading6 = HtmlTag.Heading6;
            Header = HtmlTag.Header;
            Footer = HtmlTag.Footer;
            Break = HtmlTag.Break;
        }
    }

    public enum HeadingLevel
    {
        H1,
        H2,
        H3,
        H4,
        H5,
        H6
    }
    public enum HtmlTag
    {
        Head,
        Title,
        Body,
        Paragraph,
        Div,
        Span,
        Anchor,
        Image,
        UnorderedList,
        OrderedList,
        ListItem,
        Table,
        TableRow,
        TableHeaderCell,
        TableCell,
        Form,
        Input,
        Button,
        TextArea,
        Select,
        Option,
        Label,
        Heading1,
        Heading2,
        Heading3,
        Heading4,
        Heading5,
        Heading6,
        Header,
        Footer,
        Break,
        Ul,
        Img,

    }
    public enum CssProperty
    {
        Width,
        Height,
        BackgroundColor,
        Color,
        FontFamily,
        FontSize,
        TextAlign,
        FontWeight,
        FontStyle,
        TextDecoration,
        Margin,
        Padding,
        Border,
        BorderRadius,
        Display,
        Position,
        Top,
        Right,
        Bottom,
        Left,
        Float,
        Clear,
        Overflow,
        Visibility,
        ZIndex,
        Cursor,
        Transition,
        Animation,
        BoxShadow,
        FlexDirection,
        FlexWrap,
        JustifyContent,
        AlignItems,
        AlignContent,
        FlexGrow,
        FlexShrink,
        FlexBasis,
        GridTemplateColumns,
        GridTemplateRows,
        GridGap,
        GridRowGap,
        GridColumnGap,
        GridAutoColumns,
        GridAutoRows,
        GridAutoFlow,
        GridRow,
        GridColumn,
        GridArea
    }

    public class HtmlGenerator
    {
        public static string GenerateHtml(HtmlTag tag, string content = "", Dictionary<CssProperty, string> styles = null)
        {
            string tagHtml = "";
            string styleString = styles != null ? $" style=\"{string.Join("; ", styles.Select(kv => $"{kv.Key}: {kv.Value}"))}\"" : string.Empty;

            switch (tag)
            {
                case HtmlTag.Head:
                    tagHtml = "<head>";
                    break;
                case HtmlTag.Title:
                    tagHtml = "<title>";
                    break;
                case HtmlTag.Body:
                    tagHtml = "<body>";
                    break;
                case HtmlTag.Paragraph:
                    tagHtml = "<p>";
                    break;
                case HtmlTag.Div:
                    tagHtml = "<div>";
                    break;
                case HtmlTag.Span:
                    tagHtml = "<span>";
                    break;
                case HtmlTag.Anchor:
                    tagHtml = $"<a href=\"{content}\"{styleString}>";
                    break;
                case HtmlTag.Image:
                    tagHtml = $"<img src=\"{content}\"{styleString}>";
                    break;
                case HtmlTag.UnorderedList:
                    tagHtml = "<ul>";
                    break;
                case HtmlTag.OrderedList:
                    tagHtml = "<ol>";
                    break;
                case HtmlTag.ListItem:
                    tagHtml = "<li>";
                    break;
                case HtmlTag.Table:
                    tagHtml = "<table>";
                    break;
                case HtmlTag.TableRow:
                    tagHtml = "<tr>";
                    break;
                case HtmlTag.TableHeaderCell:
                    tagHtml = "<th>";
                    break;
                case HtmlTag.TableCell:
                    tagHtml = "<td>";
                    break;
                case HtmlTag.Form:
                    tagHtml = "<form>";
                    break;
                case HtmlTag.Input:
                    tagHtml = $"<input type=\"text\" value=\"{content}\"{styleString}>";
                    break;
                case HtmlTag.Button:
                    tagHtml = "<button>";
                    break;
                case HtmlTag.TextArea:
                    tagHtml = "<textarea>";
                    break;
                case HtmlTag.Select:
                    tagHtml = "<select>";
                    break;
                case HtmlTag.Option:
                    tagHtml = "<option>";
                    break;
                case HtmlTag.Label:
                    tagHtml = "<label>";
                    break;
                case HtmlTag.Heading1:
                    tagHtml = $"<h1{styleString}>{content}</h1>";
                    break;
                case HtmlTag.Heading2:
                    tagHtml = $"<h2{styleString}>{content}</h2>";
                    break;
                case HtmlTag.Heading3:
                    tagHtml = $"<h3{styleString}>{content}</h3>";
                    break;
                case HtmlTag.Heading4:
                    tagHtml = $"<h4{styleString}>{content}</h4>";
                    break;
                case HtmlTag.Heading5:
                    tagHtml = $"<h5{styleString}>{content}</h5>";
                    break;
                case HtmlTag.Heading6:
                    tagHtml = $"<h6{styleString}>{content}</h6>";
                    break;
                case HtmlTag.Header:
                    tagHtml = "<header>";
                    break;
                case HtmlTag.Footer:
                    tagHtml = "<footer>";
                    break;
                case HtmlTag.Break:
                    tagHtml = "<br>";
                    break;
                default:
                    tagHtml = "";
                    break;
            }

            return tagHtml;
        }

    }
}
