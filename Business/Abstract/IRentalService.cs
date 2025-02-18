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
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();

        IDataResult<Rental> GetById(int id);

        IDataResult<List<RentalDetailDto>> GetRentalDetails();

        IDataResult<RentalDetailDto> GetByCarIdRentalDetails(int carId);

        IDataResult<bool> CheckIfCanACarBeRented(int carId);
        IDataResult<bool> CheckIfAnyRentalBetweenSelectedDates(int carId,DateTime rentDate,DateTime returnDate);

        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IResult CarDeliver(int rentalId);
    }
}
