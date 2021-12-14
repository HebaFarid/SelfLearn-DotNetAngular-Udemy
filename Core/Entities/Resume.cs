namespace Core.Entities
{
    public class Resume : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Age { get; set; }
        public string MobileNumber { get; set; }
        public string PictureUrl { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public ResumeCategory ResumeCategory { get; set; }
        public int ResumeCategoryId { get; set; }
        
    }
}