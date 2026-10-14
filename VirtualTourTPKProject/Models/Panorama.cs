
namespace VirtualTourTPKProject.Models
{
    public class Panorama
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string? Description { get; set; }

        public double? CoordX { get; set; }

        public double? CoordY { get; set; }

        public double? CoordZ { get; set; }

        public bool IsEntrance { get; set; }

        public Room? Room { get; set; }

        public ICollection<PanoramaTransition> TransitionsFrom { get; set; }
            = new List<PanoramaTransition>();

        public ICollection<PanoramaTransition> TransitionsTo { get; set; }
            = new List<PanoramaTransition>();
    }
}