using Data.Infrastructure;
using Models;
using ServicePattern;

namespace Services
{
    public  class MedecinService : Service<PlusMed>
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public MedecinService():base(ut)
          
        {
        }
    }
}
