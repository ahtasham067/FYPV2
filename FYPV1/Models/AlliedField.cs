namespace FYPV1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AlliedField")]
    public partial class AlliedField
    {
        public int AlliedFieldId { get; set; }

        [Required]
        [StringLength(50)]
        public string AlliedFieldName { get; set; }
    }
}
