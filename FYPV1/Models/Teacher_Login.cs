namespace FYPV1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Teacher_Login
    {
        [Key]
        public int TeacherLoginId { get; set; }

        [Required]
        [StringLength(50)]
        public string TeacherId { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public int? TeacherSignUpId { get; set; }

        public virtual Teacher_SignUp Teacher_SignUp { get; set; }
    }
}
