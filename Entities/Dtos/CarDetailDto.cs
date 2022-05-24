using Core.Entities;


namespace Entities.Dtos;

public class CarDetailDto : IDto
{
    public int CarId { get; set; }
    public string BrandName { get; set; }
    public string ColorName { get; set; }
    public decimal DailyPrice { get; set; }
    public string ModelYear { get; set; }
    public string Descriptions { get; set; }

    public DateTime CarImageDate { get; set; }
    public string ImagePath { get; set; }

}
