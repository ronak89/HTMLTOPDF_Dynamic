using System.ComponentModel;

namespace HTMLTOPDF.Models
{
    public class Employee
    {
        [DisplayName("Name Pankaj")]
        public string NameRonak { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
