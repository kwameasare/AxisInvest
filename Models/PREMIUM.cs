using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invest.Models
{
    [Table("PREMIUM")]
    public partial class PREMIUM
    {
        [Key]
        public long PremiumID { get; set; }

        public int? AccountID { get; set; }

        public int ProductID { get; set; }

        public DateTime? PaymentDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? PremiumAmount { get; set; }
    }
}
