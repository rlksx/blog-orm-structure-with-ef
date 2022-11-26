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
            using var context = new BlogDataContext();

            // var user = new User
            // {
            //     Name = "Ryan Gabriel",
            //     Slug = "ryan-gabriel",
            //     Email = "ryan.bromati@hotmail.com",
            //     Bio = "Junior Software Engineer",
            //     Image = "http://...",
            //     PasswordHash = "1122333444455555"
            // };
            // var category = new Category
            // {
            //     Name = "Backend",
            //     Slug = "backend"
            // };
            // var post = new Post
            // {
            //     Author = user,
            //     Category = category,
            //     Body = "hello world",
            //     Slug = "começando-com-ef-core",
            //     Summary = "Neste Artigo vamos dar dicas de como começar no EF",
            //     Title = "Començando com EF",
            //     CreateDate = DateTime.Now,
            //     LastUpdateDate = DateTime.Now
            // };
            // /* gera tudo automático *-* */
            // context.Posts.Add(post);

            var posts = context.Posts.AsTracking().Include(x => x.Author) //=> inner join no autor com post!
            .OrderByDescending(x => x.LastUpdateDate).ToList();
            foreach (var post in posts)
            {
                Console.WriteLine($"{post.Title} - {post.Author?.Name}");
            }

            context.SaveChanges();
        }
    }
}