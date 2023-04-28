namespace NetCoreExcel.Models.Custom
{
    public class AppUserEmployer
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int EmployerId { get; set; }
        public Employer Employer { get; set; }
    }
}
