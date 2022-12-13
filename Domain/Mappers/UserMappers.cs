using AutoMapper;
using PowerKlubbAPI.Domain.DTOs.User;
using PowerKlubbAPI.Domain.Entities;

namespace PowerKlubbAPI.Domain.Mappers;

public sealed class UserMappers : Profile
{
	public UserMappers()
	{
		CreateMap<User, UserDto>();
		CreateMap<User, FlatUserDto>();

		CreateMap<UpdateUserDto, User>();
	}
}
