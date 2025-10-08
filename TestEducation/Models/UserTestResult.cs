namespace TestEducation.Models
{
    public class UserTestResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

     
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        // Test statistikasi
        public int TotalQuestions { get; set; }       // nechta savol berilgan
        public int CorrectAnswers { get; set; }       // nechta to‘g‘ri
        public int WrongAnswers { get; set; }         // nechta noto‘g‘ri
        public double Percentage { get; set; }        // foizda baho (masalan 83.3)
        public TimeSpan TimeTaken { get; set; }       // qancha vaqt sarflandi

        // Vaqtlar
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }

 
    }
}
