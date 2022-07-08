// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace SamuraiApp
{
    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();
        public static void Main(string[] args)
        {
            AddSamurais("Okomoto", "Shimada", "Kikuchio", "Hayashida", "Cristi");
            //AddVariousTypes();
            GetSamurais();
        }

        private static void AddVariousTypes()
        {
            _context.AddRange(new Samurai{Name = "Shimada"},
                                        new Samurai{Name = "Okomoto"},
                                        new Battle{Name="Battle of Anegawa"},
                                        new Battle{Name = "Battle of Nagashino"});
            _context.SaveChanges();
        }

        private static void AddSamurais(params string[] names)
        {
            foreach (string name in names)
            {
                _context.Samurais.Add(new Samurai() { Name = name });
            }

            _context.SaveChanges();
        }

        private static void GetSamurais()
        {
            var samurais = _context.Samurais
                .TagWith("ConsoleApp.Program.GetSamurais method")
                .ToList();
            Console.WriteLine($"Samurai count is {samurais.Count}");
        }
    }
}