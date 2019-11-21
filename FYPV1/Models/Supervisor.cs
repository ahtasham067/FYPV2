namespace FYPV1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supervisor")]
    public partial class Supervisor
    {
        public int SupervisorId { get; set; }

        [Required]
        [StringLength(50)]
        public string SupervisorName { get; set; }

        public int? ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
