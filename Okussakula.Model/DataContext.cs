using Microsoft.EntityFrameworkCore;
using Okussakula.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okussakula.Model
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<CronogramConsult> CronogramConsults { get; set; }
        public DbSet<Consult> Consults { get; set; }
        public DbSet<ConsultHorario> ConsultHorarios { get; set; }
        public DbSet<CronogramExam> CronogramExams { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamHorario> ExamHorarios { get; set; }
        public DbSet<ExamMedic> ExamMedics { get; set; }
        public DbSet<Instituition> Instituitions { get; set; }
        public DbSet<InstituitionExam> InstituitionExams { get; set; }
        public DbSet<InstituitionSpeciality> InstituitionSpecialities { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
