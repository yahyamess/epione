using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEpione
{
    public class PatientService : Models<Patient>
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public PatientService() : base(ut)

        {
        }
    }
}
