using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validaton;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(isCarRented(rental.CarId));

            if (result!=null)
            {
                return result;
            }

            Console.WriteLine("araç şuanda boşta");
            _rentalDal.Add(rental); // eğer araç kiralanmış ama geri teslim edilmiş ise kiralama işlemini yap
            return new SuccessResult(Messages.RentalAdded);


        }

        public IResult CarDeliver(int rentalId)// Araç geir teslim fonk ReturnDate =---> DateTime.now
        {
            _rentalDal.CarDeliver(rentalId);
            return new SuccessResult(Messages.CarIsDelivered);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id), Messages.RentalByListed);
        }



        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalListed);
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        private IResult isCarRented(int carId)
        {
            // kiralanmak istenen aradç id sini ve geri teslim tarihini kontrol et
            // eğer geri teslim tarihi null ise araç geri teslim edilmemiştir aracı kiralama!
            var isCarRented = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate == null).Any();

            if (isCarRented == true) // araba kiralanmış ise kullanıcıyı bildir
            {
                Console.WriteLine("Araç  kiralanmamış");

                return new ErrorResult(Messages.CarNotEmty);
            }
            return new SuccessResult();
        }
    }
}
