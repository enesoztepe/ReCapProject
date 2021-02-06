using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("Id\tBrandId\tColorId\tMYear\tDailyPrice\tDescription");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "\t" + car.BrandId + "\t" + car.ColorId + "\t" +
                    car.ModelYear + "\t" + car.DailyPrice + "\t" + car.Description);
            }

            Console.Write("\nÜrünlerini istediğiniz firmanın Id sini giriniz : ");
            int id = int.Parse(Console.ReadLine());
            foreach (var car in carManager.GetCarsByBrandId(id))
            {
                Console.WriteLine(car.Id + "\t" + car.BrandId + "\t" + car.ColorId + "\t" +
                car.ModelYear + "\t" + car.DailyPrice + "\t" + car.Description);
            }
            

        }
    }
}
