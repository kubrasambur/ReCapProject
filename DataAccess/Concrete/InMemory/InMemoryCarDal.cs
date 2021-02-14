using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car> {
                new Car {Id=1, BrandId=1, ColorId=1, DailyPrice=500, ModelYear=2003, Descriptions="Otomatik Hybrid"},
                new Car {Id=2, BrandId=2, ColorId=2, DailyPrice=800, ModelYear=2014, Descriptions="Otomatik benzin"},
                new Car {Id=3, BrandId=3, ColorId=3, DailyPrice=400, ModelYear=2009, Descriptions="Manuel dizel"},
                new Car {Id=4, BrandId=4, ColorId=4, DailyPrice=700, ModelYear=2004, Descriptions="Manuel benzin"},
                new Car {Id=5, BrandId=5, ColorId=5, DailyPrice=200, ModelYear=2019, Descriptions="Otomatik dizel"}

                };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c => c.Id == car.Id);

            _car.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int CarId)
        {
            return _car.Where(c => c.Id == CarId).ToList();
        }

        public List<CarDetailDto> GetCarDetail()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c => c.Id == car.Id);

            carToUpdate.Id = car.Id;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Descriptions = car.Descriptions;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
        }
    }
}
