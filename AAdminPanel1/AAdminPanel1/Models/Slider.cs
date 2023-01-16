using System.ComponentModel.DataAnnotations;

namespace AAdminPanel1.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 25)]
        public string Title1 { get; set; }
        [StringLength(maximumLength: 25)]
        public string Title2 { get; set; }
        [StringLength(maximumLength: 75)]
        public string Desc { get; set; }
        public string RedUrl { get; set; }
        [StringLength(maximumLength: 35)]
        public string RedUrlText { get; set; }
        public string Image { get; set; }

        public int Order { get; set; }

    }
}
