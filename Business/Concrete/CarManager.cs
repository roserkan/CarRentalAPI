using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Linq.Expressions;


namespace Business.Concrete;

public class CarManager : ICarService
{
    private readonly ICarDal _carDal;

    public CarManager(ICarDal carDal)
    {
        _carDal = carDal;
    }

    [SecuredOperation("car.add")]
    [ValidationAspect(typeof(CarValidator))]
    [CacheRemoveAspect("ICarService.Get")]
    public IResult Add(Car car)
    {
        _carDal.Add(car);
        return new SuccessResult(Messages.AddedCar);

    }

    public IResult Delete(Car car)
    {

        _carDal.Delete(car);
        return new SuccessResult(Messages.DeletedCar);

    }

    [CacheAspect(duration: 10)]
    [PerformanceAspect(1)]
    public IDataResult<List<Car>> GetAll()
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll());
    }

    public IDataResult<Car> GetById(int id)
    {
        return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
    }

    public IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null)
    {
        return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(filter));

    }

    [ValidationAspect(typeof(CarValidator))]
    public IResult Update(Car car)
    {
        _carDal.Update(car);
        return new SuccessResult(Messages.UpdatedCar);
    }

    [TransactionScopeAspect]
    public IResult TransactionalOperation(Car car)
    {
        _carDal.Update(car);
        _carDal.Add(car);
        return new SuccessResult(Messages.UpdatedCar);
    }
}
