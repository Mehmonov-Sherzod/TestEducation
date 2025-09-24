namespace TestEducation.Models
{
    public class Subject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Test> tests { get; set; }   
    }
}
