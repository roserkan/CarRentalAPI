using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System.Linq.Expressions;

namespace DataAccess.Abstract;

public interface IRentalDal : IEntityRepository<Rental>
{
    List<RentalDetailDto> GetCarDetails(Expression<Func<Rental, bool>> filter = null);

}
