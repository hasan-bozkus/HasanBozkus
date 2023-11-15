using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DataAccsessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\hasan; database=HaseneBlog; integrated security=true;");
            //optionsBuilder.UseSqlServer("server=77.245.159.27\\MSSQLSERVER2019; database=HaseneBlog; user=AdminBenim; password=Hayalet0147.");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Match>().HasOne(x => x.HomeTeam).WithMany(y => y.HomeMatches).HasForeignKey(z => z.HomeTeamId).OnDelete(DeleteBehavior.ClientSetNull);

            //modelBuilder.Entity<Match>().HasOne(x => x.GuestTeam).WithMany(y => y.AwaitMatches).HasForeignKey(z => z.GuestTeamId).OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>().HasOne(x => x.SenderUser).WithMany(y => y.UserSender).HasForeignKey(z => z.Sender).OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>().HasOne(x => x.ReceiverUser).WithMany(y => y.UserReceiver).HasForeignKey(z => z.Receiver).OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Catch>().HasOne(x => x.SenderCatchUser).WithMany(y => y.UserCatchSender).HasForeignKey(z => z.SenderId).OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Catch>().HasOne(x => x.AnsweringCatchUser).WithMany(y => y.UserCatchAnswering).HasForeignKey(z => z.AnsweringId).OnDelete(DeleteBehavior.ClientSetNull);

           
            base.OnModelCreating(modelBuilder);

            //HomeMatches--> WriterSender
            //AwayMatches-->WriterReceiver

            //HomeTeam-->SenderUser
            //GuestTeam-->ReceiverUser
        }


        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogRayting> BlogRaytings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        //public DbSet<Team> Teams { get; set; }
        //public DbSet<Match> Matches { get; set; }
        public DbSet<Message2> Message2s { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Catch> Catches { get; set; }
        public DbSet<iletisimadresleri> iletisimadresleris { get; set; }
    }
}
