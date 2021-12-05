using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication13.Models
{
    public class ClinicDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
       
        public ClinicDBContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=veterinary_clinic2;Trusted_Connection=True;");
            // optionsBuilder.UseSqlServer(@"Server=tcp:urosmagnus-server.database.windows.net,1433;Initial Catalog=urosmagnusDB;Persist Security Info=False;User ID=urosmagnus-server-admin;Password=KB8G5CWJ80MG00RR$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            
            optionsBuilder.EnableSensitiveDataLogging(true);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);                     

            Employee[] employees = new Employee[]
            {
                new Employee {
                        Id = 1,
                        Fio = "Быков, Андрей Евгеньевич",
                        Speciality = "Заведующий терапевтическим отделением больницы и руководитель четырёх интернов. Самодур и циник. Является отличным специалистом, но обладает скверным характером.",
                        ImgSrc = "/images/employeers/buk.jpeg",
                        ImgAlt = ""
                    },
                new Employee()
                    {
                        Id = 2,
                        Fio = "Купитман, Иван Натанович",
                        Speciality = "Доктор-дерматовенеролог, кандидат медицинских наук, заведующий кожно-венерологическим отделением больницы. Еврей, хитёр, корыстен. Ценитель дорогого коньяка. Лучший друг Быкова.",
                        ImgSrc = "/images/employeers/kupit.jpg",
                        ImgAlt = ""
                    },
                new Employee()
                    {
                        Id = 3,
                        Fio = "Кисегач, Анастасия Константиновна",
                        Speciality = "Главный врач больницы, любовница, а затем жена Быкова. Женщина с жёстким характером, временами проявляет сентиментальность.",
                        ImgSrc = "/images/employeers/kisja.jpg",
                        ImgAlt = ""
                    },
                new Employee()
                    {
                        Id = 4,
                        Fio = "Левин, Борис Аркадьевич",
                        Speciality = "«Ботаник» с красным дипломом, уверенный в собственной важности. Дотошный и нудный, из-за чего имеет мало друзей.",
                        ImgSrc = "/images/employeers/levin.jpg",
                        ImgAlt = ""
                    },
                new Employee()
                    {
                        Id = 5,
                        Fio = "Романенко, Глеб Викторович",
                        Speciality = "Сын главного врача больницы Анастасии Кисегач от первого брака. Имеет репутацию «мажора», не пренебрегает возможностью разыграть своих коллег и отмазаться от работы. Лучший друг Лобанова.",
                        ImgSrc = "/images/employeers/roman.jpg",
                        ImgAlt = ""
                    },
                new Employee()
                    {
                        Id = 6,
                        Fio = "Лобанов, Семён Семёнович",
                        Speciality = "Интерн, не самый умный и понимающий в медицине, но быстро соображающий как отпроситься с работы и заполучить халяву. Вспыльчив и нетерпелив, ненадёжен в плане долгов. Лучший друг Романенко.",
                        ImgSrc = "/images/employeers/loban.jpg",
                        ImgAlt = ""
                    },
                new Employee()
                    {
                        Id = 7,
                        Fio = "Черноус, Варвара Николаевна",
                        Speciality = "Исполнительная и инициативная, но иногда слишком наивная девушка. Не понимает намёков.",
                        ImgSrc = "/images/employeers/chern.jpg",
                        ImgAlt = ""
                    }
            };
            modelBuilder.Entity<Employee>().HasData(employees);         

        }
    }
}
