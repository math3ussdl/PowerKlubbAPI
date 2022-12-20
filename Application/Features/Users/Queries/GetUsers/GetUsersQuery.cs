using MediatR;
using Shared.Common.Sources.Responses;

namespace PowerKlubbAPI.Application.Features.Users.Queries.GetUsers;

using DTOs.User;

public record GetUsersQuery(string QuerySearch) : IRequest<BaseQueryResponse<IReadOnlyList<FlatUserDto>>>;
