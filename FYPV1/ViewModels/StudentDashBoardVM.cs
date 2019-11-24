using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FYPV1.ViewModels
{
    public class StudentDashBoardVM
    {
        // just for primitive data type because atleast one primitive data type is compulsory in VM
        [Key]
        public int Id { get; set; }



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

        [Required]
        [StringLength(500)]
        public string ProposalFilePath { get; set; }

        [Required]
        [StringLength(500)]
        public string ProposalFileName { get; set; }

        public int Semester1 { get; set; }
        public int Semester2 { get; set; }
        public int Semester3 { get; set; }
        public int Semester4 { get; set; }

        [Required]
        [StringLength(50)]
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Email4 { get; set; }

        public int ContactNo1 { get; set; }
        public int ContactNo2 { get; set; }
        public int ContactNo3 { get; set; }
        public int ContactNo4 { get; set; }

        [Required]
        [StringLength(50)]
        public string StudentName1 { get; set; }
        public string StudentName2 { get; set; }
        public string StudentName3 { get; set; }
        public string StudentName4 { get; set; }

        [Required]
        [StringLength(50)]
        public string RegNo1 { get; set; }
        public string RegNo2 { get; set; }
        public string RegNo3 { get; set; }
        public string RegNo4 { get; set; }

        public int ProjectId { get; set; }

    }
}