using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blog_orm_structure_with_ef.Models
{   
    [Table("Category")]
    public class Category
    {
        [Key] //=> explicita a propriedade como uma primary key!
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }

        [Required] //=> equivalente ao NOT NULL do SQL
        [MaxLength(80)] //=> equivalente a NVARCHAR(80)
        [MinLength(4)] //=> caracteres mínimos :3
        [Column("Name", TypeName = "NVARCHAR")] //=> especificando o tipo da coluna!
        public string Name { get; set; }


        [Required] //=> equivalente ao NOT NULL do SQL
        [MaxLength(80)] //=> equivalente a NVARCHAR(80)
        [MinLength(4)] //=> caracteres mínimos :3
        [Column("Slug", TypeName = "VARCHAR")] //=> especificando o tipo da coluna!
        public string Slug { get; set; }
    }
}