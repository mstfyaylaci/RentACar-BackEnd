using Core.DataAccess;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntitiyRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetCarDetailsId(int carId);
        List<CarDetailDto> GetCarByBrandIdDetails(int brandId);

        List<CarDetailDto> GetCarByColorIdDetails(int colorId);
        List<CarDetailDto> GetCarByBrandAndColor(int brandId, int colorId);
    }
}
