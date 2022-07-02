using System.ComponentModel.DataAnnotations;

namespace Product.Resource
{
    public class SaveProduct_Resource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Ferlizante { get; set; }
    }
}
