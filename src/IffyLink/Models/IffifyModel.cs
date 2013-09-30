using System;
using System.ComponentModel.DataAnnotations;

namespace WorldWideWat.IffyLink.Models
{
    public class IffifyModel
    {
        [Display(Name = "What short name should it have?", Prompt = "e.g. RickRoll")]
        [Required(ErrorMessage = "Alias is equired")]
        public string Alias { get; set; }

        [Display(Name = "What link would you'd like to share?", Prompt = "e.g. http://www.vindiesel.com/")]
        [Required(ErrorMessage = "Link is equired")]
        public string Link { get; set; }

        [Display(Name = "When should it become 'iffy?'", Prompt = "Click to choose")]
        [Required(ErrorMessage = "Expiration is equired")]
        public DateTimeOffset? Expiration { get; set; }
    }
}