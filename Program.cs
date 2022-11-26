using blog_orm_structure_with_ef.Data;
using blog_orm_structure_with_ef.Models;
using Microsoft.EntityFrameworkCore;
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
                /*  criando novo item do banco */
                // CreateTag(context);

                /* atualizar dados do banco */
                // UpdateTag(context);

                /* deletando dados do banco */
                // DeleteTag(context);

                /* lendo os item(s) */
                // ReadTags(context);
                ReadOneTag(context);

                /* About SaveChanges => Por motivos de performance, o EF permite 
                trabalhar com os dados na memória e persistir (salvar) os dados todos de uma vez */
                context.SaveChanges();
            }
        }
        private static void CreateTag(BlogDataContext context)
        {
            /* criando nova tag do banco */
            var tag = new Tag { Name = ".Net", Slug = "dotnet" };
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

        private static void ReadTags(BlogDataContext context)
        {
            /* lendo as tags do banco */

            // var tags = context.Tags; //=> faz uma referencia para a execução
            var tags = context.Tags.AsNoTracking().ToList(); //=> faz a execução direta, sempre por último!!

            foreach (var tag in tags) //=> aqui é executado a query quando não usado o "ToList()"
            {
                Console.WriteLine("- " + tag.Name);
            }
        }

        private static void ReadOneTag(BlogDataContext context)
        {
            var tag = context.Tags.AsNoTracking().FirstOrDefault(x => x.Id == 2);
            Console.WriteLine(tag.Id + " - " + tag.Name);
        }
    }
}