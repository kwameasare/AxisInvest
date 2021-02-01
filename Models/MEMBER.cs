using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invest.Models
{
    [Table("MEMBER")]
    public partial class MEMBER
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccountID { get; set; }

        [StringLength(10)]
        public string AccountNo { get; set; }

        [StringLength(50)]
        public string Othernames { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        public DateTime DOB { get; set; }

        [StringLength(20)]
        public string CellPhone { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string ResidentialAddress { get; set; }

        public int Active { get; set; }

        public ICollection<PREMIUM> PremiumsCollection { get; set; }

    }
}
