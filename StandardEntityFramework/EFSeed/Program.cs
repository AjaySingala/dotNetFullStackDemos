using EFSeed.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSeed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating DbContext...");
            var db = new EFSeedDbContext();

            var associates = db.Associates.ToList();
            foreach (var associate in associates)
            {
                Console.WriteLine(associate.Name);
            }
        }
    }
}
