using MicroErp.Domain.Entity.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;

namespace MicroErp.Domain.Service.Abstract.Mappers.Dtos;

public class PagintedRequest : BaseAutoMapper
{
    public PagintedRequest()
    {
        CreateMap<PaginatedMetaDataEntity, MetaDataRequest>()
            .ReverseMap();
        CreateMap<PaginatedMetaDataEntity, MetaDataResponse>()
            .ReverseMap();

        CreateMap<RequestPaginatedDto, PaginatedMetaDataEntity>()
            .ForMember(dest => dest.PageNumber,
                source => source.MapFrom(m => m.MetaData.PageNumber))
            .ForMember(dest => dest.PageSize,
                source => source.MapFrom(m => m.MetaData.PageSize))
            .ReverseMap();
    }
}