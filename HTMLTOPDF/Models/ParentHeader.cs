namespace HTMLTOPDF.Models
{
    public class ParentHeader
    {
        public ParentHeader()
        {
            UserProvideHeader = new UserProvideHeader();
            HeaderParameters = new List<UserHeaderParam>();
        }
        public UserProvideHeader UserProvideHeader { get; set; }
        public List<UserHeaderParam> HeaderParameters { get; set; }
    }

    public class UserProvideHeader
    {
        public UserProvideHeader() { 
            UserProvideHeaderString = string.Empty;
        }
        public string UserProvideHeaderString { get; set; }
    }
    public class UserHeaderParam
    {
        public UserHeaderParam() {

            // Assign default values to properties
            Title = new string[0]; // Empty array
            FontSize = string.Empty;
            FontColor = string.Empty;
            Image = string.Empty; // Default value for Image
        }
        public string[] Title { get; set; }
        public string FontSize { get; set; } 
        public string FontColor { get; set; }
        public string Image { get; set; } // New field for Image

    }
    public class UserImageForHeader
    {
        public UserImageForHeader()
        {
            
        }

    }

}
