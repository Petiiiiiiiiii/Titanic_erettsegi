using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var kategoriak = new List<Kategoria>();
            var sr = new StreamReader(
                path: "titanic.txt",
                encoding: Encoding.UTF8);

            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                var kat = new Kategoria(sor);
                kategoriak.Add(kat);
            }

            Console.WriteLine($"2. feladat : {kategoriak.Count} db");

            int f3 = kategoriak.Sum(k => k.Utasok);
            Console.WriteLine($"3. feladat: {f3} fő");

            Console.Write("4. feladat: kulcsszó: ");
            string kSz = Console.ReadLine();

            bool f4 = kategoriak.Any(k => k.KategoriaNev.Contains(kSz));
            Console.WriteLine($"\t{(f4 ? "VAN" : "NINCS")} találat!");

            if (f4)
            {
                Console.WriteLine($"5. feladat: ");
                foreach (var item in kategoriak) 
                    if(item.KategoriaNev.Contains(kSz)) Console.WriteLine($"\t{item.KategoriaNev} {item.Utasok} fő");

            }

            var mgh = kategoriak.Where(k => k.EltuntekSzama > k.Utasok * 0.6).Select(k => k.KategoriaNev);
            Console.WriteLine("6. feladat: ");
            foreach (var katnev in mgh)
            {
                Console.WriteLine($"\t{katnev}");
            }

            var f7 = kategoriak
                .Where(k => k.TuelelokSzama == kategoriak.Max(k => k.TuelelokSzama))
                .First();

            Console.WriteLine($"7. feladat: {f7.KategoriaNev}");

            Console.ReadKey();
        }
    }
}
