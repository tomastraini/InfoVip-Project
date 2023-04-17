namespace InfoVip.Models
{
    public class Currency
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public List<Coins> coins { get; set; }
    }

    public class Coins
    {
        public int id { get; set; }
        public string name { get; set; }
        public Quote quote { get; set; }
    }

    public class Quote
    {
        public USD usd { get; set; }
    }

    public class USD
    {
        public decimal price { get; set; }
    }
}
