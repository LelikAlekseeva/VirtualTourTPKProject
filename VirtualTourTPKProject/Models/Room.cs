
namespace VirtualTourTPKProject.Models
{
    public class Room
    {
        public int Id { get; set; }

        public int FloorId { get; set; }

        public string RoomNumber { get; set; } = string.Empty;

        public string? RoomType { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public Floor? Floor { get; set; }

        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

        public ICollection<Panorama> Panoramas { get; set; } = new List<Panorama>();
    }
}