using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskHTT.DataLayer.PgSql
{
    [Table("enum_state")]
    public partial class EnumState
    {
        public EnumState()
        {
            EnumCategories = new HashSet<EnumCategory>();
            EnumProducts = new HashSet<EnumProduct>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("code")]
        [StringLength(50)]
        public string? Code { get; set; }
        [Column("short_name")]
        [StringLength(250)]
        public string ShortName { get; set; } = null!;
        [Column("full_name")]
        [StringLength(250)]
        public string FullName { get; set; } = null!;
        [Column("created_date", TypeName = "timestamp without time zone")]
        public DateTime CreatedDate { get; set; }

        [InverseProperty("State")]
        public virtual ICollection<EnumCategory> EnumCategories { get; set; }
        [InverseProperty("State")]
        public virtual ICollection<EnumProduct> EnumProducts { get; set; }
    }
}
