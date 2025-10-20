using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Users;

namespace TestEducation.Aplication.Service
{
    public  interface IRabbitMQproducer
    {
        void SedMessage(OrderCreatedDto createdDto);
    }
}
