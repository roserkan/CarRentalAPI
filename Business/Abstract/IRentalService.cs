using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System.Linq.Expressions;

namespace Business.Abstract;

public interface IRentalService
{
    IResult Add(Rental rental);
    IResult Delete(Rental rental);
    IResult Update(Rental rental);
    IDataResult<List<Rental>> GetAll();
    IDataResult<Rental> GetById(int id);

    IDataResult<List<RentalDetailDto>> GetRentalDetails(Expression<Func<Rental, bool>> filter = null);
}