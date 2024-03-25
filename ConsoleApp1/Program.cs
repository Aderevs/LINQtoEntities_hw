using DAL.Repositories;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ProductRepository repos = new ProductRepository();
            var result = await repos.Select();

            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }

            Console.ReadKey();
        }
    }
}