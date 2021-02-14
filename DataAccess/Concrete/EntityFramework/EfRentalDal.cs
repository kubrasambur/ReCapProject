using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACar>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentACar context=new RentACar())
            {
                var result = from re in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join ca in context.Cars
                             on re.CarId equals ca.Id
                             join cus in context.Customers
                             on re.CustomerId equals cus.UserId
                             join us in context.Users
                             on cus.UserId equals us.Id
                             join br in context.Brands
                             on ca.BrandId equals br.BrandId
                             select new RentalDetailDto
                             {
                                 Id = re.Id,
                                 CarName = br.BrandName,
                                 CustomerName = cus.CompanyName,
                                 CarId = ca.Id,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate,
                                 UserName = us.FirstName + " " + us.LastName
                             };

                return result.ToList();
            }
        }
    }
}
