using System.Diagnostics.CodeAnalysis;

namespace TestEducation.Aplication.Models.Users
{
    public class UserPageModel
    {
        [NotNull]
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string Search { get; set; }
    }
}
