using System.Data.Entity;

namespace Invest.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Invest")
        {
        }

        public virtual DbSet<MEMBER> MEMBERs { get; set; }
        public virtual DbSet<PREMIUM> PREMIUMs { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTs { get; set; }
        public virtual DbSet<Auth> Auths { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MEMBER>()
                .Property(e => e.AccountNo)
                .IsUnicode(false);

            modelBuilder.Entity<MEMBER>()
                .Property(e => e.Othernames)
                .IsUnicode(false);

            modelBuilder.Entity<MEMBER>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<MEMBER>()
                .Property(e => e.CellPhone)
                .IsUnicode(false);

            modelBuilder.Entity<MEMBER>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<MEMBER>()
                .Property(e => e.ResidentialAddress)
                .IsUnicode(false);

            modelBuilder.Entity<PREMIUM>()
                .Property(e => e.PremiumAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.ProductNa)
                .IsUnicode(false);
        }
    }
}
