namespace TechCareerBootcampSecondClass.Models
{
    public class Category
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
