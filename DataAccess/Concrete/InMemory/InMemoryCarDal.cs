using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ Id = 1 , BrandId = 1 , ModelYear = 2000 , DailyPrice = 25 , Description = "Bu 2000 model bir arabadır" },
                new Car{ Id = 2 , BrandId = 2 , ModelYear = 1995 , DailyPrice = 20 , Description = "Bu 1995 model bir arabadır"},
                new Car{ Id = 3 , BrandId = 2 , ModelYear = 2005 , DailyPrice = 50 , Description = "Bu 2005 model bir arabadır"},
                new Car{ Id = 4 , BrandId = 3 , ModelYear = 2015 , DailyPrice = 130 , Description = "Bu 2015 model bir arabadır"},
                new Car{ Id = 5 , BrandId = 2 , ModelYear = 2020 , DailyPrice = 700 , Description = "Bu 2020 model bir arabadır"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int Id)
        {
            return _cars.SingleOrDefault(c => c.Id == Id);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
