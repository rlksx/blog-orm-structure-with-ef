using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blog_orm_structure_with_ef.Models
{   
    [Table("Category")]
    public class Category
    {
        [Key] //=> explicita a propriedade como uma primary key!
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}