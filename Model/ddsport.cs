namespace DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ddsport : DbContext
    {
        public ddsport ()
            : base("name=ddsport")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        //public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<belt> belt { get; set; }
        public virtual DbSet<beltColor> BeltColor { get; set; }
        public virtual DbSet<branch> Branch { get; set; }
        public virtual DbSet<classstudent> ClassStudent { get; set; }
        public virtual DbSet<classteacher> ClassTeacher { get; set; }
        public virtual DbSet<classtime> classtime { get; set; }
        public virtual DbSet<_event> _event { get; set; }
        public virtual DbSet<measure> measure { get; set; }
        public virtual DbSet<measuretype> measuretype { get; set; }
        public virtual DbSet<room> room { get; set; }
        public virtual DbSet<school> school { get; set; }
        public virtual DbSet<schoolbranch> schoolbranch { get; set; }
        public virtual DbSet<sinif> sinif { get; set; }
        public virtual DbSet<student> student { get; set; }
        public virtual DbSet<teacher> teacher { get; set; }
        public virtual DbSet<traininglog> traininglog { get; set; }

        public virtual DbSet<documenttype> documenttype { get; set; }
        public virtual DbSet<document> document { get; set; }

        protected override void OnModelCreating ( DbModelBuilder modelBuilder )
        {
            modelBuilder.Entity<belt>( )
                .Property(e => e.version)
                .IsFixedLength( );

            modelBuilder.Entity<belt>( )
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<belt>( )
                .Property(e => e.updatedAt)
                .HasPrecision(3);

            modelBuilder.Entity<beltColor>( )
                .Property(e => e.name)
                .IsFixedLength( );

            modelBuilder.Entity<beltColor>( )
                .Property(e => e.value)
                .IsFixedLength( );

            modelBuilder.Entity<beltColor>( )
                .Property(e => e.version)
                .IsFixedLength( );

            modelBuilder.Entity<beltColor>( )
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<beltColor>( )
                .Property(e => e.updatedAt)
                .HasPrecision(3);

            modelBuilder.Entity<beltColor>( )
                .HasMany(e => e.belt)
                .WithRequired(e => e.beltColor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<branch>( )
                .Property(e => e.version)
                .IsFixedLength( );

            modelBuilder.Entity<branch>( )
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<branch>( )
                .Property(e => e.updatedAt)
                .HasPrecision(3);

            modelBuilder.Entity<branch>( )
                .HasMany(e => e.schoolbranch)
                .WithRequired(e => e.branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<classstudent>( )
                .Property(e => e.version)
                .IsFixedLength( );

            modelBuilder.Entity<classstudent>( )
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<classstudent>( )
                .Property(e => e.updatedAt)
                .HasPrecision(3);

            modelBuilder.Entity<classteacher>( )
                .Property(e => e.version)
                .IsFixedLength( );

            modelBuilder.Entity<classtime>( )
                .Property(e => e.version)
                .IsFixedLength( );

            modelBuilder.Entity<_event>( )
                .Property(e => e.version)
                .IsFixedLength( );

            modelBuilder.Entity<_event>( )
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<_event>( )
                .Property(e => e.updatedAt)
                .HasPrecision(3);


            modelBuilder.Entity<measuretype>( )
                .HasMany(e => e.measure)
                .WithRequired(e => e.measuretype)
                .HasForeignKey(e => e.type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<room>( )
                .Property(e => e.version)
                .IsFixedLength( );

            modelBuilder.Entity<room>( )
                .HasMany(e => e._event)
                .WithRequired(e => e.room)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<school>( )
                .Property(e => e.version)
                .IsFixedLength( );

            modelBuilder.Entity<school>( )
                .HasMany(e => e.room)
                .WithRequired(e => e.school)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<school>( )
                .HasMany(e => e.schoolbranch)
                .WithRequired(e => e.school)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<school>( )
                .HasMany(e => e.sinif)
                .WithRequired(e => e.school)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<school>( )
                .HasMany(e => e.student)
                .WithRequired(e => e.school)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<school>( )
                .HasMany(e => e.teacher)
                .WithRequired(e => e.school)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<schoolbranch>( )
                .Property(e => e.version)
                .IsFixedLength( );

            modelBuilder.Entity<schoolbranch>( )
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<schoolbranch>( )
                .Property(e => e.updatedAt)
                .HasPrecision(3);

            modelBuilder.Entity<sinif>( )
                .Property(e => e.version)
                .IsFixedLength( );

            modelBuilder.Entity<sinif>( )
                .HasMany(e => e.classstudent)
                .WithRequired(e => e.sinif)
                .HasForeignKey(e => e.sinif_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sinif>( )
                .HasMany(e => e.classteacher)
                .WithRequired(e => e.sinif)
                .HasForeignKey(e => e.sinif_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sinif>( )
                .HasMany(e => e.classtime)
                .WithRequired(e => e.sinif)
                .HasForeignKey(e => e.sinif_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sinif>( )
                .HasMany(e => e._event)
                .WithRequired(e => e.sinif)
                .HasForeignKey(e => e.sinif_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<student>( )
                .Property(e => e.version)
                .IsFixedLength( );

            modelBuilder.Entity<student>( )
                .HasMany(e => e.classstudent)
                .WithRequired(e => e.student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<student>( )
                .HasMany(e => e.measure)
                .WithRequired(e => e.student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<teacher>( )
                .Property(e => e.version)
                .IsFixedLength( );

            modelBuilder.Entity<teacher>( )
                .HasMany(e => e.classteacher)
                .WithRequired(e => e.teacher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<traininglog>( )
                .Property(e => e.version)
                .IsFixedLength( );
 

            modelBuilder.Entity<documenttype>()
                .Property(e => e.name)
                .IsFixedLength();
 

            modelBuilder.Entity<document>()
                .Property(e => e.version)
                .IsFixedLength();

            modelBuilder.Entity<document>()
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<document>()
                .Property(e => e.updatedAt)
                .HasPrecision(3);

            modelBuilder.Entity<documenttype>()
                .HasMany(e => e.documents)
                .WithRequired(e => e.documenttype)
                .WillCascadeOnDelete(false);
        }
    }
}
