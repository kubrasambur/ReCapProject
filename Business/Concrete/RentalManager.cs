using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rentals)
        {
            _rentalDal.Add(rentals);
            return new SuccessResult(Messages.CarsRented);
        }

        public IResult CheckReturnDate(Rental rentals)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Rental rentals)
        {
            _rentalDal.Delete(rentals);
            return new SuccessResult(Messages.RentDeleted);
        }

        public IDataResult<List<Rental>> GetAllRentals()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentedListed);
        }

        public IResult GetCarStatus(int carId)
        {
            if (_rentalDal.GetRentalDetails(r => r.CarId==carId && r.ReturnDate==null).Count>0)
            {
                return new SuccessResult(Messages.CarInRent);
            }
            else
            {
                return new ErrorResult(Messages.AvailableForRent);
            }
            
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
            }
        }

        public IResult Update(Rental rentals)
        {
            _rentalDal.Update(rentals);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
