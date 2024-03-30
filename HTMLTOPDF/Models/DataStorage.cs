using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;
namespace HTMLTOPDF.Models
{
    public static class DataStorage
    {
        public static List<Employee> GetAllEmployees() =>
    new List<Employee>
    {
        new Employee { NameRonak="Mike", LastName="Turner", Age=35, Gender="Male", NamesObj = new Names { MyNames = "Mike Turner", LastName = "Turner" }},
        new Employee { NameRonak="Sonja", LastName="Markus", Age=22, Gender="Female", NamesObj = new Names { MyNames = "Sonja Markus", LastName = "Markus" }},
        new Employee { NameRonak="Luck", LastName="Martins", Age=40, Gender="Male", NamesObj = new Names { MyNames = "Luck Martins", LastName = "Martins" }},
        new Employee { NameRonak="Sofia", LastName="Packner", Age=30, Gender="Female", NamesObj = new Names { MyNames = "Sofia Packner", LastName = "Packner" }},
        new Employee { NameRonak="John", LastName="Doe", Age=45, Gender="Male", NamesObj = new Names { MyNames = "John Doe", LastName = "Doe" }},
        new Employee { NameRonak="Mike", LastName="Turner", Age=35, Gender="Male", NamesObj = new Names { MyNames = "Mike Turner", LastName = "Turner" }},
        new Employee { NameRonak="Sonja", LastName="Markus", Age=22, Gender="Female", NamesObj = new Names { MyNames = "Sonja Markus", LastName = "Markus" }},
        new Employee { NameRonak="Luck", LastName="Martins", Age=40, Gender="Male", NamesObj = new Names { MyNames = "Luck Martins", LastName = "Martins" }},
        new Employee { NameRonak="Sofia", LastName="Packner", Age=30, Gender="Female", NamesObj = new Names { MyNames = "Sofia Packner", LastName = "Packner" }},
        new Employee { NameRonak="John", LastName="Doe", Age=45, Gender="Male", NamesObj = new Names { MyNames = "John Doe", LastName = "Doe" }},
        new Employee { NameRonak="Mike", LastName="Turner", Age=35, Gender="Male", NamesObj = new Names { MyNames = "Mike Turner", LastName = "Turner" }},
        new Employee { NameRonak="Sonja", LastName="Markus", Age=22, Gender="Female", NamesObj = new Names { MyNames = "Sonja Markus", LastName = "Markus" }},
        new Employee { NameRonak="Luck", LastName="Martins", Age=40, Gender="Male", NamesObj = new Names { MyNames = "Luck Martins", LastName = "Martins" }},

        new Employee { NameRonak="Mike", LastName="Turner", Age=35, Gender="Male", NamesObj = new Names { MyNames = "Mike Turner", LastName = "Turner" }},
        new Employee { NameRonak="Sonja", LastName="Markus", Age=22, Gender="Female", NamesObj = new Names { MyNames = "Sonja Markus", LastName = "Markus" }},
        new Employee { NameRonak="Luck", LastName="Martins", Age=40, Gender="Male", NamesObj = new Names { MyNames = "Luck Martins", LastName = "Martins" }},
        new Employee { NameRonak="Sofia", LastName="Packner", Age=30, Gender="Female", NamesObj = new Names { MyNames = "Sofia Packner", LastName = "Packner" }},
        new Employee { NameRonak="John", LastName="Doe", Age=45, Gender="Male", NamesObj = new Names { MyNames = "John Doe", LastName = "Doe" }},
        new Employee { NameRonak="Mike", LastName="Turner", Age=35, Gender="Male", NamesObj = new Names { MyNames = "Mike Turner", LastName = "Turner" }},
        new Employee { NameRonak="Sonja", LastName="Markus", Age=22, Gender="Female", NamesObj = new Names { MyNames = "Sonja Markus", LastName = "Markus" }},
        new Employee { NameRonak="Luck", LastName="Martins", Age=40, Gender="Male", NamesObj = new Names { MyNames = "Luck Martins", LastName = "Martins" }},
        new Employee { NameRonak="Sofia", LastName="Packner", Age=30, Gender="Female", NamesObj = new Names { MyNames = "Sofia Packner", LastName = "Packner" }},
        new Employee { NameRonak="John", LastName="Doe", Age=45, Gender="Male", NamesObj = new Names { MyNames = "John Doe", LastName = "Doe" }},
        new Employee { NameRonak="Mike", LastName="Turner", Age=35, Gender="Male", NamesObj = new Names { MyNames = "Mike Turner", LastName = "Turner" }},
        new Employee { NameRonak="Sonja", LastName="Markus", Age=22, Gender="Female", NamesObj = new Names { MyNames = "Sonja Markus", LastName = "Markus" }},
        new Employee { NameRonak="Luck", LastName="Martins", Age=40, Gender="Male", NamesObj = new Names { MyNames = "Luck Martins", LastName = "Martins" }},

    new Employee { NameRonak="Mike", LastName="Turner", Age=35, Gender="Male", NamesObj = new Names { MyNames = "Mike Turner", LastName = "Turner" }},
        new Employee { NameRonak="Sonja", LastName="Markus", Age=22, Gender="Female", NamesObj = new Names { MyNames = "Sonja Markus", LastName = "Markus" }},
        new Employee { NameRonak="Luck", LastName="Martins", Age=40, Gender="Male", NamesObj = new Names { MyNames = "Luck Martins", LastName = "Martins" }},
        new Employee { NameRonak="Sofia", LastName="Packner", Age=30, Gender="Female", NamesObj = new Names { MyNames = "Sofia Packner", LastName = "Packner" }},
        new Employee { NameRonak="John", LastName="Doe", Age=45, Gender="Male", NamesObj = new Names { MyNames = "John Doe", LastName = "Doe" }},
        new Employee { NameRonak="Mike", LastName="Turner", Age=35, Gender="Male", NamesObj = new Names { MyNames = "Mike Turner", LastName = "Turner" }},
        new Employee { NameRonak="Sonja", LastName="Markus", Age=22, Gender="Female", NamesObj = new Names { MyNames = "Sonja Markus", LastName = "Markus" }},
        new Employee { NameRonak="Luck", LastName="Martins", Age=40, Gender="Male", NamesObj = new Names { MyNames = "Luck Martins", LastName = "Martins" }},
        new Employee { NameRonak="Sofia", LastName="Packner", Age=30, Gender="Female", NamesObj = new Names { MyNames = "Sofia Packner", LastName = "Packner" }},
        new Employee { NameRonak="John", LastName="Doe", Age=45, Gender="Male", NamesObj = new Names { MyNames = "John Doe", LastName = "Doe" }},
        new Employee { NameRonak="Mike", LastName="Turner", Age=35, Gender="Male", NamesObj = new Names { MyNames = "Mike Turner", LastName = "Turner" }},
        new Employee { NameRonak="Sonja", LastName="Markus", Age=22, Gender="Female", NamesObj = new Names { MyNames = "Sonja Markus", LastName = "Markus" }},
        new Employee { NameRonak="Luck", LastName="Martins", Age=40, Gender="Male", NamesObj = new Names { MyNames = "Luck Martins", LastName = "Martins" }},

            new Employee { NameRonak="Mike", LastName="Turner", Age=35, Gender="Male", NamesObj = new Names { MyNames = "Mike Turner", LastName = "Turner" }},
        new Employee { NameRonak="Sonja", LastName="Markus", Age=22, Gender="Female", NamesObj = new Names { MyNames = "Sonja Markus", LastName = "Markus" }},
        new Employee { NameRonak="Luck", LastName="Martins", Age=40, Gender="Male", NamesObj = new Names { MyNames = "Luck Martins", LastName = "Martins" }},
        new Employee { NameRonak="Sofia", LastName="Packner", Age=30, Gender="Female", NamesObj = new Names { MyNames = "Sofia Packner", LastName = "Packner" }},
        new Employee { NameRonak="John", LastName="Doe", Age=45, Gender="Male", NamesObj = new Names { MyNames = "John Doe", LastName = "Doe" }},
        new Employee { NameRonak="Mike", LastName="Turner", Age=35, Gender="Male", NamesObj = new Names { MyNames = "Mike Turner", LastName = "Turner" }},
        new Employee { NameRonak="Sonja", LastName="Markus", Age=22, Gender="Female", NamesObj = new Names { MyNames = "Sonja Markus", LastName = "Markus" }},
        new Employee { NameRonak="Luck", LastName="Martins", Age=40, Gender="Male", NamesObj = new Names { MyNames = "Luck Martins", LastName = "Martins" }},
        new Employee { NameRonak="Sofia", LastName="Packner", Age=30, Gender="Female", NamesObj = new Names { MyNames = "Sofia Packner", LastName = "Packner" }},
        new Employee { NameRonak="John", LastName="Doe", Age=45, Gender="Male", NamesObj = new Names { MyNames = "John Doe", LastName = "Doe" }},
        new Employee { NameRonak="Mike", LastName="Turner", Age=35, Gender="Male", NamesObj = new Names { MyNames = "Mike Turner", LastName = "Turner" }},
        new Employee { NameRonak="Sonja", LastName="Markus", Age=22, Gender="Female", NamesObj = new Names { MyNames = "Sonja Markus", LastName = "Markus" }},
        new Employee { NameRonak="Luck", LastName="Martins", Age=40, Gender="Male", NamesObj = new Names { MyNames = "Luck Martins", LastName = "Martins" }},


    };

    }
}
