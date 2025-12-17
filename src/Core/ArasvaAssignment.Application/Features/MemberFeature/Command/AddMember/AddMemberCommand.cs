using ArasvaAssignment.Application.Dtos.MemberDtos;
using ArasvaAssignment.Domain.Common;
using MediatR;

namespace ArasvaAssignment.Application.Features.MemberFeature.Command.AddMember
{
    public record AddMemberCommand(AddMemberDto AddMemberDto) : IRequest<ApiResponse<MemberDto>>;
}
