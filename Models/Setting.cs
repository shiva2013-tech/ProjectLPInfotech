using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectLPInfotech.Models
{
    public partial class Setting
    {
        public long Id { get; set; }

        [Required]
        public string? Key { get; set; }

        [Required]
        public string? Value { get; set; }
        public string Value2 { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}
