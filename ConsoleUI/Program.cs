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
            // CarServiceTest();
            // BrandServiceTest();
            // ColorServiceTest();

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
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "\t" + car.BrandId + "\t" + car.ColorId + "\t"
                    + car.ModelYear + "\t" + car.DailyPrice + "\t" + car.Name + "\t" + car.Description);
            }
        }
        static void CarGetDetails(CarManager carManager)
        {
            Console.WriteLine("Cars,\nId\tBName\tCName\tMYear\tDPrice\tName\tDescription");
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.Id + "\t" + car.BrandName + "\t" + car.ColorName + "\t"
                    + car.ModelYear + "\t" + car.DailyPrice + "\t" + car.Name + "\t" + car.Description);
            }
        }
        static void CarGetById(CarManager carManager)
        {
            Console.Write("\nId giriniz : ");
            int id = int.Parse(Console.ReadLine());
            Car car = carManager.GetById(id);
            Console.WriteLine(car.Id + "\t" + car.BrandId + "\t" + car.ColorId + "\t"
                    + car.ModelYear + "\t" + car.DailyPrice + "\t" + car.Name + "\t" + car.Description);
        }
        static void CarInsert(CarManager carManager)
        {
        ageinInsert:
            try
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
                carManager.Add(insertedCar);
            }
            catch (Exception)
            {
                Console.WriteLine("Tekrardan girmek için bir tuşa basınız.");
                Console.ReadKey();
                Console.Clear();
                goto ageinInsert;
            }
        }
        static void CarUpdate(CarManager carManager)
        {
        ageinUpdate:
            try
            {
                Car updatedCar = new Car();
                Console.Write("\ngüncellemek istediğiniz arabanın idsini giriniz : ");
                int carIdUpdate = int.Parse(Console.ReadLine());
                updatedCar = carManager.GetById(carIdUpdate);
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
                carManager.Update(updatedCar);
            }
            catch (Exception)
            {
                Console.WriteLine("Tekrardan girmek için bir tuşa basınız.");
                Console.ReadKey();
                Console.Clear();
                goto ageinUpdate;
            }
        }
        static void CarDelete(CarManager carManager)
        {
            Car deletedCar = new Car();
            Console.Write("\nSilmek istediğiniz arabanın idsini giriniz : ");
            deletedCar.Id = int.Parse(Console.ReadLine());
            carManager.Delete(deletedCar);
        }
        static void CarGetCarsByBrandId(CarManager carManager)
        {
            Console.Write("\nListelemek İçin BrandId giriniz : ");
            int brandId = int.Parse(Console.ReadLine());
            Console.WriteLine("Id\tBrandId\tColorId\tMYear\tDPrice\tName\tDescription");
            foreach (var car in carManager.GetCarsByBrandId(brandId))
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
            foreach (var car in carManager.GetCarsByColorId(colorId))
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
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Id + "\t" + brand.Name);
            }
        }
        static void BrandGetById(BrandManager brandManager)
        {
            Console.Write("Id giriniz : ");
            int id = int.Parse(Console.ReadLine());
            Brand brand = brandManager.GetById(id);
            Console.WriteLine(brand.Id + "\t" + brand.Name);
        }
        static void BrandInsert(BrandManager brandManager)
        {
        ageinInsert:
            try
            {
                Brand insertedBrand = new Brand();
                Console.WriteLine("Brand ekleme bilgilerini giriniz,");
                Console.Write("Name : ");
                insertedBrand.Name = Console.ReadLine();
                brandManager.Add(insertedBrand);
            }
            catch (Exception)
            {
                Console.WriteLine("Tekrardan girmek için bir tuşa basınız.");
                Console.ReadKey();
                Console.Clear();
                goto ageinInsert;
            }
        }
        static void BrandUpdate(BrandManager brandManager)
        {
        ageinUpdate:
            try
            {
                Brand updatedBrand = new Brand();
                Console.Write("güncellemek istediğiniz brandın idsini giriniz : ");
                int brandIdUpdate = int.Parse(Console.ReadLine());
                updatedBrand = brandManager.GetById(brandIdUpdate);
                Console.Write("Name : ");
                updatedBrand.Name = Console.ReadLine();
                brandManager.Update(updatedBrand);
            }
            catch (Exception)
            {
                Console.WriteLine("Tekrardan girmek için bir tuşa basınız.");
                Console.ReadKey();
                Console.Clear();
                goto ageinUpdate;
            }
        }
        static void BrandDelete(BrandManager brandManager)
        {
            Brand deletedBrand = new Brand();
            Console.Write("Silmek istediğiniz brandın idsini giriniz : ");
            deletedBrand.Id = int.Parse(Console.ReadLine());
            brandManager.Delete(deletedBrand);
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
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Id + "\t" + color.Name);
            }
        }
        static void ColorGetById(ColorManager colorManager)
        {
            Console.Write("Id giriniz : ");
            int id = int.Parse(Console.ReadLine());
            Color color = colorManager.GetById(id);
            Console.WriteLine(color.Id + "\t" + color.Name);
        }
        static void ColorInsert(ColorManager colorManager)
        {
        ageinInsert:
            try
            {
                Color insertedColor = new Color();
                Console.WriteLine("Color ekleme bilgilerini giriniz,");
                Console.Write("Name : ");
                insertedColor.Name = Console.ReadLine();
                colorManager.Add(insertedColor);
            }
            catch (Exception)
            {
                Console.WriteLine("Tekrardan girmek için bir tuşa basınız.");
                Console.ReadKey();
                Console.Clear();
                goto ageinInsert;
            }
        }
        static void ColorUpdate(ColorManager colorManager)
        {
        ageinUpdate:
            try
            {
                Color updatedColor = new Color();
                Console.Write("güncellemek istediğiniz colorun idsini giriniz : ");
                int colorIdUpdate = int.Parse(Console.ReadLine());
                updatedColor = colorManager.GetById(colorIdUpdate);
                Console.Write("Name : ");
                updatedColor.Name = Console.ReadLine();
                colorManager.Update(updatedColor);
            }
            catch (Exception)
            {
                Console.WriteLine("Tekrardan girmek için bir tuşa basınız.");
                Console.ReadKey();
                Console.Clear();
                goto ageinUpdate;
            }
        }
        static void ColorDelete(ColorManager colorManager)
        {
            Color deletedColor = new Color();
            Console.Write("Silmek istediğiniz colorun idsini giriniz : ");
            deletedColor.Id = int.Parse(Console.ReadLine());
            colorManager.Delete(deletedColor);
        }
        #endregion
    }
}
