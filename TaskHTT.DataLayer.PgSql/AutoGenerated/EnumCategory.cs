using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskHTT.DataLayer.PgSql
{
    [Table("enum_category")]
    public partial class EnumCategory
    {
        public EnumCategory()
        {
            EnumProducts = new HashSet<EnumProduct>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("category_name")]
        [StringLength(250)]
        public string CategoryName { get; set; } = null!;
        [Column("title")]
        [StringLength(1000)]
        public string Title { get; set; } = null!;
        [Column("state_id")]
        public int StateId { get; set; }
        [Column("created_date", TypeName = "timestamp without time zone")]
        public DateTime CreatedDate { get; set; }

        [ForeignKey("StateId")]
        [InverseProperty("EnumCategories")]
        public virtual EnumState State { get; set; } = null!;
        [InverseProperty("Category")]
        public virtual ICollection<EnumProduct> EnumProducts { get; set; }
    }
}
