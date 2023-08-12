using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Repository.Models
{
    public partial class CourseManagementContext : DbContext
    {
        public CourseManagementContext()
        {
        }

        public CourseManagementContext(DbContextOptions<CourseManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAttendence> TblAttendences { get; set; }
        public virtual DbSet<TblCourse> TblCourses { get; set; }
        public virtual DbSet<TblSemester> TblSemesters { get; set; }
        public virtual DbSet<TblSession> TblSessions { get; set; }
        public virtual DbSet<TblStudent> TblStudents { get; set; }
        public virtual DbSet<TblStudentInCourse> TblStudentInCourses { get; set; }
        public virtual DbSet<TblSubject> TblSubjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=CourseManagement;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblAttendence>(entity =>
            {
                entity.ToTable("tblAttendence");

                entity.Property(e => e.DateAttendence).HasColumnType("datetime");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.TblAttendences)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("FK_tblAttendence_tblSession");
            });

            modelBuilder.Entity<TblCourse>(entity =>
            {
                entity.ToTable("tblCourse");

                entity.Property(e => e.CourseCode).HasMaxLength(50);

                entity.Property(e => e.DateEnd).HasColumnType("datetime");

                entity.Property(e => e.DateStart).HasColumnType("datetime");

                entity.Property(e => e.Instructor).HasMaxLength(50);

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.TblCourses)
                    .HasForeignKey(d => d.SemesterId)
                    .HasConstraintName("FK_tblCourse_tblSemester");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.TblCourses)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_tblCourse_tblSubject");
            });

            modelBuilder.Entity<TblSemester>(entity =>
            {
                entity.ToTable("tblSemester");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.SemesterName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblSession>(entity =>
            {
                entity.ToTable("tblSession");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.SessionDate).HasMaxLength(50);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TblSessions)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_tblSession_tblCourse");
            });

            modelBuilder.Entity<TblStudent>(entity =>
            {
                entity.ToTable("tblStudent");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TblStudentInCourse>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseId })
                    .HasName("PK__tblStude__5E57FC83FBC5DAF0");

                entity.ToTable("tblStudentInCourse");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TblStudentInCourses)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblStudentInCourse_tblCourse");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.TblStudentInCourses)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblStudentInCourse_tblStudent");
            });

            modelBuilder.Entity<TblSubject>(entity =>
            {
                entity.ToTable("tblSubject");

                entity.Property(e => e.SubjectName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
