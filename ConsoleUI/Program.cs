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
            BrandTest();
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
