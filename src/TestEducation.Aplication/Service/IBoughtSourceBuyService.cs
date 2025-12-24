using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEducation.Aplication.Service
{
    public interface IBoughtSourceBuyService
    {
        Task<string> ShareSouceBuy(Guid SharedSourceId);
    }
}
