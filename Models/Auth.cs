using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Invest.Models
{
    [Table("Auth")]
    public partial class Auth
    {
        [Key]
        public long AuthID { get; set; }

        public int? AccountID { get; set; }

        public string UserName { get; set; }

        public string Pwd { get; set; }

       
    }
}