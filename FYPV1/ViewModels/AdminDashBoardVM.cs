using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FYPV1.ViewModels
{
    public class AdminDashBoardVM
    {
        //Just model Key
        [Key]
        public int Id { get; set; }

        //Domain
        [Required]
        [StringLength(50)]
        public string DomainName { get; set; }
        //Allied Field
        [Required]
        [StringLength(50)]
        public string AlliedFieldName { get; set; }
        //Supervisor
        [Required]
        [StringLength(50)]
        public string SupervisorName { get; set; }
        //Co-Supervisor
        [Required]
        [StringLength(50)]
        public string CoSupervisorName { get; set; }
        //Batch
        [Required]
        [StringLength(50)]
        public string BatchName { get; set; }
        //Campus
        [Required]
        [StringLength(50)]
        public string CampusName { get; set; }
        //Program
        [Required]
        [StringLength(50)]
        public string ProgramName { get; set; }
        //Semester
        public int SemesterNumber { get; set; }

    }
}