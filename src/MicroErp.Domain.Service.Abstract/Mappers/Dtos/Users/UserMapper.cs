using MicroErp.Domain.Entity.Users;
using MicroErp.Domain.Service.Abstract.Dtos.User.AddNewUser;
using MicroErp.Domain.Service.Abstract.Dtos.User.AddNewUsers;
using MicroErp.Domain.Service.Abstract.Dtos.User.FindOneUser;
using MicroErp.Domain.Service.Abstract.Dtos.User.ListUsers;

namespace MicroErp.Domain.Service.Abstract.Mappers.Dtos.Users;

public class UserMapper : BaseAutoMapper
{
	public UserMapper()
	{
		CreateMap<User, ListUsersResponseDto>()
			.ReverseMap();

		CreateMap<User, AddNewUserRequestDto>()
			.ReverseMap();

		CreateMap<User, UserEntity>()
			 .ForMember(x => x.Nome, opt => opt.MapFrom(x => x.Nome))
			.ReverseMap();

		CreateMap<UserEntity, User>()
			 .ForMember(x => x.Nome, opt => opt.MapFrom(x => x.Nome))
			 .ReverseMap();

		CreateMap<User, ListUsersResponseDto>()
			.ForMember(x => x.Nome, opt => opt.MapFrom(x => x.Nome))
			.ForMember(x => x.IdUsuario, opt => opt.MapFrom(x => x.Id))
			.ForMember(x => x.Celular, opt => opt.MapFrom(x => x.PhoneNumber))
			.ForMember(x => x.AtivoUsuario, opt => opt.MapFrom(x => x.AtivoUsuario))
			.ForMember(x => x.AtivoDesde, opt => opt.MapFrom(x => x.DataCadastro))
			.ForMember(x => x.InativoDesde, opt => opt.MapFrom(x => x.DataInativacao))
			.ReverseMap();

		CreateMap<User, AddNewUsersRequestDto>()
			.ReverseMap();

		CreateMap<User, FindOneUserResponseDto>()
			.ForMember(x => x.Celular, opt => opt.MapFrom(x => x.PhoneNumber))
			.ForMember(x => x.IdUsuario, opt => opt.MapFrom(x => x.Id))
			.ReverseMap();

	}
}
