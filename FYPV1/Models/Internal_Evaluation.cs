namespace FYPV1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Internal_Evaluation
    {
        [Key]
        public int InternalEvaluationId { get; set; }

        public int ProjectId { get; set; }

        public int ProjectTitle { get; set; }

        public int Supervisor { get; set; }

        public int CoSupervisor { get; set; }

        [Required]
        [StringLength(50)]
        public string Scope { get; set; }

        public int Completion { get; set; }

        [Column(TypeName = "text")]
        public string OverAllComments { get; set; }

        [Column(TypeName = "date")]
        public DateTime EvaluationDate { get; set; }

        public int TeacherId { get; set; }

        public virtual Project Project { get; set; }
    }
}
