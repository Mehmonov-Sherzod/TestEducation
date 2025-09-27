namespace TestEducation.Models
{
    public class QuestionLevel
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public int Point {  get; set; } 
        public List<Question> questions { get; set; }  
    }
}
    
