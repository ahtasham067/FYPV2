namespace FYPV1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Teacher_SignUp
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teacher_SignUp()
        {
            Fyp_Idea = new HashSet<Fyp_Idea>();
            Teacher_Login = new HashSet<Teacher_Login>();
        }

        [Key]
        public int TeacherSignUpId { get; set; }

        [Required]
        [StringLength(50)]
        public string TFullName { get; set; }

        [Required]
        [StringLength(50)]
        public string TeacherId { get; set; }

        [Required]
        [StringLength(50)]
        public string TEmail { get; set; }

        [Required]
        [StringLength(250)]
        public string TPassword { get; set; }

        public bool? TEmailVerification { get; set; }

        public Guid? TActivetionCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fyp_Idea> Fyp_Idea { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teacher_Login> Teacher_Login { get; set; }
    }
}
