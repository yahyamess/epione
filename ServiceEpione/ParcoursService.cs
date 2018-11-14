using Data.Infrastructure;
using Domain;
using Domaine;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEpione
{
    public class ParcoursService : Service<Parcours>
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public ParcoursService() : base(ut)

        {
        }
    }
}
