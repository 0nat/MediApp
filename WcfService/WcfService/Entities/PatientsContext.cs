namespace WcfService.Entities
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PatientsContext : DbContext
    {

        public PatientsContext()
            : base("name=Patients")
        {           
        }

        public DbSet<Illness> TableIllness { get; set; }
        public DbSet<IllnessHasSymptom> TableIllnessHasSymptom { get; set; }
        public DbSet<Symptom> TableSymptom { get; set; }
        public DbSet<Patient> TablePatient { get; set; }
        public DbSet<LifeFuncMeasure> TableLifeFuncMeasure { get; set; }
        public DbSet<PatientWasSick> TablePatientWasSick { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<>
            base.OnModelCreating(modelBuilder);
        }
    }
}