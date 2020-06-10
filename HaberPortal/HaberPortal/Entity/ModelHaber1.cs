namespace HaberPortal.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelHaber1 : DbContext
    {
        public ModelHaber1()
            : base("name=ModelHaber1")
        {
        }

        public virtual DbSet<Haber> Haber { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Haber>()
                .Property(e => e.baslik)
                .IsUnicode(false);

            modelBuilder.Entity<Haber>()
                .Property(e => e.resim_yolu)
                .IsUnicode(false);

            modelBuilder.Entity<Haber>()
                .Property(e => e.icerik)
                .IsUnicode(false);

            modelBuilder.Entity<Kategori>()
                .Property(e => e.kategori_ad)
                .IsUnicode(false);

            modelBuilder.Entity<Kategori>()
                .HasMany(e => e.Haber)
                .WithRequired(e => e.Kategori)
                .HasForeignKey(e => e.kategori_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanicilar>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Kullanicilar>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
