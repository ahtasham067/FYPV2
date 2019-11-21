namespace FYPV1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Domain")]
    public partial class Domain
    {
        public int DomainId { get; set; }

        [Required]
        [StringLength(50)]
        public string DomainName { get; set; }
    }
}
