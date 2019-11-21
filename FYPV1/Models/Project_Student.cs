namespace FYPV1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Project_Student
    {
        [Key]
        public int ProjectStudentId { get; set; }

        public int Semester { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public int ContactNo { get; set; }

        [Required]
        [StringLength(50)]
        public string StudentName { get; set; }

        [Required]
        [StringLength(50)]
        public string RegNo { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
