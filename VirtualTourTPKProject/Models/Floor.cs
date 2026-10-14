
namespace VirtualTourTPKProject.Models
{
    public class Floor
    {
        public int Id { get; set; }

        public int BuildingId { get; set; }

        public int FloorNumber { get; set; }

        public string? Description { get; set; }

        public Building? Building { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}