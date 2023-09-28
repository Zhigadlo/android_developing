namespace lab2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UPC { get; set; }
        public string Producer { get; set; }
        public double Price { get; set; }
        public DateTime ExpireDate { get; set; }
        public int Quantity { get; set; }

        public Product(int Id, string Name, string UPC, string Producer, double Price, DateTime ExpireDate, int Quantity)
        {
            this.Id = Id;
            this.Name = Name;
            this.UPC = UPC;
            this.Producer = Producer;
            this.Price = Price;
            this.ExpireDate = ExpireDate;
            this.Quantity = Quantity;
        }
        public override string ToString()
        {
            return $"Название: {Name}\n" +
                   $"Цена: {Price}\n" +
                   $"Изготовитель: {Producer}\n" +
                   $"UPC: {UPC}\n" +
                   $"Срок годности: {ExpireDate.ToShortDateString()}\n" +
                   $"Количество: {Quantity}";
        }
    }
}

