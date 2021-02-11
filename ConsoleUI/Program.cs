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
            CarServiceTest();
            BrandServiceTest();
            ColorServiceTest();

            Console.ReadKey();
        }

        #region CarTestServices
        static void CarServiceTest()
        {
            Console.Clear();
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            CarGetDetails(carManager);
            CarGetAll(carManager);
            CarGetById(carManager);
            CarGetCarsByBrandId(carManager);
            CarGetCarsByColorId(carManager);
            Console.ReadKey();

            Console.Clear();
            CarGetDetails(carManager);
            BrandGetAll(brandManager);
            ColorGetAll(colorManager);
            CarInsert(carManager);
            Console.ReadKey();

            Console.Clear();
            CarGetDetails(carManager);
            BrandGetAll(brandManager);
            ColorGetAll(colorManager);
            CarUpdate(carManager);
            Console.ReadKey();

            Console.Clear();
            CarGetDetails(carManager);
            BrandGetAll(brandManager);
            ColorGetAll(colorManager);
            CarDelete(carManager);
            Console.ReadKey();
        }
        static void CarGetAll(CarManager carManager)
        {
            Console.WriteLine("\nCars,\nId\tBrandId\tColorId\tMYear\tDPrice\tName\tDescription");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Id + "\t" + car.BrandId + "\t" + car.ColorId + "\t"
                    + car.ModelYear + "\t" + car.DailyPrice + "\t" + car.Name + "\t" + car.Description);
            }
        }
        static void CarGetDetails(CarManager carManager)
        {
            Console.WriteLine("Cars,\nId\tBName\tCName\tMYear\tDPrice\tName\tDescription");
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.Id + "\t" + car.BrandName + "\t" + car.ColorName + "\t"
                    + car.ModelYear + "\t" + car.DailyPrice + "\t" + car.Name + "\t" + car.Description);
            }
        }
        static void CarGetById(CarManager carManager)
        {
            Console.Write("\nId giriniz : ");
            int id = int.Parse(Console.ReadLine());
            Car car = carManager.GetById(id).Data;
            Console.WriteLine(car.Id + "\t" + car.BrandId + "\t" + car.ColorId + "\t"
                    + car.ModelYear + "\t" + car.DailyPrice + "\t" + car.Name + "\t" + car.Description);
        }
        static void CarInsert(CarManager carManager)
        {
            Car insertedCar = new Car();
            Console.WriteLine("\nAraba ekleme bilgilerini giriniz,");
            Console.Write("Brand Id : ");
            insertedCar.BrandId = int.Parse(Console.ReadLine());
            Console.Write("Color Id : ");
            insertedCar.ColorId = int.Parse(Console.ReadLine());
            Console.Write("Name : ");
            insertedCar.Name = Console.ReadLine();
            Console.Write("Model Year : ");
            insertedCar.ModelYear = int.Parse(Console.ReadLine());
            Console.Write("Daily Price : ");
            insertedCar.DailyPrice = float.Parse(Console.ReadLine());
            Console.Write("Description : ");
            insertedCar.Description = Console.ReadLine();
            var result = carManager.Add(insertedCar);
            if (result.Success)
                Console.WriteLine(result.Message);
            else
                Console.WriteLine(result.Message);
        }
        static void CarUpdate(CarManager carManager)
        {
            Car updatedCar = new Car();
            Console.Write("\ngüncellemek istediğiniz arabanın idsini giriniz : ");
            int carIdUpdate = int.Parse(Console.ReadLine());
            updatedCar = carManager.GetById(carIdUpdate).Data;
            Console.Write("Brand Id : ");
            updatedCar.BrandId = int.Parse(Console.ReadLine());
            Console.Write("Color Id : ");
            updatedCar.ColorId = int.Parse(Console.ReadLine());
            Console.Write("Name : ");
            updatedCar.Name = Console.ReadLine();
            Console.Write("Model Year : ");
            updatedCar.ModelYear = int.Parse(Console.ReadLine());
            Console.Write("Daily Price : ");
            updatedCar.DailyPrice = float.Parse(Console.ReadLine());
            Console.Write("Description : ");
            updatedCar.Description = Console.ReadLine();
            var result = carManager.Update(updatedCar);
            if (result.Success)
                Console.WriteLine(result.Message);
            else
                Console.WriteLine(result.Message);
        }
        static void CarDelete(CarManager carManager)
        {
            Car deletedCar = new Car();
            Console.Write("\nSilmek istediğiniz arabanın idsini giriniz : ");
            deletedCar.Id = int.Parse(Console.ReadLine());
            var result = carManager.Delete(deletedCar);
            if (result.Success)
                Console.WriteLine(result.Message);
            else
                Console.WriteLine(result.Message);
        }
        static void CarGetCarsByBrandId(CarManager carManager)
        {
            Console.Write("\nListelemek İçin BrandId giriniz : ");
            int brandId = int.Parse(Console.ReadLine());
            Console.WriteLine("Id\tBrandId\tColorId\tMYear\tDPrice\tName\tDescription");
            foreach (var car in carManager.GetCarsByBrandId(brandId).Data)
            {
                Console.WriteLine(car.Id + "\t" + car.BrandId + "\t" + car.ColorId + "\t"
                    + car.ModelYear + "\t" + car.DailyPrice + "\t" + car.Name + "\t" + car.Description);
            }
        }
        static void CarGetCarsByColorId(CarManager carManager)
        {
            Console.Write("\nListelemek İçin ColorId giriniz : ");
            int colorId = int.Parse(Console.ReadLine());
            Console.WriteLine("Id\tBrandId\tColorId\tMYear\tDPrice\tName\tDescription");
            foreach (var car in carManager.GetCarsByColorId(colorId).Data)
            {
                Console.WriteLine(car.Id + "\t" + car.BrandId + "\t" + car.ColorId + "\t"
                    + car.ModelYear + "\t" + car.DailyPrice + "\t" + car.Name + "\t" + car.Description);
            }
        }
        #endregion
        #region BrandTestServices
        static void BrandServiceTest()
        {
            Console.Clear();
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            BrandGetAll(brandManager);
            BrandGetById(brandManager);
            Console.ReadKey();

            Console.Clear();
            BrandGetAll(brandManager);
            BrandInsert(brandManager);
            Console.ReadKey();

            Console.Clear();
            BrandGetAll(brandManager);
            BrandUpdate(brandManager);
            Console.ReadKey();

            Console.Clear();
            BrandGetAll(brandManager);
            BrandDelete(brandManager);
            Console.ReadKey();
        }
        static void BrandGetAll(BrandManager brandManager)
        {
            Console.WriteLine("\nBrands,\nId\tName");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Id + "\t" + brand.Name);
            }
        }
        static void BrandGetById(BrandManager brandManager)
        {
            Console.Write("Id giriniz : ");
            int id = int.Parse(Console.ReadLine());
            Brand brand = brandManager.GetById(id).Data;
            Console.WriteLine(brand.Id + "\t" + brand.Name);
        }
        static void BrandInsert(BrandManager brandManager)
        {
            Brand insertedBrand = new Brand();
            Console.WriteLine("Brand ekleme bilgilerini giriniz,");
            Console.Write("Name : ");
            insertedBrand.Name = Console.ReadLine();
            var result = brandManager.Add(insertedBrand);
            if (result.Success)
                Console.WriteLine(result.Message);
            else
                Console.WriteLine(result.Message);
        }
        static void BrandUpdate(BrandManager brandManager)
        {
            Brand updatedBrand = new Brand();
            Console.Write("güncellemek istediğiniz brandın idsini giriniz : ");
            int brandIdUpdate = int.Parse(Console.ReadLine());
            updatedBrand = brandManager.GetById(brandIdUpdate).Data;
            Console.Write("Name : ");
            updatedBrand.Name = Console.ReadLine();
            var result = brandManager.Update(updatedBrand);
            if (result.Success)
                Console.WriteLine(result.Message);
            else
                Console.WriteLine(result.Message);
        }
        static void BrandDelete(BrandManager brandManager)
        {
            Brand deletedBrand = new Brand();
            Console.Write("Silmek istediğiniz brandın idsini giriniz : ");
            deletedBrand.Id = int.Parse(Console.ReadLine());
            var result = brandManager.Delete(deletedBrand);
            if (result.Success)
                Console.WriteLine(result.Message);
            else
                Console.WriteLine(result.Message);
        }
        #endregion
        #region ColorTestServices
        static void ColorServiceTest()
        {
            Console.Clear();
            ColorManager colorManager = new ColorManager(new EfColorDal());
            ColorGetAll(colorManager);
            ColorGetById(colorManager);
            Console.ReadKey();

            Console.Clear();
            ColorGetAll(colorManager);
            ColorInsert(colorManager);
            Console.ReadKey();

            Console.Clear();
            ColorGetAll(colorManager);
            ColorUpdate(colorManager);
            Console.ReadKey();

            Console.Clear();
            ColorGetAll(colorManager);
            ColorDelete(colorManager);
            Console.ReadKey();
        }
        static void ColorGetAll(ColorManager colorManager)
        {
            Console.WriteLine("\nColors,\nId\tName");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Id + "\t" + color.Name);
            }
        }
        static void ColorGetById(ColorManager colorManager)
        {
            Console.Write("Id giriniz : ");
            int id = int.Parse(Console.ReadLine());
            Color color = colorManager.GetById(id).Data;
            Console.WriteLine(color.Id + "\t" + color.Name);
        }
        static void ColorInsert(ColorManager colorManager)
        {
            Color insertedColor = new Color();
            Console.WriteLine("Color ekleme bilgilerini giriniz,");
            Console.Write("Name : ");
            insertedColor.Name = Console.ReadLine();
            var result = colorManager.Add(insertedColor);
            if (result.Success)
                Console.WriteLine(result.Message);
            else
                Console.WriteLine(result.Message);
        }
        static void ColorUpdate(ColorManager colorManager)
        {
            Color updatedColor = new Color();
            Console.Write("güncellemek istediğiniz colorun idsini giriniz : ");
            int colorIdUpdate = int.Parse(Console.ReadLine());
            updatedColor = colorManager.GetById(colorIdUpdate).Data;
            Console.Write("Name : ");
            updatedColor.Name = Console.ReadLine();
            var result = colorManager.Update(updatedColor);
            if (result.Success)
                Console.WriteLine(result.Message);
            else
                Console.WriteLine(result.Message);
        }
        static void ColorDelete(ColorManager colorManager)
        {
            Color deletedColor = new Color();
            Console.Write("Silmek istediğiniz colorun idsini giriniz : ");
            deletedColor.Id = int.Parse(Console.ReadLine());
            var result = colorManager.Delete(deletedColor);
            if (result.Success)
                Console.WriteLine(result.Message);
            else
                Console.WriteLine(result.Message);
        }
        #endregion
    }
}
