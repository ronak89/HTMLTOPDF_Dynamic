﻿using System.ComponentModel;
using System.Text;

namespace HTMLTOPDF.Models
{
    public static class TemplateGenerator
    {
        public static string UpdateCompanyName(string htmlContent, string companyName)
        {
            // Find and replace the placeholder text with the actual company name
            return htmlContent.Replace("<h1>Company</h1>", $"<h1>{companyName}</h1>");
        }
        public static string GetHTMLString()
        {
            // Define the folder path dynamically
            string imagePath = "/assets/";

            string physicalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePath.Replace("~/", "").Replace("/", "\\"));

            // Get all image files in the folder
            string[] imageFiles = Directory.GetFiles(physicalPath, "*.jpg");

            // Select the first image file found (you can modify this based on your criteria)
            string selectedImagePath = imageFiles[0];

            string companyName = "MyCompany-Ronak";
            var employees = DataStorage.GetAllEmployees();
            var sb = new StringBuilder();
            sb.Append(@"
            <html>
                <head>
                    <meta charset=""utf-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
                    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"">
                    <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js""></script>
                    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js""></script>
                </head>
                <body>
                     <div class=""jumbotron"">
                <h1>" + companyName + @"</h1>
                <div class=""header-right"">
                    <img src=""" + selectedImagePath + @""" alt=""Italian Trulli"">
                </div>
            </div>
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

        //public static string GetHTMLString()
        //{
        //    var employees = DataStorage.GetAllEmployees();
        //    var sb = new StringBuilder();
        //    sb.Append(@"
        //                            <html>
        //                                <head>
        //                                </head>
        //                                <body>
        //                                    <div class='header'><h1>This is the generated PDF report!!!</h1></div>
        //                                    <table align='center'>
        //                                        <tr>
        //                                            <th>Name</th>
        //                                            <th>LastName</th>
        //                                            <th>Age</th>
        //                                            <th>Gender</th>
        //    <th>Icon</th>
        //                                        </tr>");
        //    foreach (var emp in employees)
        //    {
        //        sb.AppendFormat(@"<tr>
        //                                        <td>{0}</td>
        //                                        <td>{1}</td>
        //                                        <td>{2}</td>
        //                                        <td>{3}</td>
        //    <td><svg height='16' viewBox='0 0 16 16' width='16' xmlns='http://www.w3.org/2000/svg'><path d='m12.2417871 6.58543288-5.97153941 5.97295362c-.32039706.3203971-.72184675.5476941-1.16142789.6575893l-2.29099929.5727499c-.36619024.0915475-.69788662-.2401489-.60633907-.6063391l.57274983-2.2909993c.10989528-.4395811.33719224-.8410308.65758929-1.16142788l5.97153945-5.97295366zm1.4149207-4.24193358c.7810486.78104859.7810486 2.04737855 0 2.82842713l-.7078139.70639967-2.8284271-2.82842712.7078139-.70639968c.7810486-.78104858 2.0473785-.78104858 2.8284271 0z' fill='#212121'/></svg></td>
        //                                      </tr>", emp.Name, emp.LastName, emp.Age, emp.Gender);
        //    }
        //    sb.Append(@"
        //                                    </table>
        //                                </body>
        //                            </html>");
        //    return sb.ToString();

        //    //var employees = DataStorage.GetAllEmployees();
        //    //var sb = new StringBuilder();
        //    //sb.Append(@"
        //    //    <html>
        //    //        <head>
        //    //        </head>
        //    //        <body>
        //    //            <div class='header'><h1>This is the generated PDF report!!!</h1></div>
        //    //            <table align='center'>
        //    //                <tr>
        //    //                    <th>Name</th>
        //    //                    <th>Age</th>
        //    //                    <th>Gender</th>
        //    //                    <th>Icon</th>
        //    //                </tr>");
        //    //foreach (var emp in employees)
        //    //{
        //    //    sb.AppendFormat(@"<tr>
        //    //                <td colspan='2'>{0} {1}</td> <!-- Merge Name and LastName columns -->
        //    //                <td>{2}</td>
        //    //                <td>{3}</td>
        //    //                <td><svg height='16' viewBox='0 0 16 16' width='16' xmlns='http://www.w3.org/2000/svg'><path d='m12.2417871 6.58543288-5.97153941 5.97295362c-.32039706.3203971-.72184675.5476941-1.16142789.6575893l-2.29099929.5727499c-.36619024.0915475-.69788662-.2401489-.60633907-.6063391l.57274983-2.2909993c.10989528-.4395811.33719224-.8410308.65758929-1.16142788l5.97153945-5.97295366zm1.4149207-4.24193358c.7810486.78104859.7810486 2.04737855 0 2.82842713l-.7078139.70639967-2.8284271-2.82842712.7078139-.70639968c.7810486-.78104858 2.0473785-.78104858 2.8284271 0z' fill='#212121'/></svg></td>
        //    //              </tr>", emp.Name, emp.LastName, emp.Age, emp.Gender);
        //    //}
        //    //sb.Append(@"
        //    //            </table>
        //    //        </body>
        //    //    </html>");
        //    //return sb.ToString();
        //}
    }
}
