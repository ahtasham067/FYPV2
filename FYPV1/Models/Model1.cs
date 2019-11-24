namespace FYPV1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<AlliedField> AlliedFields { get; set; }
        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<Campu> Campus { get; set; }
        public virtual DbSet<Co_Supervisor> Co_Supervisor { get; set; }
        public virtual DbSet<Domain> Domains { get; set; }
        public virtual DbSet<Fyp_Idea> Fyp_Idea { get; set; }
        public virtual DbSet<Internal_Evaluation> Internal_Evaluation { get; set; }
        public virtual DbSet<Internal_Evaluation_Student> Internal_Evaluation_Student { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Project_Student> Project_Student { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Student_Login> Student_Login { get; set; }
        public virtual DbSet<Student_SignUp> Student_SignUp { get; set; }
        public virtual DbSet<Supervisor> Supervisors { get; set; }
        public virtual DbSet<Supervisor_Evaluation> Supervisor_Evaluation { get; set; }
        public virtual DbSet<Supervisor_Evaluation_Student> Supervisor_Evaluation_Student { get; set; }
        public virtual DbSet<Teacher_Login> Teacher_Login { get; set; }
        public virtual DbSet<Teacher_SignUp> Teacher_SignUp { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlliedField>()
                .Property(e => e.AlliedFieldName)
                .IsUnicode(false);

            modelBuilder.Entity<Batch>()
                .Property(e => e.BatchName)
                .IsUnicode(false);

            modelBuilder.Entity<Campu>()
                .Property(e => e.CampusName)
                .IsUnicode(false);

            modelBuilder.Entity<Co_Supervisor>()
                .Property(e => e.CoSupervisorName)
                .IsUnicode(false);

            modelBuilder.Entity<Domain>()
                .Property(e => e.DomainName)
                .IsUnicode(false);

            modelBuilder.Entity<Fyp_Idea>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Fyp_Idea>()
                .Property(e => e.Summary)
                .IsUnicode(false);

            modelBuilder.Entity<Internal_Evaluation>()
                .Property(e => e.Scope)
                .IsUnicode(false);

            modelBuilder.Entity<Internal_Evaluation>()
                .Property(e => e.OverAllComments)
                .IsUnicode(false);

            modelBuilder.Entity<Internal_Evaluation_Student>()
                .Property(e => e.IndividualComments)
                .IsUnicode(false);

            modelBuilder.Entity<Program>()
                .Property(e => e.ProgramName)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.Summary)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.Objective)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.Scope)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.ToolsAndTechnologies)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.ProposalFileType)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.ProposalFilePath)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.ProposalFileName)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.SrsFileType)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.SrsFilePath)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.SrsFileName)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.SreFileType)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.SreFilePath)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.SreFileName)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.CodeFileType)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.CodeFilePath)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.CodeFileName)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.PrototypeFileType)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.PrototypeFilePath)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.PrototypeFileName)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.FinalReportFileType)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.FinalReportFilePath)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.FinalReportFileName)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Co_Supervisor)
                .WithOptional(e => e.Project)
                .HasForeignKey(e => e.ProjectId);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Co_Supervisor1)
                .WithOptional(e => e.Project1)
                .HasForeignKey(e => e.ProjectId);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Internal_Evaluation)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Internal_Evaluation_Student)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Project_Student)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Supervisor_Evaluation)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Supervisor_Evaluation_Student)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project_Student>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Project_Student>()
                .Property(e => e.StudentName)
                .IsUnicode(false);

            modelBuilder.Entity<Project_Student>()
                .Property(e => e.RegNo)
                .IsUnicode(false);

            modelBuilder.Entity<Student_Login>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Student_SignUp>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Student_SignUp>()
                .Property(e => e.RegNo)
                .IsUnicode(false);

            modelBuilder.Entity<Supervisor>()
                .Property(e => e.SupervisorName)
                .IsUnicode(false);

            modelBuilder.Entity<Supervisor_Evaluation>()
                .Property(e => e.Scope)
                .IsUnicode(false);

            modelBuilder.Entity<Supervisor_Evaluation_Student>()
                .Property(e => e.IndividualComments)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher_Login>()
                .Property(e => e.TeacherId)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher_Login>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher_SignUp>()
                .Property(e => e.TFullName)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher_SignUp>()
                .Property(e => e.TeacherId)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<FYPV1.ViewModels.StudentDashBoardVM> StudentDashBoardVMs { get; set; }

        public System.Data.Entity.DbSet<FYPV1.ViewModels.TeacherDashBoardVM> TeacherDashBoardVMs { get; set; }

        public System.Data.Entity.DbSet<FYPV1.ViewModels.AdminDashBoardVM> AdminDashBoardVMs { get; set; }

        public System.Data.Entity.DbSet<FYPV1.ViewModels.SignUpVM> SignUpVMs { get; set; }

        public System.Data.Entity.DbSet<FYPV1.ViewModels.LogInVM> LogInVMs { get; set; }
    }
}
