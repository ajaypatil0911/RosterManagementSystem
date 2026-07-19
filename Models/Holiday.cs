namespace RosterManagementSystem.Models
{
    public class Holiday
    {
        public int Id { get; set; }

        public string HolidayName { get; set; } = string.Empty;

        public DateOnly HolidayDate { get; set; }

        public int MinimumEmployees { get; set; }

        public string? Description { get; set; }
    }
}
