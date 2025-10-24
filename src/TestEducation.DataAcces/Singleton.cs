using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols;
using TestEducation.Models;

namespace TestEducation.DataAcces
{
    public sealed class Singleton
    {
        private static Singleton _instance;

        private Singleton()
        {
        }

        public static Singleton instance()
        {

            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;

        }



        public void Add()
        {
            List<Subject> subjects = new List<Subject>();
        }

    }
}
