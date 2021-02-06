using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.Clear();
            Console.WriteLine("Id\tBrandId\tColorId\tMYear\tDPrice\tName\tDescription");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "\t" + car.BrandId + "\t" + car.ColorId + "\t"
                    + car.ModelYear + "\t" + car.DailyPrice + "\t" + car.Name + "\t" + car.Description);
            }

            Console.Write("\nÜrünlerini istediğiniz firmanın Id sini giriniz : ");
            int id = int.Parse(Console.ReadLine());
            foreach (var car in carManager.GetCarsByBrandId(id))
            {
                Console.WriteLine(car.Id + "\t" + car.BrandId + "\t" + car.ColorId + "\t"
                    + car.ModelYear + "\t" + car.DailyPrice + "\t" + car.Name + "\t" + car.Description);
            }
            string devamMi;

            Console.Write("Ekleme yapmak istiyor musunuz (E/e) : ");
            devamMi = Console.ReadLine();
            while (devamMi.ToUpper() == "E")
            {
                agein:
                try
                {
                    Car car1 = new Car();
                    Console.WriteLine("Araba ekleme bilgilerini giriniz,");
                    Console.Write("Brand Id : ");
                    car1.BrandId = int.Parse(Console.ReadLine());
                    Console.Write("Color Id : ");
                    car1.ColorId = int.Parse(Console.ReadLine());
                    Console.Write("Name : ");
                    car1.Name = Console.ReadLine();
                    Console.Write("Model Year : ");
                    car1.ModelYear = int.Parse(Console.ReadLine());
                    Console.Write("Daily Price : ");
                    car1.DailyPrice = float.Parse(Console.ReadLine());
                    Console.Write("Description : ");
                    car1.Description = Console.ReadLine(); //Cadillac
                    carManager.Add(car1);
                }
                catch (Exception)
                {
                    Console.WriteLine("Tekrardan girmek için bir tuşa basınız.");
                    Console.ReadKey();
                    Console.Clear();
                    goto agein;
                }
                Console.Write("Yeniden ekleme yapmak istiyor musunuz (E/e) : ");
                devamMi = Console.ReadLine();
            }
        }
    }
}
