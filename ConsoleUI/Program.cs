using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "\t" + car.BrandId + "\t" + 
                    car.ModelYear + "\t" + car.DailyPrice + "\t" + car.Description);
            }

            Console.Write("\nAciklamasını istediğiniz arabanın Id sini giriniz : ");
            int Id = int.Parse(Console.ReadLine());
            foreach (var car in carManager.GetById(Id))
            {
                Console.WriteLine(car.Description);
            }

        }
    }
}
