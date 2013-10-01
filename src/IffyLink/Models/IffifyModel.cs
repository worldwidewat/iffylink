using System;
using System.ComponentModel.DataAnnotations;

namespace WorldWideWat.IffyLink.Models
{
    public class IffifyModel
    {
        [Display(Name = "Custom name? (if you're into that kind of thing)", Prompt = "(optional) e.g. RickRoll")]
        public string Alias { get; set; }

        [Display(Name = "What link would you'd like to share?", Prompt = "e.g. http://www.vindiesel.com/")]
        [DataType(DataType.Url)]
        [Url(ErrorMessage = "You think this is a URL... really?")]
        [Required(ErrorMessage = "Fool, a link is required")]
        public string Link { get; set; }

        [Display(Name = "When should it become 'iffy?'", Prompt = "e.g. 2014-01-01 12:01 AM")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Fool, an expiration is required")]
        public DateTimeOffset? Expiration { get; set; }
    }
}