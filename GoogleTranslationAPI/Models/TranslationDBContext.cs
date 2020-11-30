using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GoogleTranslationAPI.Models
{
    public partial class TranslationDBContext : DbContext
    {
        public TranslationDBContext()
        {
        }

        public TranslationDBContext(DbContextOptions<TranslationDBContext> options)
            : base(options)
        { 
        }

        public virtual DbSet<Source> Source { get; set; }
        public virtual DbSet<Translator> Translator { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TranslationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Source>(entity =>
            {
                entity.Property(e => e.SourceId).HasColumnName("Source_ID");

                entity.Property(e => e.LanguageCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SourceTxt).IsUnicode(false);

                entity.Property(e => e.TranslatorId).HasColumnName("Translator_ID");

                entity.HasOne(d => d.Translator)
                    .WithMany(p => p.Source)
                    .HasForeignKey(d => d.TranslatorId)
                    .HasConstraintName("FK__Phrases__Transla__25869641");
            });

            modelBuilder.Entity<Translator>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LanguageCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TransText)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
