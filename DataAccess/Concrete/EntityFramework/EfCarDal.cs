using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACar>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using (RentACar context = new RentACar())
            {
                // Products ve categories i birleştirir 'on' satırındaki duruma göre
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 BrandId=c.BrandId, ColorId=c.ColorId, ColorName=co.ColorName, 
                                 DailyPrice=c.DailyPrice, Description= c.Descriptions, Id=c.Id, ModelYear= c.ModelYear
                             };
                return result.ToList();
            }
        }
    }
          
}
