using MicroErp.Domain.Entity.Users;
using MicroErp.Domain.Service.Abstract.Dtos.User.AddNewUser;
using MicroErp.Domain.Service.Abstract.Dtos.User.AddNewUsers;
using MicroErp.Domain.Service.Abstract.Dtos.User.FindOneUser;

namespace MicroErp.Domain.Service.Abstract.Mappers.Dtos.Users;

public class UserMapper : BaseAutoMapper
{
	public UserMapper()
	{
		CreateMap<User, AddNewUserRequestDto>()
			.ReverseMap();

		CreateMap<User, UserEntity>()
			 .ForMember(x => x.Nome, opt => opt.MapFrom(x => x.Nome))
			.ReverseMap();

		CreateMap<UserEntity, User>()
			 .ForMember(x => x.Nome, opt => opt.MapFrom(x => x.Nome))
			 .ReverseMap();

		CreateMap<User, AddNewUsersRequestDto>()
			.ReverseMap();

		CreateMap<User, FindOneUserResponseDto>()
			.ForMember(x => x.Celular, opt => opt.MapFrom(x => x.PhoneNumber))
			.ForMember(x => x.IdUsuario, opt => opt.MapFrom(x => x.Id))
			.ReverseMap();

	}
}
