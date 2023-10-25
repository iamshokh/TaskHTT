using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskHTT.DataLayer.EfClasses
{
    [Table("enum_state")]
    public partial class State
    {
        public State()
        {
            Categories = new HashSet<Category>();
            Products = new HashSet<Product>();
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
        [InverseProperty(nameof(Category.State))]
        public virtual ICollection<Category> Categories { get; set; }
        [InverseProperty(nameof(Product.State))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
