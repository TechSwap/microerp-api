using AutoMapper;

namespace MicroErp.Domain.Service.Abstract.Mappers;

public class BaseAutoMapper : Profile
{
    public BaseAutoMapper()
    {
        AllowNullDestinationValues = true;
        AllowNullCollections = true;
    }
}