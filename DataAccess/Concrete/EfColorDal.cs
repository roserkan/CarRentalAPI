using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfColorDal : EfEntityRepositoryBase<Color, CarRentalDbContext>, IColorDal
    {

    }
}
