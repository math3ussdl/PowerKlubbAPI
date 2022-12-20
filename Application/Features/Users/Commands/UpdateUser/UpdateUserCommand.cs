using MediatR;
using Shared.Common.Sources.Responses;

namespace PowerKlubbAPI.Application.Features.Users.Commands.UpdateUser;

using DTOs.User;

public record UpdateUserCommand(UpdateUserDto UpdateUserDto) : IRequest<BaseResponse>;
