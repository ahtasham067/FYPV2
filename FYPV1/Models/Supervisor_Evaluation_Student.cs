namespace FYPV1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Supervisor_Evaluation_Student
    {
        [Key]
        public int SupervisorEvaluationStudentId { get; set; }

        public int ProjectId { get; set; }

        public int RegNo { get; set; }

        public double Documentation { get; set; }

        public double Implementation { get; set; }

        public double FypKnowledge { get; set; }

        public double PresentationOnSkill { get; set; }

        public double OverAllContribution { get; set; }

        public double TotalMarks { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string IndividualComments { get; set; }

        public int TeacherId { get; set; }

        public virtual Project Project { get; set; }
    }
}
