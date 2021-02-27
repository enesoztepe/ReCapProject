using Business.Abstract;
using Business.Constants;
using Core.Untilities;
using Core.Untilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public IResult Add(CarImage carImage, IFormFile file)
        {
            var result = CheckIfImageCountOfCarExceeded(carImage.CarId);

            if (!result.Success)
            {
                return result;
            }
            string path = @"C:\Users\Enes\source\repos\enesoztepe\ReCapProject\DataAccess\Images\"
                                            + carImage.CarId + "-picture-" + result.Data + ".jpg";
            using (FileStream fileStream = System.IO.File.Create(path))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            carImage.ImagePath = path;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }
        public IResult Update(CarImage carImage, IFormFile file)
        {
            var result = _carImageDal.Get(c => c.Id == carImage.Id);
            if (result == null)
            {
                return new ErrorResult();
            }
            File.Delete(result.ImagePath);
            using (FileStream fileStream = System.IO.File.Create(result.ImagePath))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            carImage.ImagePath = result.ImagePath;
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.CarImageUpdated);
        }
        public IResult Delete(CarImage carImage)
        {
            var result = _carImageDal.Get(c => c.Id == carImage.Id);
            File.Delete(result.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            var result = _carImageDal.Get(c => c.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<CarImage>();
            }
            return new SuccessDataResult<CarImage>(result);
        }
        public IDataResult<List<CarImage>> GetCarImages(int id)
        {
            string path = @"C:\Users\Enes\source\repos\enesoztepe\ReCapProject\DataAccess\Images\default.jpg";
            var result = CheckIfImageCountOfCarExceeded(id);
            if (result.Data == 0)
            {
                List<CarImage> carImage = new List<CarImage>
                {
                    new CarImage
                    {
                        CarId = id,
                        ImagePath = path
                    }
                };
                return new SuccessDataResult<List<CarImage>>(carImage);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id));
        }
        private IDataResult<int> CheckIfImageCountOfCarExceeded(int carId)
        {
            int result = _carImageDal.GetAll(i => i.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorDataResult<int>(result, Messages.ImageCountOfCarError);
            }
            return new SuccessDataResult<int>(result);
        }
    }
}
