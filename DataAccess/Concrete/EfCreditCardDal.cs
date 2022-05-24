﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfCreditCardDal : EfEntityRepositoryBase<CreditCard, CarRentalDbContext>, ICreditCardDal
    {
    }
}
