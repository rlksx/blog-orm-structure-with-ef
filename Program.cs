using blog_orm_structure_with_ef.Data;
using blog_orm_structure_with_ef.Models;

namespace blog_orm_structure_with_ef
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            using (var context = new BlogDataContext())
            {
                var tag =  new Tag { Name = "ASP.NET", Slug = "aspnet" };
                context.Tags.Add(tag);

                /* About SaveChanges => Por motivos de performance, o EF permite 
                trabalhar com os dados na memória e persistir (salvar) os dados todos de uma vez */
                context.SaveChanges(); 
            }
        }
    }
}