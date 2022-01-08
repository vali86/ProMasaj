using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DbMasajModel
{
    public partial class DbMasajEntitiesModel : DbContext
    {
        public DbMasajEntitiesModel()
            : base("name=DbMasajEntitiesModel")
        {
        }

        public virtual DbSet<Angajat> Angajats { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Masaj> Masajs { get; set; }
        public virtual DbSet<Programare> Programares { get; set; }
        public virtual DbSet<Sala> Salas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Angajat>()
                .Property(e => e.Nume)
                .IsUnicode(false);

            modelBuilder.Entity<Angajat>()
                .Property(e => e.Prenume)
                .IsUnicode(false);

            modelBuilder.Entity<Angajat>()
                .Property(e => e.NrTelefon)
                .IsUnicode(false);

            modelBuilder.Entity<Angajat>()
                .HasMany(e => e.Salas)
                .WithRequired(e => e.Angajat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Nume)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Prenume)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.NrTelefon)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Masaj>()
                .Property(e => e.Denumire)
                .IsUnicode(false);

            modelBuilder.Entity<Masaj>()
                .Property(e => e.Pret)
                .IsUnicode(false);

            modelBuilder.Entity<Sala>()
                .Property(e => e.Strada)
                .IsUnicode(false);
        }
    }
}
