namespace TheArne4.SandwichService.Models
{
    public class Sandwich
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string Description { get; internal set; }
        public decimal Price { get; set; }
    }
}