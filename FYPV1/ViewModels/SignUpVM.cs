using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FYPV1.ViewModels
{
    public class SignUpVM
    {
        //Just model Key
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is requierd")]
        public string FullName { get; set; }
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

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is requierd")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is requierd")]
        [StringLength(50)]
        public string Email { get; set; }
        public bool? EmailVerification { get; set; }

        public Guid? ActivetionCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is requierd")]
        [StringLength(50)]
        public string TFullName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is requierd")]
        [StringLength(50)]
        public string TeacherId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is requierd")]
        [StringLength(50)]
        public string TEmail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is requierd")]
        [StringLength(50)]
        [MinLength(5, ErrorMessage = "Enter atleast 5 Characters")]
        [DataType(DataType.Password)]
        public string TPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is requierd")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string TConfirmPassword { get; set; }

        public bool? TEmailVerification { get; set; }

        public Guid? TActivetionCode { get; set; }
    }
}