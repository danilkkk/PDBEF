﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace PDBEF
{
    public class ApplicationContext : DbContext
    {
        // Коллекции сущностей
        public DbSet<Student> Students { get; set; }
        public DbSet<Lector> Lectors { get; set; }
        

        private string ConnectionString;

        private Action<string> Logger;


        public ApplicationContext(string connectionString, Action<string> logger)
        {
            this.ConnectionString = connectionString; // получаем извне строку подключения
            this.Logger = logger; // получаем извне логгер
            Database.EnsureDeleted(); // удаляем базу данных
            Database.EnsureCreated(); // создаем базу данных
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString); // подключение базы данных
            optionsBuilder.LogTo(Logger, LogLevel.Error); // добавляем логгер
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  ====== заполнение первоначальными данными =====


            // преподаватели
            modelBuilder.Entity<Lector>().HasData(
                new Lector[]
                {
                new Lector(1, "Вадим", "Пак", 1970),
                new Lector(2, "Александр", "Щукин", 1990),
                new Lector(3, "Константин", "Туральчук", 2000),
                });

            // студенты

            Student pupa = new Student { Id = 1, Name = "Пупа", Surname = "Зайков", YearOfEntry = 2020 };
            Student lupa = new Student(2, "Лупа", "Карасев", 2020);
            Student vitya = new Student(3, "Виктор", "Баринов", 2020);


            modelBuilder.Entity<Student>().HasData(
                new Student[]
                {
                pupa, lupa, vitya
                });

            // домашние работы
            modelBuilder.Entity<Homework>().HasData(
               new Homework[]
               {
                new Homework(1, "https://aboba.amogus.com/metod-pyzurka.php?lectId=1#homework"),
                new Homework(2, "https://aboba.amogus.com/mnozestva.php?lectId=1#homework"),
                new Homework(3, "https://aboba.amogus.com/metod-pyzurka.php?lectId=2#homework"),
               });

            // лекции

            Lecture lecture1 = new Lecture(1, "2.09.2021", "Сортировка методом пузырька", "https://aboba.amogus.com/metod-pyzurka.php?lectId=1", 1, 2);

           /* lecture1.StudentsWhoAttended.Add(lupa);
            lecture1.StudentsWhoAttended.Add(pupa);
            lecture1.StudentsWhoAttended.Add(vitya);*/

            Lecture lecture2 = new Lecture(2, "3.09.2021", "Множества", "https://aboba.amogus.com/mnozestva.php?lectId=1", 2, 1);

           /* lecture1.StudentsWhoAttended.Add(lupa);
            lecture1.StudentsWhoAttended.Add(vitya);*/

            Lecture lecture3 = new Lecture(3, "9.09.2021", "Сортировка методом пузырька. Дополнительные главы", "https://aboba.amogus.com/metod-pyzurka.php?lectId=2", 3, 2);

           // lecture1.StudentsWhoAttended.Add(vitya);

            modelBuilder.Entity<Lecture>().HasData(
             new Lecture[]
             {
                 lecture1, lecture2, lecture3
             });

            // оценки
            modelBuilder.Entity<Grade>().HasData(
               new Grade[]
               {
                new Grade(1, 3, 1, 1), // Зайков - '3'
                new Grade(2, 4, 3, 1), // Баринов - '4'
                new Grade(3, 5, 3, 2), // Баринов - '5'
               });
        }
    }
}
