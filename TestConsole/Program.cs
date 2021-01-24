using System;
using System.Collections.Generic;
using WebApp.Models;

namespace TestConsole
{
    class Program
    {

        static void Main(string[] args)
        {

            var simplex = new Simplex(SimplexType.Maximum);

            simplex.BahanBaku = 3.2826;

            simplex.Products = new List<Product>();
            simplex.Products.Add(new Product { Name = "Balok", KeyName = 1, Need=0.2,  Harga = 4500000, BahanBaku=3.2826 });
            simplex.Products.Add(new Product { Name = "Papan", KeyName = 2, Need = 0.4, Harga = 4500000, BahanBaku=3.2826 });
            simplex.Products.Add(new Product { Name = "Rang", KeyName = 3 , Need = 0.1, Harga = 4500000, BahanBaku=3.2826 });

            //Fungsi Tujuan 
            Console.WriteLine("Fungsi Tujuan");
            Console.WriteLine(simplex.GetFungsiTujuan(simplex.Products));
            Console.WriteLine("\n\n");


            //Fungsi Kendala 
            Console.WriteLine("Fungsi Kendala");

            foreach (var item in simplex.GetFunsiKendala(simplex.Products))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n\n");

            //Fungsi Pembantu 
            Console.WriteLine("Fungsi Pembantu");

            foreach (var item in simplex.GetFungsiPembatu(simplex.Products))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n\n");

            

            var basic = new double[simplex.RowCount, simplex.ColumnCount];
            var index = 0;
            var col = 0;
            basic[index, col] = 1;
            foreach (var item in simplex.Products)
            {
                col++;
                basic[index, col] = -item.Harga;
            }

            index = 1;
            foreach (var item in simplex.Products)
            {
                basic[item.KeyName, index] = item.Need;
                basic[item.KeyName, index+(simplex.RowCount-1)] = 1;
                basic[item.KeyName, simplex.ColumnCount-1] = simplex.BahanBaku;
                index++;
            }

            simplex.Calculate(basic);
           
            Console.WriteLine();


        }
    }
}
