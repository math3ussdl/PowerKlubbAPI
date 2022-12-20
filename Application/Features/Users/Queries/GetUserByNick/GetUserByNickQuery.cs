using MediatR;
using Shared.Common.Sources.Responses;

namespace PowerKlubbAPI.Application.Features.Users.Queries.GetUserByNick;

using DTOs.User;

public record GetUserByNickQuery(string Nick) : IRequest<BaseQueryResponse<UserDto>>;
