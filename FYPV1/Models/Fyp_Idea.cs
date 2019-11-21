namespace FYPV1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Fyp_Idea
    {
        [Key]
        public int IdeaId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public int Domain { get; set; }

        public int AlliedField { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Summary { get; set; }

        public byte[] IdeaFile { get; set; }

        public int? TeacherSignUpId { get; set; }

        public virtual Teacher_SignUp Teacher_SignUp { get; set; }
    }
}
