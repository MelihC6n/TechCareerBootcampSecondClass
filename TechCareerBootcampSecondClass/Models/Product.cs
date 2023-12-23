namespace TechCareerBootcampSecondClass.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;    

        public int UnitPrice { get; set; }

        public Category category { get; set; }  

        public Product(int id, string name, int unitPrice, Category category)
        {
            Id = id;
            Name = name;
            UnitPrice = unitPrice;
            this.category = category;
        }


    }
}
