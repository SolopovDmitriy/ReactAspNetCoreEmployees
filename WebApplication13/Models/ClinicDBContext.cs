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
        public DbSet<Service> Services { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Navigate> Navigations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        public ClinicDBContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:simplewebreactapplication-server.database.windows.net,1433;Initial Catalog=simplewebreactapplication;Persist Security Info=False;User ID=simplewebreactapplication-server-admin;Password=LG0H82ACK801A714$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=veterinary_clinic2;Trusted_Connection=True;");

            // optionsBuilder.UseSqlServer(@"Server=tcp:urosmagnus-server.database.windows.net,1433;Initial Catalog=urosmagnusDB;Persist Security Info=False;User ID=urosmagnus-server-admin;Password=KB8G5CWJ80MG00RR$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            optionsBuilder.EnableSensitiveDataLogging(true);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Subscribe>(entity => {
                entity.HasIndex(e => e.Email).IsUnique();
            });
            modelBuilder.Entity<User>(entity => {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.Login).IsUnique();
            });

            User[] users = new User[]
            {
                new User(){Id = 1, Login = "Admin", Email = "admin@admin.com", Password = SecurePasswordHasher.Hash("qwerty"), DateRegister = DateTime.Now }
            };
            modelBuilder.Entity<User>().HasData(users);

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

            Service[] services = new Service[]
            {
                new Service()
                {
                    Id = 1,
                    Title = "Ветеринарная клиника",
                    Description = "Цель нашей работы – здоровье Ваших любимцев! Мы готовы предоставить высококвалифицированную помощь в любую минуту, 7 дней в неделю, 24 часа в сутки. У нас есть все необходимое, чтоб в максимально короткие сроки провести комплексное аппаратное и лабораторное обследование питомца, ведь чем раньше поставлен диагноз, тем эффективнее будет лечение.УЗИ(в том числе и сложные обследования сердца), цифровая рентгенография, электрокардиография, офтальмо - и отоскопия(обследование ушей животного), гибкая эндоскопия, лабораторные исследования, включая высокоточные экспресс - тесты на инфекционные заболевания. Наши врачи – это эксперты, пециализирующиеся во всех отраслях ветеринарии. ",
                    ImgSrc = "/images/icon/care.png",
                    ImgAlt = "Ветеринарная клиника",
                    Order = 1,
                },
                new Service()
                {
                    Id = 2,
                    Title = "Дневной лагерь с домашними животными",
                    Description = "Цель нашей работы – кгуглосуточный присмотр за домашними животными",
                    ImgSrc = "/images/icon/camp.png",
                    ImgAlt = "Дневной лагерь для любимых питомцев",
                    Order = 2,
                },
                new Service()
                    {
                        Id = 3,
                        Title = "Питание для домашних животных",
                        Description = "Что лучше, сухой корм или собственноручно приготовленная еда? Почему нельзя кормить питомца «человеческой» едой? Как выкормить совсем маленького щенка или котенка? Ответы на эти вопросы вы найдете здесь. Кроме того, вы узнаете, какие последствия может иметь неправильное питание – это поможет вам избежать ошибок и неприятностей, а также подарить вашим любимцам хорошее здоровье и отличное самочувствие.",
                        ImgSrc = "/images/icon/nutrition.png",
                        ImgAlt = "Питание домашних живоных",
                        Order = 3,
                    },
                new Service()
                    {
                        Id = 4,
                        Title = "Страхование домашних животных",
                        Description = "С помощью страхования домашнего животного Вы можете застраховаться от расходов, сопряженных с заболеванием вашего питомца, его кражей или другим неожиданным несчастным случаем.",
                        ImgSrc = "/images/icon/insurance.png",
                        ImgAlt = "Страхование домашних животных",
                        Order = 4,
                    }
            };
            modelBuilder.Entity<Service>().HasData(services);

            Option[] options = new Option[]
            {
                new Option()
                {
                    Id = 1,
                    Name = "siteName",
                    Value = "Ветеринарная клиника имени Быкова",
                    Relation="",
                    Order = 1,
                    isSystem = true
                },
                new Option()
                {
                    Id = 2,
                    Name = "siteDescription",
                    Value = "Полный спектр услуг",
                    Relation="",
                    Order = 1,
                    isSystem = true
                },
                new Option()
                {
                    Id = 3,
                    Name = "siteLogo",
                    Value = "/images/logo.png",
                    Relation="",
                    Order = 1,
                    isSystem = true
                },
                new Option()
                {
                    Id = 4,
                    Name = "email",
                    Value = "info@bukovvpetcare.com",
                    Relation="",
                    Order = 1,
                    isSystem = true
                },
                new Option()
                {
                    Id = 5,
                    Name = "Twitter",
                    Key = "https://twitter.com/?lang=ru",
                    Value = "/images/icon/tw-ic.png",
                    Relation="socialLinks",
                    Order = 1
                },
                new Option()
                {
                    Id = 6,
                    Name = "Facebook",
                    Key = "https://www.facebook.com/",
                    Value = "/images/icon/fb-ic.png",
                    Relation="socialLinks",
                    Order = 2
                },
                new Option()
                {
                    Id = 7,
                    Name = "LinkedIn",
                    Key = "https://ru.linkedin.com/",
                    Value = "/images/icon/in-ic.png",
                    Relation="socialLinks",
                    Order = 3
                }
            };
            modelBuilder.Entity<Option>().HasData(options);

            Navigate[] navigates = new Navigate[]
            {
                new Navigate()
                {
                     Id = 1,
                     Title = "Главная",
                     Href = "/home/index",
                     Order = 1
                },
                new Navigate()
                {
                     Id = 2,
                     Title = "О Нас",
                     Href = "/about/index",
                     Order = 2
                },
                new Navigate()
                {
                     Id = 3,
                     Title = "ОБРАТНАЯ СВЯЗЬ",
                     Href = "#",
                     Order = 4
                },
                new Navigate()
                {
                     Id = 4,
                     Title = "СВЯЗАТЬСЯ С НАМИ",
                     Href = "/about/ContactUs",
                     Order = 1,
                     Parent_Id = 3
                },
                new Navigate()
                {
                     Id = 5,
                     Title = "Сотрудники",
                     Href = "/home/employees",
                     Order = 3
                },
                new Navigate()
                {
                     Id = 6,
                     Title = "БЫКОВ, АНДРЕЙ ЕВГЕНЬЕВИЧ",
                     Href = "/home/employeer/1",
                     Order = 1,
                     Parent_Id = 5
                },
                new Navigate()
                {
                     Id = 7,
                     Title = "ЧЕРНОУС, ВАРВАРА НИКОЛАЕВНА",
                     Href = "/home/employeer/7",
                     Order = 2,
                     Parent_Id = 5
                },
                new Navigate()
                {
                     Id = 8,
                     Title = "КИСЕГАЧ, АНАСТАСИЯ КОНСТАНТИНОВНА",
                     Href = "/home/employeer/3",
                     Order = 3,
                     Parent_Id = 5
                }
            };
            modelBuilder.Entity<Navigate>().HasData(navigates);

            Category[] categories = new Category[]
            {
                new Category()
                {
                    Id = 1,
                    Title = "Новости",
                    Description = "",
                    Slogan = "Горячие ветеринарные новости",
                    Order = 1,
                    ImgSrc = "/images/categories/news.png",

                },
                new Category()
                {
                    Id = 2,
                    Title = "Услуги",
                    Description = "",
                    Slogan = "Цивилизованные ветеринарные услуги каждому любимцу",
                    Order = 2,
                    ImgSrc = "/images/categories/services.png",
                },
                new Category()
                {
                    Id = 3,
                    Title = "Достижения",
                    Description = "",
                    Slogan = "Новые и передовые подходы ветеринарной медицины",
                    Order = 3,
                    ImgSrc = "/images/categories/achievement.png",
                }
            };
            modelBuilder.Entity<Category>().HasData(categories);


            Comment[] comments = new Comment[]
            {
                new Comment()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    IsValid = true,
                    IsReview = true,
                    Post_Id = 1,
                    Message = "Всем доволен, они так трепетно и аккуратно поствили клизму моему питомцу, что я понял что он в надежных руках",
                    VisitorAvatar = "/images/author/author.jpg",
                    VisitorEmail = "mike@email.com",
                    VisitorName = "Майкл Мандаринофф"
                },
                 new Comment()
                {
                    Id = 2,
                    DateCreated = DateTime.Now,
                    IsValid = true,
                    IsReview = true,
                    Post_Id = 1,
                    Message = "Все ок, качественно, дорого, соответсвующе. ",
                     VisitorAvatar = "/images/author/author.jpg",
                    VisitorEmail = "chak@norris.com",
                    VisitorName = "Чакка Норриса"
                },
                  new Comment()
                {
                    Id = 3,
                    DateCreated = DateTime.Now,
                    IsValid = true,
                    IsReview = true,
                    Post_Id = 1,
                    Message = "Санта - Барбара отдыхает",
                     VisitorAvatar = "/images/author/author.jpg",
                    VisitorEmail = "hideuser@com.ua",
                    VisitorName = "Невидимы йпользователь"
                },
                   new Comment()
                {
                    Id = 4,
                    DateCreated = DateTime.Now,
                    IsValid = true,
                    IsReview = true,
                    Post_Id = 1,
                    Parent_Id = 3,
                    Message = "Ага, мой любимый сериал, посмотрел почти все 3500 серий",
                    VisitorAvatar = "/images/author/author.jpg",
                    VisitorEmail = "chak@norris.com",
                    VisitorName = "Чакка Норриса"
                },
                   new Comment()
                {
                    Id = 5,
                    DateCreated = DateTime.Now,
                    IsValid = true,
                    IsReview = true,
                    Post_Id = 1,
                    Parent_Id = 3,
                    Message = "Фуу, эту гадость смотреть - себя не уважать",
                    VisitorAvatar = "/images/author/author.jpg",
                    VisitorEmail = "mike@email.com",
                    VisitorName = "Майкл Мандаринофф"
                }
            };
            modelBuilder.Entity<Comment>().HasData(comments);


            Post[] posts = new Post[]
            {
                new Post() {
                    Id = 1,
                    CategoryId = 2,
                    ImgSrc = "/images/posts/1.jpg",
                    PostedOn = true,
                    Title = "Пальпация - новый и продвинутый метод обследования животных",
                    Slogan = "Физический метод медицинской диагностики, проводимый путём ощупывания тела пациента",
                    UrlSlug = "palpatio",
                    DateOfPublished = DateTime.Now
                },
                new Post() {
                    Id = 2,
                    CategoryId = 2,
                    ImgSrc = "/images/posts/2.jpg",
                    PostedOn = true,
                    Title = "Анализ шума как сумма различных по свойствам звуков, где нельзя выделить основной тон",
                    Slogan = "Перкуссия - метод медицинской диагностики, заключающийся в простукивании отдельных участков тела и анализе звуковых явлений, возникающих при этом.",
                    UrlSlug = "palpatio",
                    DateOfPublished = DateTime.Now
                },
                new Post() {
                    Id = 3,
                    CategoryId = 2,
                    ImgSrc = "/images/posts/3.jpg",
                    PostedOn = true,
                    Title = "Термометрия — процедура измерения температуры тела.",
                    Slogan = "Исследование весьма простое и должно проводиться у каждого больного. Измерение температуры тела обычно производится медицинским максимальным термометром со шкалой, градуированной по Цельсию",
                    UrlSlug = "palpatio",
                    DateOfPublished = DateTime.Now
                },
                new Post() {
                    Id = 4,
                    CategoryId = 2,
                    ImgSrc = "/images/posts/4.jpg",
                    PostedOn = true,
                    Title = "Аускультация  - новый и продвинутый метод обследования животных",
                    Slogan = "Физический метод медицинской диагностики, заключающийся в выслушивании звуков, образующихся в процессе функционирования внутренних органов",
                    UrlSlug = "auscultatio",
                    DateOfPublished = DateTime.Now
                },
                new Post() {
                    Id = 5,
                    CategoryId = 3,
                    ImgSrc = "/images/posts/5.jpg",
                    PostedOn = true,
                    Title = "Ветеринарная биотехнология",
                    Slogan = "Биотехнология использует микроорганизмы и вирусы, которые в процессе своей жизнедеятельности вырабатывают естественным путем необходимые нам вещества — витамины, ферменты, аминокислоты, органические кислоты, спирты, антибиотики и др. биологически активные соединения.",
                    UrlSlug = "",
                    DateOfPublished = DateTime.Now
                },
                new Post() {
                    Id = 6,
                    CategoryId = 3,
                    ImgSrc = "/images/posts/6.jpg",
                    PostedOn = true,
                    Title = "Рекомбинантные вакцины",
                    Slogan = "производства этих вакцин применяют методы генной инженерии, встраивая генетический материал микроорганизма в дрожжевые клетки, продуцирующие антиген. После культивирования дрожжей из них выделяют нужный антиген, очищают и готовят вакцину. Примером таких вакцин может служить вакцина против гепатита В, а также вакцина против вируса папилломы человека",
                    UrlSlug = "vaccinus",
                    DateOfPublished = DateTime.Now
                },
                new Post() {
                    Id = 7,
                    CategoryId = 3,
                    ImgSrc = "/images/posts/7.jpg",
                    PostedOn = true,
                    Title = "Вакцины – антигены",
                    Slogan = "производства этих вакцин применяют методы генной инженерии, встраивая генетический материал микроорганизма в дрожжевые клетки, продуцирующие антиген. После культивирования дрожжей из них выделяют нужный антиген, очищают и готовят вакцину. Примером таких вакцин может служить вакцина против гепатита В, а также вакцина против вируса папилломы человека",
                    UrlSlug = "vaccinus",
                    DateOfPublished = DateTime.Now
                },
            };
            modelBuilder.Entity<Post>().HasData(posts);
        }
    }
}
