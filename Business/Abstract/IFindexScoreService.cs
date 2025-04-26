using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;

namespace Business.Abstract
{
    public interface IFindexScoreService
    {
        IDataResult<int> GetCustomerFindexScore(int customerId);
        IDataResult<int> GetCarMinFindexScore(int carId);
    }
}
