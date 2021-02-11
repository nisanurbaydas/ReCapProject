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
            Car car1 = new Car();

            Console.Write("Araç id: ");
            car1.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Araç Marka id: ");
            car1.BrandId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Araç Renk id: ");
            car1.ColorId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Araç model yılı: ");
            car1.ModelYear = Convert.ToInt32(Console.ReadLine());

            Console.Write("Araç fiyatı: ");
            car1.DailyPrice = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Araç model: ");
            car1.Description = Console.ReadLine();

            carManager.Add(car1);

            foreach (var car in carManager.GetCarsByColorId(130))
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
