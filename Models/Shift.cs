namespace RosterManagementSystem.Models
{
    public class Shift
    {
        public int Id { get; set; }

        public string ShiftName { get; set; } = string.Empty;

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public int RequiredEmployees { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation Property
        public ICollection<RosterDetail> RosterDetails { get; set; } = new List<RosterDetail>();

    }
}
