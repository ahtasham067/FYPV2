using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FYPV1.ViewModels
{
    public class LogInVM
    {
        //Just model Key
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is requierd")]
        public int Campus { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is requierd")]
        public int Batch { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is requierd")]
        public int Program { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is requierd")]
        [StringLength(50)]
        public string RegNo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is requierd")]
        [StringLength(50)]
        [MinLength(5, ErrorMessage = "Enter atleast 5 Characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool? EmailVerification { get; set; }
        public bool Rememberme { get; internal set; }
        [Required]
        [StringLength(50)]
        public string TeacherId { get; set; }
        [Required]
        [StringLength(250)]
        public string TPassword { get; set; }

        public bool? TEmailVerification { get; set; }
    }
}