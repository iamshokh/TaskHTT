using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskHTT.DataLayer.EfClasses
{
    [Table("enum_category")]
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
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
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [ForeignKey(nameof(StateId))]
        public virtual State State { get; set; } = null!;
        [InverseProperty(nameof(Product.Category))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
