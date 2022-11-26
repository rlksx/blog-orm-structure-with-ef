using blog_orm_structure_with_ef.Data;
using blog_orm_structure_with_ef.Models;
using System.Linq;

namespace blog_orm_structure_with_ef
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            using (var context = new BlogDataContext())
            {
                /*  lendo dados do banco */
                // ReadTag(context);

                /* atualizar dados do banco */
                // UpdateTag(context);

                /* deletando dados do banco */
                // DeleteTag(context);

                /* About SaveChanges => Por motivos de performance, o EF permite 
                trabalhar com os dados na memória e persistir (salvar) os dados todos de uma vez */
                context.SaveChanges(); 
            }
        }
        private static void ReadTag(BlogDataContext context)
        {
            /* lendo tag do banco */
            var tag =  new Tag { Name = "ASP.NET", Slug = "aspnet" };
            context.Tags.Add(tag);
        }

        private static void UpdateTag(BlogDataContext context)
        {
            /* atualizando tag dados do banco */

            // O processo de atualizar dados deve ser feito sem uma nova instância de um objeto,
            // para atualizar dados deve-se fazer uma "Reidratação, 
            // que consiste em ler o item do banco e atualiza-lo" 

            var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
            tag.Name = ".NET";
            tag.Slug = "dotnet";

            context.Update(tag);
        }

        private static void DeleteTag(BlogDataContext context)
        {
            /* deletando tag do banco ( precisa de reidratação) */
            var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
            context.Remove(tag);
        }
    }
}