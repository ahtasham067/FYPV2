namespace FYPV1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Project")]
    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            Co_Supervisor = new HashSet<Co_Supervisor>();
            Co_Supervisor1 = new HashSet<Co_Supervisor>();
            Internal_Evaluation = new HashSet<Internal_Evaluation>();
            Internal_Evaluation_Student = new HashSet<Internal_Evaluation_Student>();
            Project_Student = new HashSet<Project_Student>();
            Semesters = new HashSet<Semester>();
            Supervisors = new HashSet<Supervisor>();
            Supervisor_Evaluation = new HashSet<Supervisor_Evaluation>();
            Supervisor_Evaluation_Student = new HashSet<Supervisor_Evaluation_Student>();
        }

        public int ProjectId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public int Supervisor { get; set; }

        public int CoSupervisor { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Summary { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Objective { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Scope { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string ToolsAndTechnologies { get; set; }

        [StringLength(500)]
        public string ProposalFileType { get; set; }

        [StringLength(500)]
        public string ProposalFilePath { get; set; }

        [StringLength(500)]
        public string ProposalFileName { get; set; }

        [StringLength(500)]
        public string SrsFileType { get; set; }

        [StringLength(500)]
        public string SrsFilePath { get; set; }

        [StringLength(500)]
        public string SrsFileName { get; set; }

        [StringLength(500)]
        public string SreFileType { get; set; }

        [StringLength(500)]
        public string SreFilePath { get; set; }

        [StringLength(500)]
        public string SreFileName { get; set; }

        [StringLength(500)]
        public string CodeFileType { get; set; }

        [StringLength(500)]
        public string CodeFilePath { get; set; }

        [StringLength(500)]
        public string CodeFileName { get; set; }

        [StringLength(500)]
        public string PrototypeFileType { get; set; }

        [StringLength(500)]
        public string PrototypeFilePath { get; set; }

        [StringLength(500)]
        public string PrototypeFileName { get; set; }

        [StringLength(500)]
        public string FinalReportFileType { get; set; }

        [StringLength(500)]
        public string FinalReportFilePath { get; set; }

        [StringLength(500)]
        public string FinalReportFileName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Co_Supervisor> Co_Supervisor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Co_Supervisor> Co_Supervisor1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Internal_Evaluation> Internal_Evaluation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Internal_Evaluation_Student> Internal_Evaluation_Student { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project_Student> Project_Student { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Semester> Semesters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supervisor> Supervisors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supervisor_Evaluation> Supervisor_Evaluation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supervisor_Evaluation_Student> Supervisor_Evaluation_Student { get; set; }
    }
}
