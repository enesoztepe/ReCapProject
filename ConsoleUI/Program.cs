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
            // UserServiceTest();
            // CustomerServiceTest();
            RentalServiceTest();

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
        #region UserTestServices
        static void UserServiceTest()
        {
            Console.Clear();
            UserManager userManager = new UserManager(new EfUserDal());
            UserGetAll(userManager);
            UserGetById(userManager);
            Console.ReadKey();

            Console.Clear();
            UserGetAll(userManager);
            UserInsert(userManager);
            Console.ReadKey();

            Console.Clear();
            UserGetAll(userManager);
            UserUpdate(userManager);
            Console.ReadKey();

            Console.Clear();
            UserGetAll(userManager);
            UserDelete(userManager);
            Console.ReadKey();
        }
        static void UserGetAll(UserManager userManager)
        {
            Console.WriteLine("\nUsers,\nId\tFName\tLName\tEmail\t\t\tPassword");
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.Id + "\t" + user.FirstName + "\t" + user.LastName + "\t" + user.Email + "\t" + user.Password);
            }
        }
        static void UserGetById(UserManager userManager)
        {
            Console.Write("Id giriniz : ");
            int id = int.Parse(Console.ReadLine());
            User user = userManager.GetById(id).Data;
            Console.WriteLine(user.Id + "\t" + user.FirstName + "\t" + user.LastName + "\t" + user.Email + "\t" + user.Password);
        }
        static void UserInsert(UserManager userManager)
        {
            User insertedUser = new User();
            Console.WriteLine("User ekleme bilgilerini giriniz,");
            Console.Write("FistName : ");
            insertedUser.FirstName = Console.ReadLine();
            Console.Write("LastName : ");
            insertedUser.LastName = Console.ReadLine();
            Console.Write("Email : ");
            insertedUser.Email = Console.ReadLine();
            Console.Write("Password : ");
            insertedUser.Password = Console.ReadLine();
            var result = userManager.Add(insertedUser);
            if (result.Success)
                Console.WriteLine(result.Message);
            else
                Console.WriteLine(result.Message);
        }
        static void UserUpdate(UserManager userManager)
        {
            Console.Write("Güncellemek istediğiniz kullanıcının idsini giriniz : ");
            int userIdUpdate = int.Parse(Console.ReadLine());
            User updatedUser = userManager.GetById(userIdUpdate).Data;
            Console.Write("FistName : ");
            updatedUser.FirstName = Console.ReadLine();
            Console.Write("LastName : ");
            updatedUser.LastName = Console.ReadLine();
            Console.Write("Email : ");
            updatedUser.Email = Console.ReadLine();
            Console.Write("Password : ");
            updatedUser.Password = Console.ReadLine();
            var result = userManager.Update(updatedUser);
            if (result.Success)
                Console.WriteLine(result.Message);
            else
                Console.WriteLine(result.Message);
        }
        static void UserDelete(UserManager userManager)
        {
            User deletedUser = new User();
            Console.Write("Silmek istediğiniz kullanıcının idsini giriniz : ");
            deletedUser.Id = int.Parse(Console.ReadLine());
            var result = userManager.Delete(deletedUser);
            if (result.Success)
                Console.WriteLine(result.Message);
            else
                Console.WriteLine(result.Message);
        }
        #endregion
        #region CustomerTestServices
        static void CustomerServiceTest()
        {
            Console.Clear();
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());

            CustomerGetAll(customerManager);
            CustomerGetById(customerManager);
            Console.ReadKey();

            Console.Clear();
            CustomerGetAll(customerManager);
            UserGetAll(userManager);
            CustomerInsert(customerManager);
            Console.ReadKey();

            Console.Clear();
            CustomerGetAll(customerManager);
            UserGetAll(userManager);
            CustomerUpdate(customerManager);
            Console.ReadKey();

            Console.Clear();
            CustomerGetAll(customerManager);
            UserGetAll(userManager);
            CustomerDelete(customerManager);
            Console.ReadKey();
        }
        static void CustomerGetAll(CustomerManager customerManager)
        {
            Console.WriteLine("\nCustomers,\nId\tUserId\tCompanyName");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.Id + "\t" + customer.UserId + "\t" + customer.CompanyName);
            }
        }
        static void CustomerGetById(CustomerManager customerManager)
        {
            Console.Write("Id giriniz : ");
            int id = int.Parse(Console.ReadLine());
            Customer customer = customerManager.GetById(id).Data;
            Console.WriteLine(customer.Id + "\t" + customer.UserId + "\t" + customer.CompanyName);
        }
        static void CustomerInsert(CustomerManager customerManager)
        {
            Customer insertedCustomer = new Customer();
            Console.WriteLine("Müşteri ekleme bilgilerini giriniz,");
            Console.Write("UserId : ");
            insertedCustomer.UserId = int.Parse(Console.ReadLine());
            Console.Write("CompanyName : ");
            insertedCustomer.CompanyName = Console.ReadLine(); 
            var result = customerManager.Add(insertedCustomer);
            if (result.Success)
                Console.WriteLine(result.Message);
            else
                Console.WriteLine(result.Message);
        }
        static void CustomerUpdate(CustomerManager customerManager)
        {
            Console.Write("Güncellemek istediğiniz müşterinin idsini giriniz : ");
            int customerIdUpdate = int.Parse(Console.ReadLine());
            Customer updatedCustomer = customerManager.GetById(customerIdUpdate).Data;
            Console.Write("UserId : ");
            updatedCustomer.UserId = int.Parse(Console.ReadLine());
            Console.Write("CompanyName : ");
            updatedCustomer.CompanyName = Console.ReadLine();
            var result = customerManager.Update(updatedCustomer);
            if (result.Success)
                Console.WriteLine(result.Message);
            else
                Console.WriteLine(result.Message);
        }
        static void CustomerDelete(CustomerManager customerManager)
        {
            Customer deletedCustomer = new Customer();
            Console.Write("Silmek istediğiniz müşterinin idsini giriniz : ");
            deletedCustomer.Id = int.Parse(Console.ReadLine());
            var result = customerManager.Delete(deletedCustomer);
            if (result.Success)
                Console.WriteLine(result.Message);
            else
                Console.WriteLine(result.Message);
        }
        #endregion
        #region RentalTestServices
        static void RentalServiceTest()
        {
            Console.Clear();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            CarManager carManager = new CarManager(new EfCarDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            RentalGetAll(rentalManager);
            RentalGetById(rentalManager);
            Console.ReadKey();

            Console.Clear();
            RentalGetAll(rentalManager);
            CarGetAll(carManager);
            CustomerGetAll(customerManager);
            RentalInsert(rentalManager);
            Console.ReadKey();

            Console.Clear();
            RentalGetAll(rentalManager);
            CarGetAll(carManager);
            CustomerGetAll(customerManager);
            RentalUpdate(rentalManager);
            Console.ReadKey();

            Console.Clear();
            RentalGetAll(rentalManager);
            RentalDelete(rentalManager);
            Console.ReadKey();
        }
        static void RentalGetAll(RentalManager rentalManager)
        {
            Console.WriteLine("\nRentals,\nId\tCarId\tCustomerId\tRentDate\t\tRetrunDate");
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.Id + "\t" + rental.CarId + "\t" + rental.CustomerId + "\t\t" + rental.RentDate + "\t" + rental.ReturnDate);
            }
        }
        static void RentalGetById(RentalManager rentalManager)
        {
            Console.Write("Id giriniz : ");
            int id = int.Parse(Console.ReadLine());
            Rental rental = rentalManager.GetById(id).Data;
            Console.WriteLine(rental.Id + "\t" + rental.CarId + "\t" + rental.CustomerId + "\t" + rental.RentDate + "\t" + rental.ReturnDate);
        }
        static void RentalInsert(RentalManager rentalManager)
        {
            Rental? insertedRental = new Rental();
            Console.WriteLine("Kiralama bilgilerini giriniz,");
            Console.Write("CarId : ");
            insertedRental.CarId = int.Parse(Console.ReadLine());
            Console.Write("CustomerId : ");
            insertedRental.CustomerId = int.Parse(Console.ReadLine());
            Console.Write("RentDate : ");
            insertedRental.RentDate = DateTime.Parse(Console.ReadLine());
            Console.Write("ReturnDate : ");
            string stringReturnDate = Console.ReadLine();
            if (stringReturnDate != "")
                insertedRental.ReturnDate = DateTime.Parse(stringReturnDate);
            else
                insertedRental.ReturnDate = null;
            var result = rentalManager.Add(insertedRental);
            if (result.Success)
                Console.WriteLine(result.Message);
            else
                Console.WriteLine(result.Message);
        }
        static void RentalUpdate(RentalManager rentalManager)
        {
            Console.Write("Güncellemek istediğiniz kiralamanın idsini giriniz : ");
            int rentalIdUpdate = int.Parse(Console.ReadLine());
            Rental? updatedRental = rentalManager.GetById(rentalIdUpdate).Data;
            Console.Write("CarId : ");
            updatedRental.CarId = int.Parse(Console.ReadLine());
            Console.Write("CustomerId : ");
            updatedRental.CustomerId = int.Parse(Console.ReadLine());
            Console.Write("RentDate : ");
            updatedRental.RentDate = DateTime.Parse(Console.ReadLine());
            Console.Write("ReturnDate : ");
            string stringReturnDate = Console.ReadLine();
            if (stringReturnDate != "")
                updatedRental.ReturnDate = DateTime.Parse(stringReturnDate);
            else
                updatedRental.ReturnDate = null;
            var result = rentalManager.Update(updatedRental);
            if (result.Success)
                Console.WriteLine(result.Message);
            else
                Console.WriteLine(result.Message);
        }
        static void RentalDelete(RentalManager rentalManager)
        {
            Rental deletedRental = new Rental();
            Console.Write("Silmek istediğiniz kiralamanın idsini giriniz : ");
            deletedRental.Id = int.Parse(Console.ReadLine());
            var result = rentalManager.Delete(deletedRental);
            if (result.Success)
                Console.WriteLine(result.Message);
            else
                Console.WriteLine(result.Message);
        }
        #endregion
    }
}
