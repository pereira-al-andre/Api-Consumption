using RM.Api.ValueObjects;

namespace RM.Api.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = null;
        public string Status { get; set; } = null;
        public string Species { get; set; } = null;
        public string Type { get; set; } = null;
        public string Gender { get; set; } = null;
        public Origin? Origin { get; set; } 
        public Location? Location { get; set; } 
        public string Image { get; set; } = null;
        public List<string> Episode { get; set; } = new();
        public string Url { get; set; } = null;
        public string Created { get; set; } = null;
    }
}
