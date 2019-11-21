namespace FYPV1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Semester")]
    public partial class Semester
    {
        public int SemesterId { get; set; }

        public int SemesterNumber { get; set; }

        public int? ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
