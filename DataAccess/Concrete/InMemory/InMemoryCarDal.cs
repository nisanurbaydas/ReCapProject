using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        //hayali veritabanın
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
                new Car{Id=1, BrandId=2, ColorId=123, DailyPrice=5000, ModelYear=2020, Description="Mercedes G63 AMG"},
                new Car{Id=2, BrandId=3, ColorId=542, DailyPrice=10000, ModelYear=2020, Description="Chevy impala 1967"},
                new Car{Id=3, BrandId=4, ColorId=458, DailyPrice=6000, ModelYear=2020, Description="Buugatti veyron"}
            };
        }
        public void Add(Car car)
        {
            //businesstan gelen arabanı hayali veritabanına ekledin
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = null;
            //bu link metodu : Delete metoduna gönderdiğin araba nesnesinin id'si ile
            //hayali veritabanındaki/listendeki tüm arabaların id'lerini tek teek karşılaştırdı
            //eşit olanı bulduktan sonra referansını carToDelete'e atadın
            //yani business katmanından gelenin veritabanı referansını buluyorsun
            carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            //businessa veritabanını verdin
            return _cars;
        }

        public void Update(Car car)
        {
            Car carToUpdate = null;
            carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
        }

        public List<Car> GetAllById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }
    }
}
