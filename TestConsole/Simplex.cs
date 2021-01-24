using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Models;

namespace TestConsole
{
    internal class Simplex
    {
        private SimplexType simplexType;

        public Simplex(WebApp.Models.SimplexType type)
        {
            simplexType = type;
        }

        public double BahanBaku { get;  set; }
        public List<Product> Products { get; internal set; }

        public string Operator => simplexType == SimplexType.Maximum ? "+" : "-";
        public string NotOperator => simplexType == SimplexType.Maximum ? "-" : "+";


        internal string GetFungsiTujuan(List<Product> products)
        {
            var sb = new StringBuilder();
            var index = 0;
            foreach (var item in products)
            {
                if (index < products.Count - 1)
                    sb.Append($"{item.Harga} X{item.KeyName} {Operator} ");
                else
                    sb.Append($"{item.Harga} X{item.KeyName} = Z ");
                    index++;
            }


            return sb.ToString();

                
        }

        internal List<string> GetFunsiKendala(List<Product> products)
        {

            var list = new List<string>();
            foreach (var item in products)
            {
                list.Add($"{item.Need} X{item.KeyName} <= {BahanBaku}");
            }

            return list;
        }

        internal IEnumerable<string> GetFungsiPembatu(List<Product> products)
        {
            var list = new List<string>();
            foreach (var item in products)
            {
                list.Add($"{item.Need} X{item.KeyName} {Operator} S{item.KeyName} = {item.BahanBaku}");
            }


            var sb = new StringBuilder();
            var index = 0;
            foreach (var item in products)
            {
                if (index == 0)
                    sb.Append("Z-");

                if (index < products.Count - 1)
                    sb.Append($"{item.Harga} X{item.KeyName} {NotOperator} ");
                else
                    sb.Append($"{item.Harga} X{item.KeyName} = 0 ");
                index++;
            }


            list.Add(sb.ToString());
            return list;
        }


        public int RowCount => Products.Count+1;
        public int ColumnCount => RowCount * 2 + 1;

        internal void Calculate(double[,] basic)
        {
            var history = new List<double[,]>();

            Print(basic);

            while (CheckZIsMinus(basic))
            {
                double[,] newbasic = basic.Clone() as double[,];

                history.Add(newbasic);

                var columnKey = SelectColumnKey(basic);
                var rowKey = SetRatio(basic, columnKey);

                ChangeRowKey(basic, rowKey, columnKey);

                Print(basic);
            }

        }



        private  void Print(double[,] basic)
        {
            
            for (int i = 0; i < RowCount; i++)
            {
                Console.Write(" |");

                for (int j = 0; j < ColumnCount; j++)
                {
                    var tab = basic[i, j].ToString().Length > 5 ? "" : "  \t";
                    Console.Write($"{basic[i, j]} {tab}|");

                }
                Console.Write("\n");
            }

            Console.WriteLine("\n\n");
        }


        private  Tuple<int, double> SetRatio(double[,] basic, int j)
        {
            double angkaKunci = basic[0,j];
            int barisKunci = 0;

            for (int i = 1; i < RowCount; i++)
            {

                if (basic[i, j] > angkaKunci)
                {
                    angkaKunci = basic[i, j];
                    barisKunci = i;
                }
            }

            basic[barisKunci, ColumnCount-1 ] =basic[barisKunci, ColumnCount - 1] / angkaKunci;


            return Tuple.Create(barisKunci, angkaKunci);
        }

        private  int SelectColumnKey(double[,] basic)
        {
            var selectColumn = 0;
            var minValue = basic[0, 0];
            for (int j = 0; j < ColumnCount; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (minValue > basic[i, j])
                    {
                        minValue = basic[i, j];
                        selectColumn = j;
                    }

                }

            }

            return selectColumn;
        }

        private  bool CheckZIsMinus(double[,] basic)
        {
            var isFound = false;
            for (int i = 1; i < ColumnCount-1; i++)
            {
                if (basic[0, i] < 0)
                {
                    isFound = true;
                    break;
                }
            }
            return isFound;
        }


        private void ChangeRowKey(double[,] basic, Tuple<int, double> rowKey, int columnKey)
        {

            for (int j = 0; j < ColumnCount-1; j++)
            {
                var result = basic[rowKey.Item1, j] / rowKey.Item2;
                basic[rowKey.Item1, j] = result;
                if (result > 0)
                {
                    basic[0, j] = Math.Abs(basic[0, columnKey]) * result;
                }
            }
        }
    }
}