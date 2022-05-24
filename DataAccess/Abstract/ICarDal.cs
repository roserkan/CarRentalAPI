using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System.Linq.Expressions;

namespace DataAccess.Abstract;

public interface ICarDal : IEntityRepository<Car>
{

    List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null);

}
