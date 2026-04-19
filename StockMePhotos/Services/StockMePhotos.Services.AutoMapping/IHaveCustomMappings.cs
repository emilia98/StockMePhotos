using AutoMapper;

namespace StockMePhotos.Services.AutoMapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
