using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System.Linq.Expressions;

namespace Business.Abstract;

public interface ICarService
{
    IResult Add(Car car);
    IResult Update(Car car);
    IResult Delete(Car car);
    IDataResult<List<Car>> GetAll();
    IDataResult<Car> GetById(int id);
    IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null);

    IResult TransactionalOperation(Car car);
}