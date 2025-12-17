using ArasvaAssignment.Application.Contracts.Persistence;
using ArasvaAssignment.Application.Dtos.MemberDtos;
using ArasvaAssignment.Domain.Entities;
using ArasvaAssignment.Infrastructure.Helper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ArasvaAssignment.Application.Features.MemberFeature.Query.LoginMember
{
    public class LoginMemberQueryHandler
        : IRequestHandler<LoginMemberQuery, LoginResponseDto>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly JwtHelper _jwtHelper;

        private readonly PasswordHasher<Member> _passwordHasher = new();

        public LoginMemberQueryHandler(
            IMemberRepository memberRepository,
            JwtHelper jwtHelper)
        {
            _memberRepository = memberRepository;
            _jwtHelper = jwtHelper;
        }

        public async Task<LoginResponseDto> Handle(
            LoginMemberQuery request,
            CancellationToken cancellationToken)
        {
            var login = request.Login;
             
            var user = await _memberRepository.GetMemberByEmail(login.Username);

            if (user == null)
            {
                return new LoginResponseDto
                {
                    Success = false,
                    Message = "Invalid username"
                };
            }

            if (!user.IsActive)
            {
                return new LoginResponseDto
                {
                    Success = false,
                    Message = "Account is disabled"
                };
            }
             
            var passwordResult = _passwordHasher.VerifyHashedPassword(
                user,
                user.Password,
                login.Password
            );

            if (passwordResult == PasswordVerificationResult.Failed)
            {
                return new LoginResponseDto
                {
                    Success = false,
                    Message = "Invalid password"
                };
            }
             
            const int tokenValidityMinutes = 60;

            var token = _jwtHelper.GenerateToken(user.Id, user.Email);

            return new LoginResponseDto
            {
                Success = true,
                Message = "Login successful",
                Token = token,
                TokenValidityInMinutes = tokenValidityMinutes
            };
        }
    }
}
