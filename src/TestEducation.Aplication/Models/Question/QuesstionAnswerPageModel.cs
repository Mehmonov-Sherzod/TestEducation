using System.Diagnostics.CodeAnalysis;

namespace TestEducation.Aplication.Models.Question
{
    public class QuesstionAnswerPageModel
    {
        [NotNull]
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string Search { get; set; }
    }
}
