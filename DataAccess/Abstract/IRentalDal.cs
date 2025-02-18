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
    public interface IRentalDal:IEntitiyRepository<Rental>
    {
        List<RentalDetailDto>GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null);
        //List<RentalDetailDto> GetRentalsDetails();
        
        void CarDeliver(int rentalId);
    }
}
