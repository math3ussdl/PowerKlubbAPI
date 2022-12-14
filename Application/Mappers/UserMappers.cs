using AutoMapper;
using PowerKlubbAPI.Domain.Entities;

namespace PowerKlubbAPI.Application.Mappers;

using DTOs.User;

public sealed class UserMappers : Profile
{
	public UserMappers()
	{
		CreateMap<User, UserDto>();
		CreateMap<User, FlatUserDto>();

		CreateMap<UpdateUserDto, User>();
	}
}
