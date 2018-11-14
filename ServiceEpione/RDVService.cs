using Data.Infrastructure;
using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEpione
{
    public class RDVService : Service<RDV>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public RDVService():base(ut)
          
        {
        }
    }
}
