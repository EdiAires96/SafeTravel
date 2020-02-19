namespace SafeTravel.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class data : DbContext
    {
        public data()
            : base("name=data")
        {
        }

        public virtual DbSet<Allergy> Allergy { get; set; }
        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Diagnostic> Diagnostic { get; set; }
        public virtual DbSet<Disease> Disease { get; set; }
        public virtual DbSet<FemaleCondition> FemaleCondition { get; set; }
        public virtual DbSet<Kit> Kit { get; set; }
        public virtual DbSet<Kit_Product> Kit_Product { get; set; }
        public virtual DbSet<Medic> Medic { get; set; }
        public virtual DbSet<Order_Pharmacy> Order_Pharmacy { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Pharmacy> Pharmacy { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<Trip> Trip { get; set; }
        public virtual DbSet<Vaccine> Vaccine { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allergy>()
                .Property(e => e.info)
                .IsUnicode(false);

            modelBuilder.Entity<Allergy>()
                .HasMany(e => e.Patient)
                .WithMany(e => e.Allergy)
                .Map(m => m.ToTable("PatientAllergy").MapLeftKey("allergy_id").MapRightKey("patient_id"));

            modelBuilder.Entity<Appointment>()
                .Property(e => e.obs)
                .IsUnicode(false);

            modelBuilder.Entity<Diagnostic>()
                .Property(e => e.reason)
                .IsUnicode(false);

            modelBuilder.Entity<Diagnostic>()
                .Property(e => e.health_condition)
                .IsUnicode(false);

            modelBuilder.Entity<Diagnostic>()
                .Property(e => e.medicines)
                .IsUnicode(false);

            modelBuilder.Entity<Diagnostic>()
                .Property(e => e.allergic)
                .IsUnicode(false);

            modelBuilder.Entity<Diagnostic>()
                .Property(e => e.surgery)
                .IsUnicode(false);

            modelBuilder.Entity<Diagnostic>()
                .Property(e => e.recentSick)
                .IsUnicode(false);

            modelBuilder.Entity<Diagnostic>()
                .Property(e => e.malaria)
                .IsUnicode(false);

            modelBuilder.Entity<Diagnostic>()
                .Property(e => e.vaccines)
                .IsUnicode(false);

            modelBuilder.Entity<Diagnostic>()
                .Property(e => e.sickTravelling)
                .IsUnicode(false);

            modelBuilder.Entity<Diagnostic>()
                .Property(e => e.obs)
                .IsUnicode(false);

            modelBuilder.Entity<Diagnostic>()
                .HasMany(e => e.Trip)
                .WithRequired(e => e.Diagnostic)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Disease>()
                .Property(e => e.info)
                .IsUnicode(false);

            modelBuilder.Entity<Disease>()
                .HasMany(e => e.Patient)
                .WithMany(e => e.Disease)
                .Map(m => m.ToTable("PatientDiseases").MapLeftKey("disease_id").MapRightKey("patient_id"));

            modelBuilder.Entity<FemaleCondition>()
                .Property(e => e.info)
                .IsUnicode(false);

            modelBuilder.Entity<Kit>()
                .Property(e => e.info)
                .IsUnicode(false);

            modelBuilder.Entity<Kit>()
                .HasMany(e => e.Kit_Product)
                .WithRequired(e => e.Kit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Medic>()
                .HasMany(e => e.Appointment)
                .WithRequired(e => e.Medic)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Medic>()
                .HasMany(e => e.Kit)
                .WithRequired(e => e.Medic)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order_Pharmacy>()
                .Property(e => e.info)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.genre)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Appointment)
                .WithRequired(e => e.Patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.FemaleCondition)
                .WithRequired(e => e.Patient)
                .HasForeignKey(e => e.female_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Vaccine)
                .WithMany(e => e.Patient)
                .Map(m => m.ToTable("PatientVaccine").MapLeftKey("patient_id").MapRightKey("vaccine_id"));

            modelBuilder.Entity<Pharmacy>()
                .HasMany(e => e.Order_Pharmacy)
                .WithRequired(e => e.Pharmacy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pharmacy>()
                .HasMany(e => e.Stock)
                .WithRequired(e => e.Pharmacy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.info)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Kit_Product)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Order_Pharmacy)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Stock)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Region>()
                .Property(e => e.countries)
                .IsUnicode(false);

            modelBuilder.Entity<Region>()
                .Property(e => e.precautions)
                .IsUnicode(false);

            modelBuilder.Entity<Region>()
                .Property(e => e.info)
                .IsUnicode(false);

            modelBuilder.Entity<Region>()
                .HasMany(e => e.Trip)
                .WithRequired(e => e.Region)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trip>()
                .Property(e => e.destination)
                .IsUnicode(false);

            modelBuilder.Entity<Trip>()
                .Property(e => e.activities)
                .IsUnicode(false);

            modelBuilder.Entity<Trip>()
                .Property(e => e.accommodation)
                .IsUnicode(false);

            modelBuilder.Entity<Trip>()
                .Property(e => e.environment)
                .IsUnicode(false);

            modelBuilder.Entity<Vaccine>()
                .Property(e => e.info)
                .IsUnicode(false);
        }
    }
}
