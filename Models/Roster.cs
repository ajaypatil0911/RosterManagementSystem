namespace RosterManagementSystem.Models
{
    public class Roster
    {
        public int Id { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public string Status { get; set; } = "Draft";

        public DateTime GeneratedOn { get; set; } = DateTime.UtcNow;

        public string GeneratedBy { get; set; } = string.Empty;

        // Navigation Property
        public ICollection<RosterDetail> RosterDetails { get; set; } = new List<RosterDetail>();

    }
}
