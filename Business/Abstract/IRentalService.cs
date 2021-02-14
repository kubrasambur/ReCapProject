using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAllRentals();
        IDataResult<List<RentalDetailDto>> GetRentalDetail();
        IResult Add(Rental rentals);
        IResult Update(Rental rentals);
        IResult CheckReturnDate(Rental rentals);
        IResult Delete(Rental rentals);
        IResult GetCarStatus(int carId);
    }
}
