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
            if (args.Length != 0)
            {
                if (args[0] == "add")
                {
                    AddBattles(args);
                }
            }
           
        }

        private static void AddBattles(string[] battleNames)
        {
            foreach (var name in battleNames)
            {
                DateTime startDate = GenerateStartDate();
                DateTime endDate = GenerateEndDate(startDate);

                _context.Battles.Add(new Battle
                {
                    Name = name,
                    StartDate = startDate,
                    EndDate = endDate
                });
            }

            _context.SaveChanges();
        }

        private static DateTime GenerateStartDate()
        {
            Random randomNumberGenerator = new Random();
            var startDate = new DateTime(randomNumberGenerator.Next(1, 2022), randomNumberGenerator.Next(1, 12), randomNumberGenerator.Next(1, 30));

            return startDate;
        }

        private static DateTime GenerateEndDate(DateTime startDate)
        {
            Random randomNumberGenerator = new Random();
            var endDate = startDate;

            endDate.AddYears(randomNumberGenerator.Next(0, 10));
            endDate.AddMonths(randomNumberGenerator.Next(0, 12));
            endDate.AddDays(randomNumberGenerator.Next(0, 30));

            if (endDate > DateTime.Now)
            {
                endDate = DateTime.Now;
            }

            return endDate;
        }
    }
}