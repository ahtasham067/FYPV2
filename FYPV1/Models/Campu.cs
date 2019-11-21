namespace FYPV1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Campu
    {
        [Key]
        public int CampusId { get; set; }

        [Required]
        [StringLength(50)]
        public string CampusName { get; set; }

        public int? StudentLoginId { get; set; }

        public int? StudentSignUpId { get; set; }

        public virtual Student_Login Student_Login { get; set; }

        public virtual Student_SignUp Student_SignUp { get; set; }
    }
}
