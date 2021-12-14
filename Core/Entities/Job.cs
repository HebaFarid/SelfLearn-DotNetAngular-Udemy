namespace Core.Entities
{
    public class Job : BaseEntity
    {
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Salary { get; set; }
        public string Location { get; set; }
        public JobCategory JobCategory { get; set; }
        public int JobCategoryId { get; set; }
        
    }
}