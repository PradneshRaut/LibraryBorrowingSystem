using MediatR;
using ArasvaAssignment.Application.Dtos.MemberDtos;
using ArasvaAssignment.Domain.Common;
using System.Collections.Generic;

namespace ArasvaAssignment.Application.Features.MemberFeature.Query.GetAllMember
{
    public record GetAllMemberQuery(string? search = null, int? isActive = null)
        : IRequest<ApiResponse<IEnumerable<MemberDto>>>;
}
