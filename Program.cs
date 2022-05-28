using System;
using System.Linq;

namespace PDBEF
{
    internal class Program
    {
        static string connectionParams = "Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;";
        static void Main(string[] args)
        {
            // Добавление
            using (ApplicationContext db = new ApplicationContext(connectionParams, Console.WriteLine))
            {

                /*User user1 = new User("Надежда", "Филимоненкова");
                User user2 = new User("Танзиля", "Черкасова");

                // Добавление
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();


                // получение

                // получаем объекты из бд и выводим на консоль
                var users = db.Users.ToList();
                Console.WriteLine("Данные после добавления:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Surname}");
                }

                // Редактирование

                // получаем первый объект
                User user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    user.Name = "Bob";
                    user.Surname = "Test";
                    //обновляем объект
                    //db.Users.Update(user);
                    db.SaveChanges();
                }

                // выводим данные после обновления
                Console.WriteLine("\nДанные после редактирования:");
                users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}. {u.Name} - {u.Surname}");
                }

                // Удаление

                // получаем первый объект
                user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    //удаляем объект
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
                // выводим данные после обновления
                Console.WriteLine("\nДанные после удаления:");
                users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Surname}");
                }*/
            }

            Console.Read();
        }

    }
}
