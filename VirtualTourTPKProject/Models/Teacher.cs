
namespace VirtualTourTPKProject.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public string LastName { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string? MiddleName { get; set; }

        public string? Position { get; set; }

        public string? Department { get; set; }

        public string? Email { get; set; }

        public int? OfficeRoomId { get; set; }

        public Room? OfficeRoom { get; set; }
    }
}