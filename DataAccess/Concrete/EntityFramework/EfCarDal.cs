﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, TransportationContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (TransportationContext context = new TransportationContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             join brand in context.Brands
                             on  car.BrandId equals brand.Id
                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 Name = car.Name,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description
                             };
                return result.ToList();
            }
        }
    }
}
