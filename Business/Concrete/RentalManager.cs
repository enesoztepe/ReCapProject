using Business.Abstract;
using Business.Constants;
using Core.Untilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (ControlReturnTime(rental.CarId).Success)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            else
               return new ErrorResult(Messages.NotRentable);
        }
        public IResult Update(Rental rental)
        {
            if (ControlReturnTime(rental.CarId).Success)
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.RentalUpdated);
            }
            else
                return new ErrorResult(Messages.NotRentable);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }
        public IResult ControlReturnTime(int id)
        {
            List<Rental> carRentals = _rentalDal.GetAll(r => r.CarId == id);
            if (carRentals.Count == 0)
                return new SuccessResult();
            else
            {
                foreach (var car in carRentals)
                {
                    if (car.ReturnDate == null)
                    {
                        return new ErrorResult();
                    }
                }
            }
            return new SuccessResult();
        }
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }
    }
}
