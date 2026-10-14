namespace VirtualTourTPKProject.Models
{
    public class Building
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Address { get; set; }

        public string? Description { get; set; }

        public ICollection<Floor> Floors { get; set; } = new List<Floor>();
    }
}