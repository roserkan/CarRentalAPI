using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class ColorManager : IColorService
{
    private readonly IColorDal _colorDal;

    public ColorManager(IColorDal brandDal)
    {
        _colorDal = brandDal;
    }

    [SecuredOperation("admin")]
    [ValidationAspect(typeof(ColorValidator))]
    public IResult Add(Color entity)
    {
        _colorDal.Add(entity);
        return new SuccessResult(Messages.AddedColor);
    }

    [SecuredOperation("admin")]
    public IResult Delete(Color color)
    {
        _colorDal.Delete(color);
        return new SuccessResult(Messages.DeletedColor);

    }

    public IDataResult<List<Color>> GetAll()
    {
        return new SuccessDataResult<List<Color>>(_colorDal.GetAll());

    }

    public IDataResult<Color> GetById(int id)
    {
        return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id));
    }

    [SecuredOperation("admin")]
    [ValidationAspect(typeof(ColorValidator))]
    public IResult Update(Color entity)
    {
        _colorDal.Update(entity);
        return new SuccessResult(Messages.UpdatedColor);

    }
}
