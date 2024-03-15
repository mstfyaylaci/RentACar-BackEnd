using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();

        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);

        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);

        IDataResult<List<Car>> GetCarsByColorId(int colorId);

        IDataResult<List<CarDetailDto>> GetCarDetails();

        IDataResult<List<CarDetailDto>> GetCarDetailsId(int id);
        IDataResult<List<CarDetailDto>> GetCarByBrandIdDetails(int brandId);
        IDataResult<List<CarDetailDto>> GetCarByColorIdDetails(int colorId);

        IDataResult<List<CarDetailDto>> GetCarByBrandAndColor(int brandId, int colorId);
    }
}
