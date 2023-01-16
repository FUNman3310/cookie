using System.ComponentModel.DataAnnotations;

namespace AAdminPanel1.ViewModels
{
    public class BookCreateViewModel
    {
        public int GenreId { get; set; }

        public int AuthorId { get; set; }

        [StringLength(maximumLength: 55, ErrorMessage = "Max 55")]
        public string Name { get; set; }
        [StringLength(maximumLength: 25, ErrorMessage = "Max 25")]
        public string ProductCode { get; set; }
        [StringLength(maximumLength: 155, ErrorMessage = "Max 155")]
        public string Desc { get; set; }
        public bool IsAvailable { get; set; }

        public double CostPrice { get; set; }
        public double SalePrice { get; set; }

        public double DiscountPrice { get; set; }
    }
}
