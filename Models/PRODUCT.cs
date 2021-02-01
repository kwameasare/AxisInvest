using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invest.Models
{
    [Table("PRODUCT")]
    public partial class PRODUCT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [Required]
        [StringLength(17)]
        public string ProductNa { get; set; }

        public int Active { get; set; }
    }
}
