
namespace VirtualTourTPKProject.Models
{
    public class PanoramaTransition
    {
        public int Id { get; set; }

        public int FromPanoramaId { get; set; }

        public int ToPanoramaId { get; set; }

        public string? DirectionHint { get; set; }

        public decimal? DistanceMeters { get; set; }

        public Panorama? FromPanorama { get; set; }

        public Panorama? ToPanorama { get; set; }
    }
}