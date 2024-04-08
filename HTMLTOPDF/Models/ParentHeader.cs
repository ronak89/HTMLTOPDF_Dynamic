using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "User provide header string is required")]
        [SwaggerSchema(Description = "The string provided by the user in the header.")]
        public string UserProvideHeaderString { get; set; }
        
    }
    public class UserHeaderParam
    {
        public UserHeaderParam()
        {
            // Assign default values to properties
            Title = new List<string>();
            FontSize = string.Empty;
            FontColor = string.Empty;
            Image = string.Empty;
        }

        [Required(ErrorMessage = "Title is required")]
        public List<string> Title { get; set; }

        [Required(ErrorMessage = "Font size is required")]
        public string FontSize { get; set; }

        [Required(ErrorMessage = "Font color is required")]
        public string FontColor { get; set; }

        [Required(ErrorMessage = "Image URL is required")]
        public string Image { get; set; }
    }
    public class UserImageForHeader
    {
        public UserImageForHeader()
        {
            
        }

    }

}
