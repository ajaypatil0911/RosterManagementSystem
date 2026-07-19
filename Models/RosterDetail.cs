namespace RosterManagementSystem.Models
{
    public class RosterDetail
    {
        public int Id { get; set; }

        public int RosterId { get; set; }

        public Roster? Roster { get; set; }

        public int EmployeeId { get; set; }

        public Employee? Employee { get; set; }

        public DateOnly RosterDate { get; set; }

        public int ShiftId { get; set; }

        public Shift? Shift { get; set; }

        public bool IsWeekOff { get; set; }

        public bool IsHoliday { get; set; }

        public string? Remarks { get; set; }
    }
}
