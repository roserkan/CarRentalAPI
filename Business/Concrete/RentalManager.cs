using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Linq.Expressions;

namespace Business.Concrete;

public class RentalManager : IRentalService
{
    private readonly IRentalDal _rentalDal;

    public RentalManager(IRentalDal rentalDal)
    {
        _rentalDal = rentalDal;
    }

    [ValidationAspect(typeof(RentalValidator))]
    public IResult Add(Rental rental)
    {
        IResult result = BusinessRules.Run(CheckCarExistInRentalList(rental));

        if (result != null)
        {
            return result;
        }


        _rentalDal.Add(rental);
        return new SuccessResult(Messages.AddedRental);
    }

    [SecuredOperation("admin")]
    public IResult Delete(Rental rental)
    {
        _rentalDal.Delete(rental);
        return new SuccessResult(Messages.DeletedRental);
    }

    public IDataResult<List<Rental>> GetAll()
    {
        return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
    }

    public IDataResult<Rental> GetById(int id)
    {
        return new SuccessDataResult<Rental>(_rentalDal.Get(I => I.Id == id));
    }

    public IDataResult<List<RentalDetailDto>> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
    {
        return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetCarDetails(filter), Messages.ReturnedRental);
    }

    [ValidationAspect(typeof(RentalValidator))]
    public IResult Update(Rental rental)
    {
        _rentalDal.Update(rental);
        return new SuccessResult(Messages.UpdatedRental);
    }

    private IResult CheckCarExistInRentalList(Rental rental)
    {
        if (rental.ReturnDate > DateTime.Now && _rentalDal.GetCarDetails(I => I.CarId == rental.CarId).Count > 0)
        {
            return new ErrorResult(Messages.FailedRentalAddOrUpdate);
        }

        return new SuccessResult();
    }
}
