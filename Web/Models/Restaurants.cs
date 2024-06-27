namespace Web.Models
{
    public class Restaurants :BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }
        public List<Food_items> food_Items{get; set;}
        }
}
