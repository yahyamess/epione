using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNet.Identity.EntityFramework;
using Domaine;

namespace DATA
{
  public  class MyContext : IdentityDbContext<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {


        
        public static MyContext Create()
        {
            return new MyContext();
        }

        static MyContext()
        {
            Database.SetInitializer<MyContext>(null);
        }

        public MyContext() : base("name=EpioneDB")
        {

        }


        public DbSet<Parcours> parcours { get; set; }

        public DbSet<Motif> motif { get; set; }

        public DbSet<Chat> chats { get; set; }
        

        public DbSet<Soin> Soins { get; set; }

        public DbSet<Rapport> Rapport { get; set; }

        public DbSet<Notification> Notification { get; set; }

        public DbSet<Rating> Raiting { get; set; }

        public DbSet<Programme> Programme { get; set; }
        public DbSet<RDV> RendezVous { get; set; }
        
        public DbSet<PlusMed> PlusMed { get; set; }

    }
}
