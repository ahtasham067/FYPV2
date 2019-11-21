namespace FYPV1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Co_Supervisor
    {
        [Key]
        public int CoSupervisorId { get; set; }

        [Required]
        [StringLength(50)]
        public string CoSupervisorName { get; set; }

        public int? ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public virtual Project Project1 { get; set; }
    }
}
