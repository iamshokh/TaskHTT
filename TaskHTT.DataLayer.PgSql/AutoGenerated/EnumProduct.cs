using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskHTT.DataLayer.PgSql
{
    [Table("enum_product")]
    public partial class EnumProduct
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("product_name")]
        [StringLength(250)]
        public string ProductName { get; set; } = null!;
        [Column("title")]
        [StringLength(1000)]
        public string Title { get; set; } = null!;
        [Column("category_id")]
        public int CategoryId { get; set; }
        [Column("state_id")]
        public int StateId { get; set; }
        [Column("created_date", TypeName = "timestamp without time zone")]
        public DateTime CreatedDate { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("EnumProducts")]
        public virtual EnumCategory Category { get; set; } = null!;
        [ForeignKey("StateId")]
        [InverseProperty("EnumProducts")]
        public virtual EnumState State { get; set; } = null!;
    }
}
