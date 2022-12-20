using MediatR;
using Shared.Common.Sources.Responses;

namespace PowerKlubbAPI.Application.Features.Users.Queries.GetUserById;

using DTOs.User;

public record GetUserByIdQuery(Guid UserId) : IRequest<BaseQueryResponse<UserDto>>;
