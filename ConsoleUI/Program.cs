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
            
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //Console.WriteLine(rentalManager.Add(new Rental { RentalId = 3, CarId = 1, CustomerId = 1, RentDate = "14-05-2021" }).Message);
            //Console.WriteLine(rentalManager.Update(new Rental { RentalId = 1, CarId = 2, CustomerId = 1, RentDate = "12-05-2021", ReturnDate = "15-05-2021" }).Message);
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rentalManager.GetAll().Message);
                Console.WriteLine("Rental Id {0} / Car Id {1} / Customer Id {2} / Rent Date {3} / Return Date {4}", rental.RentalId, rental.CarId, rental.CustomerId, rental.RentDate, rental.ReturnDate);
            }
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Console.WriteLine(customerManager.Add(new Customer { CustomerId = 1, UserId = 1, CompanyName = "Google" }).Message);
            Console.WriteLine(customerManager.Update(new Customer { CustomerId = 1, UserId = 1, CompanyName = "Rockstar Games" }).Message);
            Console.WriteLine(customerManager.Delete(new Customer { CustomerId = 2 }).Message);

            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customerManager.GetAll().Message);
                Console.WriteLine("Customer Id {0} / User Id {1} / Company Name {2}", customer.CustomerId, customer.UserId, customer.CompanyName);
            }

            foreach (var customer in customerManager.GetCustomerDetailDtos().Data)
            {
                Console.WriteLine(customerManager.GetCustomerDetailDtos().Message);
                Console.WriteLine(customer.CustomerName + "/" + customer.CustomerSurname + "/" + customer.CustomerCompany);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            Console.WriteLine(userManager.Add(new User { UserId = 2, FirstName = "Ömer", LastName = "Baydaş", Email = "o@homtail.com", Password = "abcdefg" }).Message);
            userManager.Update(new User { UserId = 2, FirstName = "Ömer Faruk", LastName = "Baydaş", Email = "of@gmail.com", Password = "abcdefg" });
            Console.WriteLine(userManager.Delete(new User { UserId = 2 }).Message);
            
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(userManager.GetAll().Message);
                Console.WriteLine("User Id {0} / User Name {1} / User Surname {2} / User Email {3} / User Password {4}", user.UserId, user.FirstName,user.LastName,user.Email,user.Password);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            //brandManager.Add(new Brand { Id = 4, Name = "Jeep" });
            //brandManager.Update(new Brand { Id = 4, Name = "Mustang" });
            //brandManager.Delete(new Brand { Id = 4 });

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brandManager.GetAll().Message);
                Console.WriteLine("Brand Id {0} / Brand {1} ", brand.Id, brand.Name);

            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { Id = 140, Name = "Blue" });
            colorManager.Update(new Color { Id = 140, Name = "Purple" });
            colorManager.Delete(new Color { Id = 140 });

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("Color Id {0} / Color {1} ", color.Id, color.Name);

            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { Id = 5, BrandId = 1, ColorId = 130, DailyPrice = 2500, Description = "Benz" });
            carManager.Update(new Car { Id = 4, BrandId = 2, ColorId = 130, ModelYear = 2019, DailyPrice = 1800, Description = "divo" });
            carManager.Delete(new Car { Id = 5 });

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("Car Id {0} / Brand Id {1} / Color Id {2} / Daily Price {3}  / Description {4}", car.Id, car.BrandId, car.ColorId, car.DailyPrice, car.Description);
            }

            foreach (var car in carManager.GetCarDetailDtos().Data)
            {
                Console.WriteLine(car.BrandName + "/" + car.Description + "/" + car.ColorName + "/" + car.DailyPrice);
            }
        }
    }
}
