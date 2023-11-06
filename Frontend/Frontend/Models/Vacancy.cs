namespace Frontend.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public Company Company { get; set; }
        public string JobDescription { get; set; }
        public DateTime JobOpenedDate { get; set; }
        public DateTime JobClosedDate { get; set; }
        public float Salary { get; set; }
    }
}
