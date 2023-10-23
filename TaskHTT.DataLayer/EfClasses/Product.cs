using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskHTT.DataLayer.EfClasses
{
    [Table("enum_product")]
    public partial class Product
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

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; } = null!;
        [ForeignKey(nameof(StateId))]
        public virtual State State { get; set; } = null!;
    }
}
