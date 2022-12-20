using MediatR;
using Shared.Common.Sources.Responses;

namespace PowerKlubbAPI.Application.Features.Users.Commands.CreateUser;

using DTOs.User;

public record CreateUserCommand(CreateUserDto CreateUserDto) : IRequest<BaseResponse>;
