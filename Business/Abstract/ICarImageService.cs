﻿using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Business.Abstract;

public interface ICarImageService
{
    IResult Add(IFormFile file, CarImage carImage);
    IResult Update(IFormFile file, CarImage carImage);
    IResult Delete(CarImage carImage);
    IDataResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter = null);
    IDataResult<CarImage> GetById(int id);
}