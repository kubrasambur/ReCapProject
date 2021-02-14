using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();

            //BrandTest();

            //ColorTest();

            //RentalTest();

            //CustomerTest();

            //UsersTest();

            //RentalTest2();

            //CarDeleteTest();
        }

        private static void CarDeleteTest()
        {
            CarManager carManager1 = new CarManager(new EfCarDal());
            var result = carManager1.Delete(new Car { Id = 19 });
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void RentalTest2()
        {
            RentalManager rentalManager1 = new RentalManager(new EfRentalDal());
            var result = rentalManager1.GetCarStatus(1);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void UsersTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.Add(new User { FirstName = "Kübra", LastName = "Sambur", Email = "k@gmail.com", Password = "123" });
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer { CompanyName = "Kartal" });
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { CarId = 1, CustomerId = 2, RentDate = new DateTime(2020, 02, 13)});
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);

            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAllColors();
            if(result.Success==true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAllBrands();
            if(result.Success==true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car() {ColorId=3, ModelYear=2015, DailyPrice=700, BrandId=3, Descriptions="Manuel dizel"});
            var result = carManager.GetCarsByColorId(3);
            if(result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.ColorId);
                }
            }else
            {
                Console.WriteLine(result.Message);
            }
            
        }
    }
}
