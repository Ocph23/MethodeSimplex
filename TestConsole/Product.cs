namespace TestConsole
{
     public class Product
    {
        public string Name { get;  set; }
        public int KeyName { get;  set; }
        public double Need { get;  set; }
        public int Harga { get;  set; }
        public double BahanBaku { get; internal set; }
    }
}